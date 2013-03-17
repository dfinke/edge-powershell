var edge = require('../../lib/edge-powershell.js')
var express = require('express');

var app = express();
var port = process.env.PORT || 8080;

function wrapScript(script) {
	return '.\\' + script + '.ps1';
}
app.get('/powershell/:script', function(req,res) {

	var payload = {
		script: wrapScript(req.params.script),
		parameters: req.query
		//request: req,
		//response: res,
	}
	edge.powerShell(payload, function (error, results) {
		if (error) return console.log(error);
		res.json(results.Result);
	});
});

app.listen(port);
console.log("Server listening on port " + port);
