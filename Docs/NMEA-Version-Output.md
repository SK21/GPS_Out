# NMEA Version Compatibility in GPS_Out

Analysis of [AgOpenGPS issue #1249](https://github.com/AgOpenGPS-Official/AgOpenGPS/issues/1249) —
"GPS OUT needs to output NMEA v2.3 and above" — and what it means for this repo.

Status: analysis only, nothing implemented.

---

## 1. Why this issue belongs here

The issue is filed on the AgOpenGPS repo, but AOG core does not emit NMEA. GPS_Out does.
Every sentence a monitor receives is built in `GPS_Out/PGNs/`:

| Sentence | Builder | Version-sensitive? |
|---|---|---|
| GGA | `PGN_GGA.cs` | Only the Fix Quality value |
| RMC | `PGN_RMC.cs` | **Yes** — field count changes |
| VTG | `PGN_VTG.cs` | **Yes** — field count changes |
| ZDA | `PGN_ZDA.cs` | No |
| GSA | `PGN_GSA.cs` | No (within the scope of the issue) |

Whatever is decided upstream, the code change lands in this repo.

## 2. What the issue asks for

Field counts changed between NMEA revisions:

**RMC**
- pre-2.3 → 11 fields
- 2.3 through 3.01 → 12 fields (adds mode indicator)
- 4.00+ → 13 fields (adds navigational status)

**VTG**
- pre-2.3 → 8 fields
- 2.3 and above → 9 fields (adds mode indicator)

**GGA / ZDA** — no structural change. GGA's Fix Quality had fewer valid options pre-2.3.

The requested feature is a selectable output version with three choices: `≤2.2`,
`2.3–3.01`, `4.00+`. The reporter marks it Critical — some devices will not work without it.

## 3. Current GPS_Out output, audited

I counted the fields each builder actually produces.

### RMC and VTG are already v2.3-shaped, but the mode indicator is blank

`PGN_VTG.cs:40` appends a comma before the `*`:

```csharp
cSentence += ",*";
//cSentence += "*";   // line 41 — the previous 8-field form, commented out
```

Producing:

```
$GPVTG,000.0,T,000.0,M,000.0,N,000.0,K,*48
                                       ^ field 9 exists but is empty
```

`PGN_RMC.cs:81` does the same thing, so RMC field 12 is present and empty:

```
$GPRMC,123519.00,A,4807.0380000,N,01131.0000000,E,022.4,084.4,230394,0.0,W,*6A
                                                                          ^ field 12 empty
```

**This is likely the real cause of the reported parse failures.** GPS_Out satisfies
neither contract cleanly:

- A strict v2.3 parser reads field 9 (VTG) / field 12 (RMC), finds an empty string where
  it expects `A` / `D` / `E` / `N`, and rejects the sentence.
- A pre-2.3 parser sees a field count it does not recognise.

The commented-out line 41 shows the output was deliberately moved from the 8-field form to
the 9-field form at some point, without the mode indicator being filled in.

Checksums are unaffected. `CheckSum()` at `Form1.cs:104` XORs from `$` up to but not
including `*`, so the trailing comma is already covered correctly in both forms.

### The other three sentences

**GGA** (`PGN_GGA.cs`) — 14 fields, correct for every NMEA version. The one
version-sensitive element is Fix Quality at `PGN_GGA.cs:79`, which passes AOG's value
straight through:

```csharp
cSentence += "," + mf.AGIOdata.FixQuality.ToString();
```

Pre-2.3 devices do not recognise `4` (RTK) or `5` (Float RTK).

**ZDA** (`PGN_ZDA.cs`) — 6 fields. Unchanged across versions. Nothing to do.

**GSA** (`PGN_GSA.cs`) — 17 fields (mode, fix type, 12 satellite slots, PDOP, HDOP, VDOP).
Correct. NMEA 4.10 adds a system ID field, which issue #1249 does not mention.

## 4. What a full fix requires

One new setting, three branches.

### Setting

Add `NmeaVersion` (int index) to `GPS_Out/Properties/Settings.Designer.cs` and
`App.config`, alongside the existing `SentenceStart` and `SentencePrecisionFormat`.

### Per-version behaviour

| | ≤2.2 | 2.3–3.01 | 4.00+ |
|---|---|---|---|
| **RMC** | 11 fields — drop the trailing comma at `PGN_RMC.cs:81` | 12 fields — **populate** the mode indicator | 13 fields — add navigational status (`A`/`V`/`S`) |
| **VTG** | 8 fields — drop the trailing comma at `PGN_VTG.cs:40` | 9 fields — **populate** the mode indicator | same as 2.3 |
| **GGA** | clamp Fix Quality `4`/`5` → `2` | pass through | pass through |
| **ZDA** | no change | no change | no change |
| **GSA** | no change | no change | no change |

### Mode indicator mapping

Derive from `mf.AGIOdata.FixQuality`:

| Fix Quality | Mode indicator |
|---|---|
| 0 (invalid) | `N` |
| 1 (GPS SPS) | `A` |
| 2 (DGPS), 4 (RTK), 5 (Float RTK) | `D` |
| 6 (dead reckoning) | `E` |
| 8 (simulation) | `S` |

There is already a `FixQuality(byte)` display helper at `Form1.cs:119` doing a comparable
switch — the new mapping belongs next to it so the two stay in sync.

### UI

A fourth combo box in the sentence-settings group, next to `cboPrecision` and the
`rbGP` / `rbGN` talker radio buttons. Follow the established pattern from
`cboPrecision_SelectedIndexChanged` (`Form1.cs:329`): write to `Properties.Settings.Default`
on change, restore from it in the load handler around `Form1.cs:443-451`.

## 5. Recommended sequencing

**Step 1 — populate the mode indicator (two lines).** Change the empty field in RMC and
VTG to a real value. This keeps the current v2.3 field count and may unblock the Critical
cases on its own, since a device failing on VTG today is failing on an empty field, not
necessarily on the field count.

**Step 2 — add the version selector.** Still the right long-term answer for genuinely
pre-2.3 monitors, which need the field actually removed rather than filled.

## 6. Note for upstream

The useful contribution to #1249 is the empty-mode-indicator finding. It narrows the
problem considerably and distinguishes two failure modes that the issue currently treats
as one:

1. Device rejects an empty mode indicator → fixed by Step 1.
2. Device cannot handle the 9-field VTG / 12-field RMC at all → needs Step 2.

Worth asking the reporter which device and which symptom, since that determines whether
the quick fix is sufficient.
