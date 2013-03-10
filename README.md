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
Build the VS solution src\Owin.PowerShell\Owin.PowerShell.sln
From the directory owin-powershell\samples\tryPowerShell, set this variable in PowerShell

```
$env:OWIN_POWERSHELL_NATIVE='..\..\src\Owin.PowerShell\Owin.PowerShell\bin\Debug\Owin.PowerShell.dll'
```

Then from owin-powershell\samples\tryPowerShell

```
node .\test.js

[ 'Hello World' ]
```
