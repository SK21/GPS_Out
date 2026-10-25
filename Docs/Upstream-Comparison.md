# GPS_Out: This Repo vs. the Copy in AgOpenGPS

Comparison of `SK21/GPS_Out` (this repo) against the vendored copy inside
[AgOpenGPS-Official/AgOpenGPS](https://github.com/AgOpenGPS-Official/AgOpenGPS).

Compared on 2026-10-25. Upstream state: `develop` branch at `64984a3` (2026-10-05).
Local state: `main` at `7114115`.

Method: sparse checkout of `SourceCode/GPS_Out` from upstream, then file-by-file diff and
blob-hash matching against local history.

---

## 1. Where each copy lives

| | This repo | Upstream |
|---|---|---|
| Repo | `SK21/GPS_Out` (the `origin` remote) | `AgOpenGPS-Official/AgOpenGPS` |
| Path | `GPS_Out/` | `SourceCode/GPS_Out/Source/` |
| Solution | standalone `GPS_Out.sln` | a project inside `AgOpenGPS.sln` |
| Build output | `..\GPS_OutApp\` | `..\..\..\AgOpenGPS\` (`PublishDir`) |
| App version | **1.2.4** | **1.2.2** |

There is no standalone `GPS_Out` repository in the AgOpenGPS-Official organisation — all 13
org repos were checked. Upstream's copy carries the **same `ProjectGuid`**
(`A9BF85B8-2178-479E-B41B-4E7F84D56A79`) as `GPS_Out/GPS_Out.csproj` here, confirming it is
a copy of this project rather than an independent implementation.

## 2. Fork point: local commit `06d4e50` (2025-07-09)

Three upstream files are byte-identical to their state at local commit `06d4e50`
("change precision, optional simulate data"):

- `App.config`
- `Properties/Settings.settings`
- `Properties/Settings.Designer.cs`

Every other differing file matches **no** blob in local history — checked across all local
branches (`main` and `Development`) with `git log --all`. So upstream is a snapshot taken
around `06d4e50`, with upstream's own edits layered on top.

Local `main` has four commits after that point:

```
7114115  fix default value
4c59f9f  increase precision to 8 decimals for 20/20
a1ff959  show speed always
e178b99  add speed from AOG
06d4e50  change precision, optional simulate data   <-- fork point
```

**The divergence is two-directional.** Neither copy is a superset of the other, so a
straight file copy in either direction loses work.

## 3. Identical in both copies

`PGN100.cs`, **`PGN_GGA.cs`**, **`PGN_VTG.cs`**, `PGN_ZDA.cs`, `Program.cs`,
`frmHelp.cs`, `frmHelp.Designer.cs`, `frmHelp.resx`, `Classes/SerialSend.cs`,
`satellite.ico`, `Resources/On.png`, `Resources/Off.png`, `Resources/Example.rcs`,
`Resources/Example1.rcs`.

## 4. This repo is ahead on

### Speed from AOG — the largest functional gap

`PGNs/PGN254.cs` does not exist upstream. Upstream cannot read AutoSteer speed at all.
Supporting changes, all local-only:

| Location | Change |
|---|---|
| `PGNs/PGN254.cs` | New file. Parses AutoSteer PGN 254 (`0xFE`) for speed in km/h x10. |
| `Classes/UDPcomm.cs:145` | New `case 0xFE7F` routing AutoSteer data to `AutoSteerPGN.ParseByteData` |
| `PGNs/PGN54908.cs:269` | `Speed` getter now falls back to `AutoSteerPGN.Speed_KMH()` before the 4.8 km/h simulate value |
| `Form1.cs:84, 101` | `public PGN254 AutoSteerPGN` field and construction |

### Other local-only changes

- **8-decimal precision.** `cboPrecision` has a fifth item `"8"`; default index 4.
  Upstream stops at `"7"` with default index 3. Both defaults are internally consistent
  (each points at its own maximum), so upstream is not broken — it simply cannot output
  8 decimal places. Needed for 20/20 compatibility.
- **`Classes/UDPcomm.cs:58`** — new `SendUDPMessage(byte[])` for outbound byte arrays.
  Absent upstream.
- **`PGNs/PGN54908.cs:314`** — `Connected()` timeout widened from 4 s to **10 s**.
- **`PGNs/PGN54908.cs:247`** — new `RollSource1` property.
- **`PGNs/PGN_GSA.cs:43`** — new `Sentence` property. Upstream builds the GSA sentence but
  has no way to read it back.
- **`Classes/UDPcomm.cs:137,141`** — PGN switch cases converted from decimal (`54908`,
  `25727`) to hex literals (`0xD67C`, `0x647F`) to match the comments.
- **`Form1.cs:625`** — duplicate `lbAge` assignment removed. Upstream assigns `lbAge.Text`
  twice in `UpdateForm()` — `"N2"` at line 628 and `"N1"` at line 634 — so upstream's first
  assignment is dead code. Local keeps only the `"N2"` form.
- **`Form1.cs:614`** — lat/lon display guard simplified from
  `AOGdata.Connected() && (AGIOdata.Connected() || Simulate)` to `AOGdata.Connected()`.
  Under upstream's condition, AOG roll-corrected position is discarded in favour of AGIO
  position whenever AGIO is disconnected and simulate is off — and AGIO position is 0/0 in
  that state. The local form shows AOG data whenever it is available.
- **New resources** — `Resources/satelliteSim.ico`, `Resources/ConS_SourcesRoll.png`.

## 5. Upstream is ahead on

### Build modernization

Upstream converted to an SDK-style project file — 1,686 bytes against the 5,075-byte legacy
file here:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <PublishDir>..\..\..\AgOpenGPS\</PublishDir>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>
</Project>
```

Consequences: no explicit `<Compile Include>` list, no `Properties/AssemblyInfo.cs`,
and `PackageReference` entries for `System.Memory` 4.6.0 and
`System.Resources.Extensions` 9.0.0. This repo still uses the old
`ToolsVersion="15.0"` format with an enumerated compile list and `AssemblyInfo.cs`.

### Dead-code removal in clsTools.cs

Upstream cut the file from 22,135 to **14,374** bytes by deleting roughly 35 unused helpers
that appear carried over from another project:

`BitRead` · `BitSet` · `BitClear` · `StartWifi` · `StopWifi` · `ReadTextFile` ·
`ReadByteFile` · `WriteActivityLog` · `PrevInstance` · `SaveFile` · `SaveProperty` ·
`NoisyData` · `ParseModID` · `ParseSenID` · `BuildModSenID` · `StringToInt` · `VersionDate`

Local `HEAD` is at 22,814 bytes and still carries all of it.

### Behaviour local dropped

`cbPrecision_SelectedIndexChanged` upstream (`Form1.cs:369`) clears `tbGGA`, `tbVTG`,
`tbRMC`, and `tbZDA` after a precision change, so stale sentences at the old precision do
not linger in the display. The local handler
(`cboPrecision_SelectedIndexChanged`, `Form1.cs:329`) does not. **This is worth
cherry-picking back.**

Note the handler was also renamed (`cbPrecision` to `cboPrecision`). Both copies are
internally consistent — each designer wires up its own spelling — so this is cosmetic.

### UI rework

`Form1.Designer.cs` is 55,654 bytes upstream against 50,721 here (215 lines removed,
185 added). The control *set* is identical; the differences are layout and properties:

- `tabControl1` gains `Appearance = FlatButtons` and `Dock = DockStyle.Fill`
- `Margin` and `TextAlign` set explicitly on `lbAge`, `lbElev`, `lbSats`, `lbHDOP`, `lbSim`
- different `Location`, `Size`, and `Font` values throughout — reads like a DPI/scaling pass
- `btnRescan.Image` uses a new `Resources/ScanPorts.png` upstream; local uses
  `Resources.Update`

`Form1.resx` and `Properties/Resources.resx` differ accordingly.

## 6. Files present on only one side

| Only in this repo | Only upstream |
|---|---|
| `PGNs/PGN254.cs` | `Resources/ScanPorts.png` |
| `Properties/AssemblyInfo.cs` | |
| `Resources/satellite.ico` | |
| `Resources/satelliteSim.ico` | |
| `Resources/ConS_SourcesRoll.png` | |

## 7. Bearing on issue #1249

See [NMEA-Version-Output.md](NMEA-Version-Output.md) for the full analysis of
[AgOpenGPS#1249](https://github.com/AgOpenGPS-Official/AgOpenGPS/issues/1249).

`PGN_GGA.cs` and `PGN_VTG.cs` are **byte-identical** in both copies. `PGN_RMC.cs` differs
only by one commented-out line (upstream retains `//cSentence += "*";` at line 82; local
deleted it).

The empty-mode-indicator defect therefore exists identically in both trees. Any fix has to
land in both places — or this repo gets re-vendored upstream, which would carry the PGN254
speed work across at the same time.

## 8. Re-sync checklist

If the two copies are to be reconciled, the work splits cleanly:

**Bring upstream into here**

1. `clsTools.cs` dead-code removal (low risk, large cleanup)
2. Textbox clearing in the precision handler (small behaviour fix)
3. SDK-style csproj — but note this repo builds standalone to `..\GPS_OutApp\`, so
   `PublishDir` would need adjusting rather than copying
4. UI/DPI layout pass — review before taking; it conflicts with local layout edits

**Bring here into upstream**

1. `PGNs/PGN254.cs` plus its three supporting changes (speed from AOG)
2. 8-decimal precision (combo item + default index)
3. `PGN54908` 10-second timeout and `RollSource1`
4. `PGN_GSA.Sentence`
5. `UDPcomm.SendUDPMessage(byte[])`
6. Duplicate `lbAge` assignment removal
7. Simplified lat/lon display guard
8. Version bump to 1.2.4

`Form1.Designer.cs`, `Form1.resx`, and `Resources.resx` are the genuine conflict points —
both sides edited the layout, and these files do not merge cleanly.
