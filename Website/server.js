var express = require("express");
var app = express();
var port = 1337;
var path = require("path");
var mongo = require("mongojs");
var usersDB = mongo("FYP", ["users"]);
var bugsDB = mongo("FYP", ["bugs"]);
var parser = require("body-parser");
//var bcrypt = require("bcrypt");

app.use(express.static(__dirname + "/public"));
app.use(parser.json());

app.get("/userDetails", function(req, res){
    console.log("GET request for /userDetails");

    usersDB.users.find(function (err, docs) {

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


    usersDB.users.insert(req.body, function(err, doc){
        if(err)
        {
            console.log(err);
        }
        res.json(doc);
    });
});

app.get("/userDetails", function(req, res){
   console.log("GET request for one user");

   var query = {
                    "username": req.user.username,
                    "password": req.user.password
               };

   console.log("Username: " + req.user.username);
   console.log("Password: " + req.user.password);

    usersDB.users.findOne(query, function(err, doc){
      if(err)
      {
          console.log(err);
      }
      res.json(doc);
   });
});

app.put("/userDetails/:id", function(req, res){
    var userID = res.params.id;

    usersDB.users.findAndModify({
        query: {_id: mongo.id.ObjectId(userID)},
        update: {$set: {highscore: res.body.highscore,
                        highestLevel: res.body.highestLevel,
                        timeplayed: res.body.timeplayed}},
        new: true}, function(err, doc){
        res.json(doc);
    });
});

app.get('/bugs',function(req,res){
    res.sendFile(path.join(__dirname+'/public/bugs.html'));
});

app.post("/bugReports", function(req, res){
    console.log(req.body);


    bugsDB.bugs.insert(req.body, function(err, doc){
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