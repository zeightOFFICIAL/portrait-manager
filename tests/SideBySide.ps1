# Run with Windows PowerShell after building the solution.
param([ValidateSet('Debug', 'Release')][string]$Configuration = 'Release')
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Windows.Forms
$exe = Join-Path $PSScriptRoot "..\bin\$Configuration\Portrait Manager.exe"
$assembly = [Reflection.Assembly]::LoadFrom((Resolve-Path $exe).Path)
$type = $assembly.GetType('PortraitManager.MainForm')
$private = [Reflection.BindingFlags]'Instance,NonPublic'
$gameField = $type.GetField('_gameSelected', [Reflection.BindingFlags]'Static,NonPublic')
$settings = $assembly.GetType('PortraitManager.Properties.CoreSettings').GetProperty('Default').GetValue($null)
$settings.GameType = [char]'-'
$settings.WindowWidth = 750
$settings.Language = [char]'e'
$directory = Join-Path ([IO.Path]::GetTempPath()) ('PortraitComparison-' + [guid]::NewGuid())
$slots = @{ Lrg='Large'; Med='Medium'; Sml='Small'; Sml2='Sml2' }
$colors = @{ Lrg='Red'; Med='Green'; Sml='Blue'; Sml2='Orange' }
function Field($name) { $type.GetField($name,$private).GetValue($form) }
function Assert($condition,$detail) { if (!$condition) { throw "$game - $detail" } }

