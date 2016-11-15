var express = require("express");
var app = express();
var port = 1337;

app.use(express.static(__dirname + "/public"));

app.listen(port);

console.log();
console.log("Server runnning on port " + port);
console.log("Press CTRL + C to shutdown.");
console.log("Have a nice day :)");