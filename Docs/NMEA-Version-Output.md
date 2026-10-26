# NMEA Version Compatibility in GPS_Out

Analysis of [AgOpenGPS issue #1249](https://github.com/AgOpenGPS-Official/AgOpenGPS/issues/1249) —
"GPS OUT needs to output NMEA v2.3 and above" — and what it means for this repo.

Status: Step 1 (populate the mode indicator) implemented. Version selector not implemented.

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

### Before Step 1: RMC and VTG were v2.3-shaped, but the mode indicator was blank

`PGN_VTG.cs:40` appends a comma before the `*`:

```csharp
cSentence += ",*";
//cSentence += "*";   // line 41 — the previous 8-field form, commented out
```

Producing:

```
$GPVTG,000.0,T,000.0,M,000.0,N,000.0,K,*62
                                       ^ field 9 exists but is empty
```

`PGN_RMC.cs:81` does the same thing, so RMC field 12 is present and empty:

```
$GPRMC,123519.00,A,4807.0380000,N,01131.0000000,E,022.4,084.4,230394,0.0,W,*6A
                                                                          ^ field 12 empty
```

**This is the confirmed cause for the reporter's Trimble display.** Adding `,D` before the
`*` by hand made VTG parse (reported on Telegram, 2026-10-23). GPS_Out satisfies neither
contract cleanly:

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
The field count is correct, but most of the content is placeholder: the satellite IDs are
hardcoded as `01,02,03` and PDOP and VDOP as `2` (`PGN_GSA.cs:48-50`). Only HDOP comes from
AgIO. GSA is only sent when the GSA checkbox is on. NMEA 4.10 adds a system ID field, which
issue #1249 does not mention.

## 4. What a full fix requires

One new setting, three branches.

### Setting

Add `NmeaVersion` (int index) to `GPS_Out/Properties/Settings.settings`, alongside the
existing `SentenceStart` and `SentencePrecisionFormat`. Add it through the Visual Studio
settings designer, which regenerates `Settings.Designer.cs` and updates `App.config`.
Editing only `Settings.Designer.cs` doesn't last, because the next regeneration overwrites it.

### Per-version behaviour

| | ≤2.2 | 2.3–3.01 | 4.00+ |
|---|---|---|---|
| **RMC** | 11 fields — drop the mode indicator field at `PGN_RMC.cs:88` | 12 fields — mode indicator (done); status `V` when fix quality is 0 (done) | 13 fields — add navigational status (`S` safe / `C` caution / `U` unsafe / `V` not valid) |
| **VTG** | 8 fields — drop the mode indicator field at `PGN_VTG.cs:40` | 9 fields — mode indicator (done) | same as 2.3 |
| **GGA** | map Fix Quality `3` → `1`, `4`/`5` → `2`, `6`/`7`/`8` → `1` | pass through | pass through |
| **ZDA** | no change | no change | no change |
| **GSA** | no change | no change | no change |

### Mode indicator mapping

Implemented in `ModeIndicator(byte)` in `Form1.cs`, next to the `FixQuality(byte)` display
helper so the two stay in sync. Derived from `mf.AGIOdata.FixQuality`:

| Fix Quality | Mode indicator |
|---|---|
| 0 (invalid) | `N` |
| 1 (GPS SPS), 3 (PPS) | `A` |
| 2 (DGPS), 4 (RTK), 5 (Float RTK) | `D` |
| 6 (dead reckoning) | `E` |
| 7 (manual input) | `M` |
| 8 (simulation) | `S` |

RTK fix and float are reported as `D`, because the `R` and `F` values exist only in NMEA 4.x.
Simulate mode with AgIO disconnected reports fix quality 4, so it sends `D`.

### UI

A new combo box in the sentence-settings group, next to `cboPrecision` and the
`rbGP` / `rbGN` talker radio buttons. Follow the established pattern from
`cboPrecision_SelectedIndexChanged` (`Form1.cs:364`): write to `Properties.Settings.Default`
on change, restore from it in the load handler around `Form1.cs:478-486`.

## 5. Recommended sequencing

**Step 1 — populate the mode indicator. Done.** `ModeIndicator(byte)` in `Form1.cs` maps
fix quality to the mode value, and RMC and VTG now end with it instead of an empty field.
RMC status is now `V` when fix quality is 0. This keeps the v2.3 field count and fixes the
reporter's Trimble display.

**Step 2 — add the version selector.** Still the right long-term answer for genuinely
pre-2.3 monitors, which need the field actually removed rather than filled.

## 6. Note for upstream

The useful contribution to #1249 is the empty-mode-indicator finding. It narrows the
problem considerably and distinguishes two failure modes that the issue currently treats
as one:

1. Device rejects an empty mode indicator → fixed by Step 1.
2. Device cannot handle the 9-field VTG / 12-field RMC at all → needs Step 2.

The reporter's device is a Trimble display, and it falls under case 1. No pre-2.3 device has
been reported yet, so Step 2 can wait until one is. The screenshots in the issue are AI
output (per the reporter), and their example checksums are all invalid.
