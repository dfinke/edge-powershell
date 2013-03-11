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

Use JavaScript and act on the results from PowerShell
===
Here you pass in the range *_1..5_* to PowerShell, it returns a json array. You can then use *_forEach_* on it and print it.

```
var owin = require('../../lib/owin-powershell.js')

var script = "1..5";

powerShell(script, function (error, result) {
    if (error) throw error;

    result.forEach(function(item) {
        console.log(item*2);
    });
});
```

Run it

```
node .\testMultiply.js

2
4
6
8
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

## Displays the correct string output
But requires the Out-String. Plus, it would be prefered to get the powershell objects back to the pipeline.

```
node .\test.js 'Get-Process | where handles -gt 700 | Out-string' | ConvertFrom-Json

Handles  NPM(K)    PM(K)      WS(K) VM(M)   CPU(s)     Id ProcessName
-------  ------    -----      ----- -----   ------     -- -----------
   1444      86    94812     126244   425    11.45   2840 chrome
   1249      91    61316      10832   444   563.16   3988 communicator
   2282     155    74328     128816   707    64.66   2376 explorer
    944      80   151224     174228   596    20.98   3176 GitHub
    913      47    17488      10736  1063     5.27   4768 LiveComm
   1064      25     7316      11280    53    18.95    580 lsass
    712      69    36620      37120   613    96.81   3400 SearchIndexer
    717      35   109616      96392   172   984.39    340 svchost
    940      47    22804      28088  1482    57.84    408 svchost
    833      32    19624      21568   110    19.61    884 svchost
   1924      65   207928      47048   404    90.20    952 svchost
    820      37    13784      17988   115     8.63    984 svchost
    848       0      168      19284    29 1,232.98      4 System
    774      26    15920      15368   109     4.78   5024 wmpnetwk
```
