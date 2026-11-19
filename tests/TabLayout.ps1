# Run with Windows PowerShell after building the solution.
param([ValidateSet('Debug', 'Release')][string]$Configuration = 'Release')
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Windows.Forms
$exe = Join-Path $PSScriptRoot "..\bin\$Configuration\Portrait Manager.exe"
$assembly = [Reflection.Assembly]::LoadFrom((Resolve-Path $exe).Path)
$formType = $assembly.GetType('PortraitManager.MainForm')
$instance = [Reflection.BindingFlags]'NonPublic,Instance'
$gameField = $formType.GetField('_gameSelected', [Reflection.BindingFlags]'NonPublic,Static')
$settings = $assembly.GetType('PortraitManager.Properties.CoreSettings').GetProperty('Default').GetValue($null)
$settings.GameType = [char]'-'
$settings.GamePath = ''
$settings.WindowWidth = 750

function Select-Control($name) {
    $formType.GetMethod($name + '_Click', $instance).Invoke($form, @($null, [EventArgs]::Empty))
}

function Test-TabJoin($tab, $content) {
    foreach ($width in 750, 1050, 1350, 900) {
        $form.ClientSize = [Drawing.Size]::new($width, $width * 52 / 75)
        [Windows.Forms.Application]::DoEvents()
        $bottom = $tab.PointToScreen([Drawing.Point]::new(0, $tab.Height))
        $top = $content.PointToScreen([Drawing.Point]::Empty)
        if ($bottom.Y -ne $top.Y -or !$tab.Parent.ClientRectangle.Contains($tab.Bounds)) {
            throw "$language/$game at $($form.ClientSize): $($tab.Name) ends at $($bottom.Y), panel starts at $($top.Y)."
        }
    }
}

foreach ($language in 'e', 'd', 'r') {
    $settings.Language = [char]$language
    $form = [Activator]::CreateInstance($formType)
    try {
        $form.ShowInTaskbar = $false
        $form.Opacity = 0
        $form.Show()
        foreach ($game in 'k', 'w', 'r', 'p', 'd', 't', 'l') {
            $gameField.SetValue($null, [char]$game)
            Select-Control 'LabelCreatePortrait'
            foreach ($slot in 'Large', 'Medium', 'Small', 'Sml2') {
                $tab = $formType.GetField('LabelKingCreatePortrait' + $slot, $instance).GetValue($form)
                if (!$tab.Visible) { continue }
                Select-Control $tab.Name
                Test-TabJoin $tab ($formType.GetField('LayoutKingPortraitGroup' + $slot, $instance).GetValue($form))
            }
            Select-Control 'LabelBrowse'
            $gallery = $formType.GetField('PanelGalleryContainer', $instance).GetValue($form)
            $tabs = $formType.GetField('flowLayoutPanelGalleryTabs', $instance).GetValue($form)
            foreach ($tab in $tabs.Controls) {
                if (!$tab.Visible) { continue }
                Select-Control $tab.Name
                Test-TabJoin $tab $gallery
            }
        }
    }
    finally { $form.Dispose() }
}
'Crop and gallery tab layout checks passed.'
