#dir | select Mode, LastWriteTime, Length, Name | convertto-json
#ps

#@{Name='John'; Age=10;dir=ls|select name}
#[pscustomobject] @{
#    Name = 'John'
#    Age = 10
#} #| Out-String # ConvertTo-Json
#'Test'


dir | % {
    @{
        Mode = $_.Mode
        LastWriteTime=$_.LastWriteTime
        Length=$_.Length
        Name=$_.Name
    }
} |  out-string