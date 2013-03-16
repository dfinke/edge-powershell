function Invoke-PSNode {
    param($script)

    if(!$env:EDGE_POWERSHELL_NATIVE) {
        $env:EDGE_POWERSHELL_NATIVE = '..\..\src\Edge.PowerShell\Edge.PowerShell\bin\Debug\Edge.PowerShell.dll'
    }

    ((node .\test.js $script) -join '' | ConvertFrom-Json ).result
}