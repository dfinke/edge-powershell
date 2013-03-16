var edge = require('edge');

exports.powerShell = edge.func({
	assemblyFile: process.env.EDGE_POWERSHELL_NATIVE || (__dirname + '\\clr\\Edge.PowerShell.dll'),
	typeName: 'Edge.PS.EdgePowerShell',
	methodName: 'InvokeScript'
});