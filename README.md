Run Powershell in node.js
===============

Owin allows you to run .NET and node.js code in one process. You can call .NET functions from node.js and node.js functions from .NET. Owin takes care of marshaling data between CLR and V8. Owin also reconciles threading models of single threaded V8 and multi-threaded CLR.

owin-powerShell
===============
Is an experiment to execute PowerShell scripts from a node.js app.


How
===
Install node.js
From the owin-powershell directory, run:
```
npm install
```
Build the VS solution 
```
src\Owin.PowerShell\Owin.PowerShell.sln
```
From the directory owin-powershell\samples\tryPowerShell, set this variable in PowerShell

```
$env:OWIN_POWERSHELL_NATIVE='..\..\src\Owin.PowerShell\Owin.PowerShell\bin\Debug\Owin.PowerShell.dll'
```

Then from owin-powershell\samples\tryPowerShell

```
node .\test.js

[ 'Hello World' ]
```

Other examples
===
The results returned are json
```
node .\test.js 1..10
[ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ]
```

```
node .\test.js 1..10 | ConvertFrom-Json
1
2
3
4
5
6
7
8
9
10
```

Know issues
===
I'm still working on marshaling the data from PowerShell back to nodejs. PowerShell and the JavaScript serialization are not playing well.
So, the following will not produce the correct results.
```
node .\test.js Get-Process
```

```
node .\test.js 'Get-Process'
```

# Displays the correct string output
```
node .\test.js 'Get-Process| Out-String' | ConvertFrom-Json
```
