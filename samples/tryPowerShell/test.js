var owin = require('../../lib/owin-powershell.js')

//powerShell('. C:\OwinPowerShell\samples\helloWorld\test.ps1', function (error, result) {
//powerShell('function test {"hello"};test', function (error, result) {
//powerShell('1..10|?{$_ % 2 -eq 0}| % {$_*2}', function (error, result) {
//powerShell('@{a=1;b="a";c=1,2,3;d=3.134;e=[math]::cos(2)}', function (error, result) {
//powerShell('[pscustomobject]@{a=1;b="a";c=1,2,3;d=3.134;e=[math]::cos(2)}', function (error, result) {
//powerShell('Get-Service', function (error, result) {
//powerShell('ps | select name, company', function (error, result) {
//powerShell('function test($p) {&$p}; test {[Math]::Cos(1+1)}', function (error, result) {

// var script = '1..3 | ForEach { "hello world $_" }';

//var script = "'hello world'";
var script = process.argv.splice(2)[0] || "'Hello World'";

owin.powerShell(script, function (error, result) {
    if (error) throw error;
    console.log(result);
});
