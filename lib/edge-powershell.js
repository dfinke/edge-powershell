var edge = require('edge');

exports.powerShell = edge.func({
	assemblyFile: process.env.EDGE_POWERSHELL_NATIVE || (__dirname + '\\clr\\Owin.PowerShell.dll'),
	typeName: 'Owin.PS.OwinPowerShell',
	methodName: 'InvokeScript'
});