function Invoke-PSNode {
    param(
        $script,
        [Switch]$NoConversion
    )

    if(!$env:EDGE_POWERSHELL_NATIVE) {
        $env:EDGE_POWERSHELL_NATIVE = '..\..\src\Edge.PowerShell\Edge.PowerShell\bin\Debug\Edge.PowerShell.dll'
    }

    if($NoConversion) {
        node .\test.js $script
    } else {
        ((node .\test.js $script) -join '' | ConvertFrom-Json ).result
    }
}