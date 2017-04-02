var assert = require("assert");
var http = require("http");

describe("/", function(){
    it("homepage should return 200", function(done){
        http.get("http://localhost:1337", function(res){
            assert.equal(200, res.statusCode);
            done();
        });
    });
});

describe("/userDetails", function(){
    it("/userDetails should return 200", function(done){
        http.get("http://localhost:1337/userDetails", function(res){
            assert.equal(200, res.statusCode);
            done();
        });
    });
});

describe("/userDetails/RianF2", function(){
    it("/userDetails/RianF2 should return 200", function(done){
        http.get("http://localhost:1337/userDetails/RianF2", function(res){
            assert.equal(200, res.statusCode);
            done();
        });
    });
});

describe("/userDetails/kanye", function(){
    it("/userDetails/kanye should return 200", function(done){
        http.get("http://localhost:1337/userDetails/kanye", function(res){
            assert.equal(200, res.statusCode);
            done();
        });
    });

    it("but should return null when kanye is requested", function(done){
        http.get("http://localhost:1337/userDetails/kanye", function(res){
            var data;

            res.on("data", function(chunk){
               data += chunk;
            });

            res.on("end", function(){
                assert.equal(null, data);
                done();
            });
        });
    });
});