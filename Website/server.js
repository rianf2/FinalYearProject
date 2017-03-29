'use strict'

var express = require("express");
var app = express();
const PORT = 1337;
var path = require("path");
var mongo = require("mongojs");
var usersDB = mongo("FYP", ["users"]);
var bugsDB = mongo("FYP", ["bugs"]);
var parser = require("body-parser");
//var bcrypt = require("bcrypt");
var md5 = require("md5");
var fs = require("fs");

app.use(express.static(__dirname + "/public"));
app.use(parser.json());
app.use(parser.urlencoded({ extended: true }));
app.use(parser.json({ type: 'application/x-www-form-urlencoded' }));

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
    console.log("Inserting " + req.body.username + " into the database.");

    //req.body.password = encryptPassword(req.body.password);
    //console.log("ENCRYPTED PASSWORD: " + req.body.password);
    usersDB.users.insert(req.body, function(err, doc){
        if(err)
        {
            console.log(err);
        }
        res.json(doc);
    });
});

/*
    For report, username case must match that of whatever was inputted originally,
    better to have it ignore the username case!!!
 */
app.get("/userDetails/:username", function(req, res){
    var username = req.params.username;
    var password = req.params.password;

   console.log("Recieved a GET request for " + username);

   var query = {
                    "username": username
                    //"password": password
               };

    usersDB.users.findOne(query, function(err, docs){
      if(err)
      {
          console.log(err);
      }
        res.json(docs);
   });
});

/*
    For report, originally using req.params.score and not req.body.score, lead to undefined data
    must find out why!!!

    This says post but in reality its a put request
 */
app.post("/userDetails/:username", function(req, res){
    console.log("Updataing details for " + req.body.username);
    console.log("SCORE: " + req.body.score + ", TIME: " +req.body.timePlayed);

    //https://docs.mongodb.com/manual/reference/method/db.collection.findOneAndUpdate/
    usersDB.users.findAndModify({
        query: { username: req.body.username },
        update: { $set: {score: req.body.score, timePlayed: req.body.timePlayed}},
        new: true }, function(err, doc) {
        if(err) { console.log("Error " + err); }
        res.json(doc);
    });
});

app.get('/bugs',function(req,res){
    res.sendFile(path.join(__dirname+'/public/bugs.html'));
});

app.post("/bugReports", function(req, res){
    /*
        Have this output to a log file too for redundancy??
     */
    console.log(req.body);


    bugsDB.bugs.insert(req.body, function(err, doc){
        if(err)
        {
            console.log(err);
        }
        res.json(doc);
    });

    var report = {
                    name: req.body.name,
                    problem: req.body.problem,
                    dateReported: req.body.dateReported
                 };

    fs.appendFile("bugs.json", JSON.stringify(report, null, "\t"), function(err){
        if(err)
        {
            console.log("File I/O error");
        }
    });
});


app.listen(PORT);

console.log();
console.log("Server running since: " + getDate() + " on port: " + PORT);

/*
    Encryption: from bcrypt npm page, using async as it allows server
    to respond to different requests while encrypting details
 */
function encryptPassword(password)
{
    /*const saltRounds = 10;
    
    bcrypt.genSalt(saltRounds, function (err, salt) {
       bcrypt.hash(password, salt, function(err, hash){
           console.log("ENCRYPTED PASSWORD: " + hash);
           //this is where the hash should be returned
           return hash;
       });
    });*/
}

function getDate()
{
    var today = new Date();
    var days = today.getDate();
    var month = today.getMonth() + 1; // Starts at 0
    var year = today.getFullYear();
    var hours = today.getHours();
    var minutes = today.getMinutes();
    var seconds = today.getSeconds();

    if(days < 10) { days = "0" + days; }
    if(month < 10) { month = "0" + month; }
    if(minutes < 10) { minutes = "0" + minutes; }
    if(seconds < 10) { seconds = "0" + seconds; }

    today = days + "/" + month + "/" + year + " " + hours + ":" + minutes + ":" + seconds;
    return today;
}

/*
    DELETE: This will delete a user depending on their id
 */
app.delete("/userDetails/:id", function(req, res){
   var id = req.params.id;
   console.log("Removing user " + id);
   console.log(req.params);

   usersDB.users.remove({ _id: mongo.ObjectId(id) }, function(err, doc){
       res.json(doc);
   });
});