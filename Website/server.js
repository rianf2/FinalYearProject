var express = require("express");
var app = express();
var port = 1337;
var mongo = require("mongojs");
var db = mongo("FYP", ["users"]);
var parser = require("body-parser");

app.use(express.static(__dirname + "/public"));
app.use(parser.json());

app.get("/userDetails", function(req, res){
   console.log("I GOT A GET REQUEST");

   db.users.find(function (err, docs) {
       console.log(docs);
       res.json(docs);
   });
});

app.listen(port);

console.log();
console.log("Server runnning on port " + port);