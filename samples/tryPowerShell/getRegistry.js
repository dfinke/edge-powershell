var edge = require('../../lib/edge-powershell.js')

function getRegistryInfo(path, property) {
	return {
		script: "GetRegistry",
		parameters: {
			path: path,
			property: property
		}
	};
}

var path = '"HKLM:\\SOFTWARE\\Microsoft\\Windows Search"';
var property = 'ierss';

edge.powerShell(getRegistryInfo(path, property), function (error, results) {

    if (error) throw error;
    console.log(results);
});
