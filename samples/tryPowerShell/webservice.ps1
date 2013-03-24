param($weight, $from, $to)

$obj = New-WebServiceProxy http://www.webservicex.net/ConvertWeight.asmx
$obj.ConvertWeight($weight, $from, $to)