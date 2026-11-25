# Zeight Portrait Manager

## Build and run

This repository contains one C# Windows Forms executable targeting .NET Framework 4.8. From the repository root in a Visual Studio Developer PowerShell with the desktop build tools and the 4.8 targeting pack, run:

```powershell
msbuild .\ZeightPortraitManager.sln -restore -p:Configuration=Debug
& '.\bin\Debug\Portrait Manager.exe'
msbuild .\ZeightPortraitManager.sln -restore -p:Configuration=Release
```

Outside a Developer PowerShell, call the VS 18 MSBuild directly: `& "C:\Program Files\Microsoft Visual Studio\18\Community\MSBuild\Current\Bin\MSBuild.exe" ZeightPortraitManager.sln /t:Build /p:Configuration=Debug "/p:Platform=Any CPU"`. An older VS 2022 MSBuild on this machine fails with `MSB4019` (missing `Roslyn\Microsoft.CSharp.Core.targets`).

The solution exposes Debug and Release for Any CPU. The classic project explicitly lists source and resource files. Register new files in `ZeightPortraitManager.csproj` and preserve the existing `DependentUpon` relationships for forms and generated files. An optional, machine-specific `PostBuild.local.targets` can run after the build.

Costura.Fody comes from NuGet. The nine runtime DLLs under `lib/` are project references embedded by Costura. When changing archive dependencies, review the reference paths, the binding redirects in `app.config`, and the built executable. German and Russian strings build into separate `de/` and `ru/` satellite resource assemblies. Include those directories when distributing the current localized build. Release output also contains loose copies of the `lib/` DLLs and `Costura.dll`. The executable does not need them at runtime.

The C# sources use language version 7.3 (`LangVersion`), so newer syntax such as switch expressions, `using` declarations, and nullable reference types does not compile.

## Find the code

