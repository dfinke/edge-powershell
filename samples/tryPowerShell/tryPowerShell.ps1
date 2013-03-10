
param($number=10)

filter sqr {$_*$_}

1..$number |
    where {$_ % 2 -eq 0} |
    sqr