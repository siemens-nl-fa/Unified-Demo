'use strict';

console.log('Start client');

var net = require('net');
var exec = require('child_process').exec;

const PIPE_PATH = "\\\\.\\pipe\\HmiRuntime";

let client = net.connect(PIPE_PATH, function () {
    console.log('Client: on connection');
    
    client.write('SubscribeTagValue PC_ProgramToStart\n');
});

client.on('data', function (data) {
    let strdata = data.toString();
    var tokens = strdata.split(/[\s,]+/);
    var cmd = tokens.shift();
    if ('NotifySubscribeTagValue' == cmd){
        var tagName = tokens.shift();
        var quality = tokens.shift();
        var value=tokens.join(' ');
		console.log(strdata);
        console.log("\ntagName: " + tagName + "\ntagValue: " + value + "\nQuality: " + quality);
       }
       if('ErrorNotifyTagValue'==cmd){   
            console.log(strdata);
       }
       if('ErrorSubscribeTagValue'==cmd){
        console.log(strdata);
       }
	   
	   if (value) {
			exec('"' + value + '"', function callback(error, stdout, stderr){
				console.log(error);
			});
	   }
});

client.on('end', function () {
    console.log('on end');
});

client.on('error', function (err) {
    console.log('connection error: ' + err);
});