| Area | Entry points |
| --- | --- |
| Startup and navigation | `Program.Main` starts `MainForm`. Its constructor installs the message filter. Follow `MainForm_Load` in `sources/EventHandler.cs` for startup behavior. `MainForm.cs` owns shared editor state, fonts, and language switching. |
| UI changes | `MainForm.Designer.cs` defines controls, layout, and event wiring. `sources/EventHandler.cs`, `sources/Functions.cs`, `sources/Variables.cs`, and `sources/WindowSizing.cs` are partials of the same form. Names containing `King` often refer to controls shared by several games. |
| Window size and scaling | `sources/WindowSizing.cs`. See [Window sizing](#window-sizing). |
| Portrait creation | Start at `ButtonKingAction_Create_Click` in `EventHandler.cs` for destination selection, naming, and output sizes. Follow `sources/ImageWorks.cs` for crop geometry and PNG rendering. Zoom and pan live in `Functions.cs` (`ZoomPortrait`, `PreFilterMessage` for the mouse wheel) and `EventHandler.cs` (picture drag handlers, `ClampPictureLocation`). |
| Side-by-side editor | `sources/SideBySideEditor.cs`. The constructor calls `InitializeSideBySideEditor`, which places a `ViewSwitch` above the crop panel. In side-by-side mode, `OpenComparison` puts one `ComparisonPane` per slot in a `ComparisonRow` that uses a single shared scale. Each pane edits the bounds of the single view's `PicKing*` picture, so switching views and Create use the same crop. Wasteland 3 (`l`) has only one slot and hides the switch. `DrawCropFrame` and `DrawLegendFrame` draw the titled frame legends in both views. |
| Icons | `sources/UiIcons.cs` draws vector icons for the zoom buttons and the view switch. Bebas Neue has no emoji, and GDI does not fall back to another font for missing glyphs. `UiIcons.Attach` clears a button's `Text` and paints the icon in its `ForeColor`. |
| Gallery and pack import | `LoadGalleryImages`, `LoadArchiveThumbnails`, and `ExtractPortraitsFromArchive` in `Functions.cs` select game-specific loaders and writers. ZIP uses framework compression. RAR and 7z use SharpCompress, with an optional native 7-Zip path for 7z. Preserve cancellation and UI-thread dispatch when changing thumbnail loading. |
| Game definitions and discovery | `Variables.cs` declares the seven profiles using `sources/GameTypeClass.cs`. `sources/SystemWorks.cs` contains install detection, native 7-Zip discovery, filesystem helpers, and font registration. |
| Dialogs | `forms/` contains the web-image and name dialogs, confirmation and message dialogs, and the creation notification. Each has its own designer and resource file. |
| Resources and preferences | `properties/Resources.resx` links application artwork and fonts in `resources/`. Edit UI strings in the neutral, German, and Russian `TextVariables*.resx` files together. Regenerate the corresponding designer when adding a resource key. `CoreSettings.settings` defines the persisted game ID, path, language, window width (`WindowWidth`), and default size (`LargeInterface`). |
| Documentation and historical assets | `README.md` describes the game workflows and portrait sizes. Version 1.5 has been released. Log user-facing changes as short bullets under the `1.5.1 (in development)` changelog entry, and do not edit the entries of released versions. `media/` holds listing and README images. `deprecated/` contains historical assets. |
| UI regression script | `tests/SideBySide.ps1`. See [Verify a change](#verify-a-change). |

## Game-specific behavior

The single-character IDs are persisted settings. Use the existing mapping when reading older settings. For changes to a portrait size or filename, trace creation, gallery lookup, extraction, and backup handling together.

| Game IDs | Player portrait layout |
| --- | --- |
| `k` Kingmaker, `w` Wrath of the Righteous, `r` Rogue Trader | One folder per set with `Fulllength.png`, `Medium.png`, and `Small.png`. Rogue Trader uses different dimensions from Pathfinder. |
| `p` Pillars of Eternity, `t` Tyranny | A shared filename prefix with `_lg.png` and `_sm.png`. Creation writes to both male and female player directories under each game's own data path. |
| `d` Deadfire | Also writes `_convo.png` and `_si.png`. The two small slots share dimensions but carry different images. |
| `l` Wasteland 3 | One PNG under `Custom Portraits`. Creation writes 256 x 256. Import validation accepts near-square images at other resolutions. |

Gallery entries can represent a directory or a filename prefix. Follow the selected game and gallery tab when resolving a target for Change, Clone, or Delete. Companion and NPC editing can involve both first-edit `.backup` files and mod-provided default portraits.

Each crop slot's aspect ratio comes from the profile's `LARGE_AR`, `MEDIUM_AR`, `SMALL_AR`, and `SML2_AR` (height / width) in `Variables.cs`. `AdjustPortraitPanelAspect` in `Functions.cs` sizes the crop frame to exactly that shape, so the frame shows what will be saved. A frame that would be wider than its table cell is narrowed and shortened to match. Owlcat games save with `PortraitCrop.SaveFillCrop`; Obsidian and inXile games with `PortraitCrop.SaveUniformCrop`.

## Window sizing

The window is resizable in fixed steps. Change layout with these rules in mind:

- The design size is 750 x 520 client pixels. The window only takes whole multiples of 75 x 52 (`_sizeSteps`, 10 = compact), so the aspect ratio is exact. `UiScale` is `_sizeSteps / 10`. `WndProc` snaps both `WM_SIZING` (edge and corner drags) and `WM_WINDOWPOSCHANGING` (snap, keyboard, and programmatic resizes) to whole steps that fit the working area.
- `InitializeWindowSize` records every control's design margins, padding, fixed sizes, and absolute table rows and columns, then restores `CoreSettings.WindowWidth` (0 means 1050 if `LargeInterface`, otherwise 750). On each size change, `OnClientSizeChanged` re-applies them scaled, calls `FontInit`, resizes thumbnail cards, and rescales the crop frames and pictures with `ResizeCrop`.
- Fonts for controls come from `UiFont(family, designPoints, ...)`, a cache that multiplies the design size by `UiScale`. Do not assign `new Font(...)` to a control; pass the design size to `UiFont`. `ReleaseUnusedUiFonts` disposes cached fonts that no control uses after a resize or language switch. Fonts created inside `Paint` handlers stay `using`-scoped and multiply by `UiScale` themselves.
- Crop frames and zoomed pictures:
  - **Placement.** `TrackCropFrames` records, in `_cropFrames`, each picture's bounds in units of the frame height whenever the picture moves or resizes (zoom, pan, fit, new image). That is the crop the user framed.
  - **Frame changes.** `AdjustPortraitPanelAspect` records the size it gives each frame in `_intendedFrames` and calls `KeepCrop`. `KeepCrop` re-places the picture for that intended size, so every frame change (window resize, tab switch) keeps the crop, without accumulating rounding.
  - **Hidden tabs.** A hidden tab's table is never laid out: its cells keep stale sizes and layout passes clamp its frame to them, distorting it. So `KeepCrop` ignores the frame's current `ClientSize`, and Create saves through `IntendedFrame(panel)`: `PortraitCrop.SaveFillCrop` and `SaveUniformCrop` take the frame size as a parameter.
  - **Shrinking.** On a window resize, frame heights are captured in `WM_WINDOWPOSCHANGING`, but only for a real size change. `WM_SIZE` re-lays out the tables before `OnClientSizeChanged` runs. Frames under 16 px (no game chosen yet) are skipped.
- Gallery cards are sized from the gallery width without its vertical scroll bar, so their size does not depend on whether the bar happened to be visible.
- During an interactive drag, crop pictures are only stretched. `MainForm_ResizeEnd` re-renders them sharp from the original image (`SharpenResizedCrops`) and saves `WindowWidth`. Resizes outside the drag loop (tracked by `WM_ENTERSIZEMOVE` and `WM_EXITSIZEMOVE`) are sharpened immediately.
- Dialogs call `MainForm.ScaleOwnedWindow(this)` when anchored to the main window. It scales their bounds and every explicitly set font; inherited fonts follow their parent.

## Verify a change

There is no test project in the solution. A reflection-driven script, `tests/SideBySide.ps1`, loads the built executable, drives `MainForm` off-screen, and throws on failure. Run it with Windows PowerShell in STA mode after a build. Its `-Configuration` parameter defaults to `Release`.

```powershell
powershell -NoProfile -STA -ExecutionPolicy Bypass -File tests\SideBySide.ps1 -Configuration Debug
```

- For each game except Wasteland 3, the script loads a distinct gradient into every slot and opens side by side. It checks the pane count, the shape and shared scale of each preview, and whether the row fills its panel at 1050 and 750. It also tests wheel zoom, drag pan, and the three zoom buttons. It confirms that the other crops stay where they are and that switching views twice keeps the crop. Finally it creates the set in a temporary folder and compares the exported PNG pixels with the preview. For Wasteland 3 it only checks that the switch is hidden.
- The script runs inside `powershell.exe`, so any `CoreSettings` it changes are saved to PowerShell's own user config, not the app's.
- The earlier `TabLayout.ps1` and `ZoomResize.ps1` were removed. Nothing automated covers window resizing, tab layout across languages, or font-cache growth now, so check those by hand when you change `WindowSizing.cs` or fonts.

The script covers only side-by-side creation. It does not cover the gallery, import, or single-view creation. Choose the manual checks that exercise the changed code and use a disposable portrait tree for file operations.

- **Creation and cropping.** Load an asymmetric image, pan and zoom, then create a named portrait. Inspect the actual PNG dimensions, filenames, and framing. For Deadfire, use distinct images for the two small slots.
- **Window sizing.** Drag the window edge and corner across several sizes with a zoomed portrait loaded, then create the portrait and compare its framing with the compact size.
- **Gallery changes.** Clone a set and compare the original. Change a companion or NPC portrait twice and check that its first backup still contains the original pixels. Verify that Delete affects only the selected set.
- **Import.** Try a folder and a ZIP containing the same sets, including an incomplete set and a conflicting name. For dependency changes, also open actual 7z and RAR packs from the Release output.
- **Localization and packaging.** Switch among English, German, and Russian, open a dialog, and restart to check the saved language. Repeat from a clean directory containing exactly the files intended for distribution.

## Version control

The maintainer manages all version control. Agents edit files in the working tree only and never run commands that change repository history, refs, or the remote, even when the change looks routine: no `commit`, `merge`, `rebase`, `reset`, `revert`, `stash`, `checkout`/`switch` of branches, `branch` or `tag` creation or deletion, and no `push`, force or otherwise. Read-only commands (`status`, `diff`, `log`, `show`, `blame`, `ls-remote`, `fetch`) are fine. When work is ready, say which files changed and leave staging and committing to the maintainer.
