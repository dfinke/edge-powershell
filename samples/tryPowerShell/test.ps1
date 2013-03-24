param($min=1,$max=20)

#[System.Console]::WriteLine($min)
#[System.Console]::WriteLine($max)

$min..$max | ? {$_ % 2 -eq 0} | % {$_*$_}