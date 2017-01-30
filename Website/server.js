var express = require("express");
var app = express();
var port = 1337;
var mongo = require("mongojs");
var db = mongo("FYP", ["users"]);
var parser = require("body-parser");
//var bcrypt = require("bcrypt");

app.use(express.static(__dirname + "/public"));
app.use(parser.json());

app.get("/userDetails", function(req, res){
    console.log("GET request for /userDetails");

   db.users.find(function (err, docs) {

       if(err)
       {
           console.log(err);
       }

       console.log(docs);
       res.json(docs);
   });
});

app.post("/userDetails", function(req, res){
    console.log(req.body);


    db.users.insert(req.body, function(err, doc){
        if(err)
        {
            console.log(err);
        }
        res.json(doc);
    });
});

app.post("/login", function(req, res){
   console.log("GET request for one user");

   var query = {
                    "username": req.user.username,
                    "password": req.user.password
               };

   console.log("Username: " + req.user.username);
   console.log("Password: " + req.user.password);

   db.users.findOne(query, function(err, doc){
      if(err)
      {
          console.log(err);
      }
      res.json(doc);
   });
});

app.listen(port);

console.log();
console.log("Server runnning on port " + port);