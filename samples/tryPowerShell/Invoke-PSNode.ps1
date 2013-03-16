function Invoke-PSNode {
    param($script)

    if(!$env:OWIN_POWERSHELL_NATIVE) {
        $env:OWIN_POWERSHELL_NATIVE = '..\..\src\Owin.PowerShell\Owin.PowerShell\bin\Debug\Owin.PowerShell.dll'
    }

    ((node .\test.js $script) -join '' | ConvertFrom-Json ).result
}