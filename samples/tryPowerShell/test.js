var edge = require('../../lib/edge-powershell.js')

var script = process.argv.splice(2)[0] || "'Hello World'";

edge.powerShell(script, function (error, result) {
    if (error) throw error;
    console.log(result);
});
