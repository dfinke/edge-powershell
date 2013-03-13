function Invoke-PSNode {
    param($script)

    ((node .\test.js $script) -join '' | ConvertFrom-Json ).result
}