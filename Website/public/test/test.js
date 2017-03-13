var server = require("./server.js");

describe("server", function(){
    it("should listen on port 1337", function(){
        server.listen(1337);
    });
});