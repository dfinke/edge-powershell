var owin = require('owin');

exports.powerShell = owin.func({
	assemblyFile: process.env.OWIN_POWERSHELL_NATIVE || (__dirname + '\\clr\\Owin.PowerShell.dll'),
	typeName: 'Owin.PS.OwinPowerShell',
	methodName: 'InvokeScript'
});