$form = [Activator]::CreateInstance($type)
try {
    $form.Opacity = 0
    $form.ShowInTaskbar = $false
    $form.Show()
    foreach ($game in 'k','w','r','p','t','d','l') {
        $gameField.SetValue($null,[char]$game)
        $type.GetMethod('LabelCreatePortrait_Click',$private).Invoke($form,@($null,[EventArgs]::Empty))
        $toggle = Field '_viewSwitch'
        if ($game -eq 'l') { Assert (!$toggle.Visible) 'One-slot game shows toggle'; continue }
        foreach ($button in 'ButtonKingLrgZoomIn','ButtonKingLrgZoomOut','ButtonKingLrgZoomReset') {
            Assert ((Field $button).Text -eq '') "$button draws an icon, so it must not show glyph text"
        }
        $keys = switch ($game) {
            { $_ -in 'k','w','r' } { 'Lrg','Med','Sml' }
            { $_ -in 'p','t' } { 'Lrg','Sml' }
            'd' { 'Lrg','Med','Sml','Sml2' }
        }
        $load = $type.GetMethod('LoadImageIntoPortraitBox',$private)
        foreach ($key in $keys) {
            $img = [Drawing.Bitmap]::new(820,600)
            $g = [Drawing.Graphics]::FromImage($img)
            $brush = [Drawing.Drawing2D.LinearGradientBrush]::new([Drawing.Rectangle]::new(0,0,820,600),
                [Drawing.Color]::FromName($colors[$key]),[Drawing.Color]::White,35.0)
            $g.FillRectangle($brush,0,0,820,600)
            $brush.Dispose()
            $g.Dispose()
            $slot = [Enum]::Parse($load.GetParameters()[2].ParameterType,$slots[$key])
            $load.Invoke($form,@((Field "PicKing$key"),$img,$slot))
        }
        $toggle.PerformClick()
        $row = Field '_comparisonRow'
        Assert ($row.Controls.Count -eq $keys.Count) 'Incorrect slot count'
        Assert (!(Field 'LayoutKingPortraitGroups').Visible) 'Source controls visible'
        foreach ($width in 1050,750) {
            $form.ClientSize = [Drawing.Size]::new($width,$width*52/75)
            [Windows.Forms.Application]::DoEvents()
            foreach ($pane in $row.Controls) {
                Assert ($pane.Width -gt 0 -and $pane.Left -ge 0 -and $pane.Right -le $row.Width -and
                        $pane.Top -ge 0 -and $pane.Bottom -le $row.Height) "Clipped pane at $width"
                # Previews show the portrait's real size, or scale it down keeping its exact shape.
                $out = $pane.Output
                $shown = $pane.Controls['Preview'].Size
                Assert ($shown.Width -le $out.Width -and $shown.Height -le $out.Height) "$($pane.Name) preview larger than real size"
                Assert ([Math]::Abs($shown.Width - $out.Width * $shown.Height / $out.Height) -le 1) "$($pane.Name) preview has the wrong shape"
                if ($game -eq 'd' -and $width -eq 1050) { Assert ($shown -eq $out) "$($pane.Name) should be shown at real size" }
            }
        }
        $other = (Field 'PicKingSml').Bounds
        $pane = $row.Controls[0]
        $large = Field 'PicKingLrg'
        $before = $large.Bounds
        $canvas = $pane.Controls['Preview']
        $center = [Drawing.Point]::new($canvas.Width / 2,$canvas.Height / 2)
        Assert ($pane.ZoomAtScreenPoint($canvas.PointToScreen($center),120)) 'Wheel missed preview'
        Assert ($large.Width -gt $before.Width) 'Wheel did not zoom'
        $mouse = [Windows.Forms.MouseEventArgs]
        $left = [Windows.Forms.MouseButtons]::Left
        $down = $mouse::new($left,1,$center.X,$center.Y,0)
        $drag = $mouse::new($left,1,($center.X+10),$center.Y,0)
        $x = $large.Left
        $canvas.GetType().GetMethod('OnMouseDown',$private).Invoke($canvas,@($down))
        $canvas.GetType().GetMethod('OnMouseMove',$private).Invoke($canvas,@($drag))
        $canvas.GetType().GetMethod('OnMouseUp',$private).Invoke($canvas,@($drag))
        Assert ($large.Left -gt $x) 'Dragging did not pan'
        $buttons = @($pane.Controls | Where-Object { $_ -is [Windows.Forms.Button] })
        Assert ($buttons.Count -eq 3) 'Pane should only have zoom in, zoom out and reset'
        $pane.Controls['ZoomReset'].PerformClick()
        $before = $large.Bounds
        $pane.Controls['ZoomIn'].PerformClick()
        Assert ($large.Width -gt $before.Width) 'Zoom did not enlarge active crop'
        $before = $large.Bounds
        $pane.Controls['ZoomOut'].PerformClick()
        Assert ($large.Width -lt $before.Width) 'Zoom out did not shrink active crop'
        $pane.Controls['ZoomIn'].PerformClick()
        Assert ((Field 'PicKingSml').Bounds -eq $other) 'Another crop moved'
        $adjusted = $large.Bounds
        $toggle.PerformClick()
        $toggle.PerformClick()
        Assert ($large.Bounds -eq $adjusted) 'Crop changed after switching views'
        $row = Field '_comparisonRow'
        $samples = @{}
        foreach ($key in $keys) {
            $pane = $row.Controls["ComparePicKing$key"]
            $canvas = $pane.Controls['Preview']
            $frame = $pane.GetType().GetProperty('Frame',$private).GetValue($pane)
            $preview = [Drawing.Bitmap]::new($canvas.Width,$canvas.Height)
            $canvas.DrawToBitmap($preview,$canvas.ClientRectangle)
            $samples[$key] = foreach ($fraction in 0.15,0.5,0.85) {
                $preview.GetPixel([int]($frame.X+$frame.Width*$fraction),[int]($frame.Y+$frame.Height*$fraction))
            }
            $preview.Dispose()
        }
        $settings.GamePath = [IO.Directory]::CreateDirectory((Join-Path $directory $game)).FullName
        $settings.GameType = [char]$game
        $type.GetField('_customPortraitName',$private).SetValue($form,'Test')
        (Field 'ButtonKingCreateNewPortrait').PerformClick()
        $files = @(Get-ChildItem $settings.GamePath -Filter '*.png' -Recurse | Where-Object { $_.Directory.Name -ne 'female' })
        Assert ($files.Count -eq $keys.Count) 'Incorrect exported file count'
        foreach ($key in $keys) {
            $name = if ($game -in 'k','w','r') { @{Lrg='Fulllength';Med='Medium';Sml='Small'}[$key] }
                    else { 'Test_' + @{Lrg='lg';Med='convo';Sml='sm';Sml2='si'}[$key] }
            $out = [Drawing.Bitmap]::new(($files | Where-Object BaseName -eq $name).FullName)
            try {
                $i = 0
                foreach ($fraction in 0.15,0.5,0.85) {
                    $actual = $out.GetPixel([int]($out.Width*$fraction),[int]($out.Height*$fraction))
                    $shown = $samples[$key][$i++]
                    foreach ($channel in 'R','G','B') {
                        Assert ([Math]::Abs($actual.$channel-$shown.$channel) -le 6) "$name preview and export differ"
                    }
                }
            } finally { $out.Dispose() }
        }
    }
} finally {
    $form.Dispose()
    if ([IO.Directory]::Exists($directory)) { [IO.Directory]::Delete($directory,$true) }
}
'Comparison layouts, independent crops, and exported previews passed.'
