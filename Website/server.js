'use strict'

var express = require("express");
var app = express();
var port = 1337;
var path = require("path");
var mongo = require("mongojs");
var usersDB = mongo("FYP", ["users"]);
var bugsDB = mongo("FYP", ["bugs"]);
var parser = require("body-parser");
var bcrypt = require("bcrypt");

app.use(express.static(__dirname + "/public"));
app.use(parser.json());

app.get("/userDetails", function(req, res){
    console.log("GET request for /userDetails");

    usersDB.users.find(function (err, docs) {

       if(err)
       {
           console.log(err);
       }
       res.json(docs);
   });
});

app.post("/userDetails", function(req, res){
    console.log("INSERTING A USER TO THE DATABASE.");

    req.body.password = encryptPassword(req.body.password);
    usersDB.users.insert(req.body, function(err, doc){
        if(err)
        {
            console.log(err);
        }
        res.json(doc);
    });
});

app.get("/userDetails/:username", function(req, res){
   console.log("GET request for one user");

   var username = req.params.username;
   var password = req.params.password;

   var query = {
                    "username": username
                    //"password": password
               };

   console.log(query.username);
    usersDB.users.findOne(query, function(err, docs){
      if(err)
      {
          console.log(err);
      }

      if(docs.password == password)
      {
          console.log(password);
          res.json(docs);
      }
        res.json(docs);
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

/*
    Encryption: First: reverse the string
                Second: loop through string and convert unicode
                    character to hex character
                Third: return encrypted string
 */
function encryptPassword(password)
{
    var encryptedPassword = "";
    password.split("").reverse().join("");

    for(var i = 0;i < password.length;i++)
    {
        encryptedPassword += password.charCodeAt(i).toString(16);
    }

    return encryptedPassword;
}