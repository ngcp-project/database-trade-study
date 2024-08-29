import WebSocket from "ws";

const CONNECTION_URL = "ws://localhost:5156/socket";
const HERTZ = 1; // 1 update per second

const webSocket = new WebSocket(CONNECTION_URL);

let messageCount = 0;
let startTime = Date.now();

webSocket.on("error", console.error);

webSocket.on("message", function message(data) {
    console.log("received: %s", data);
    const receivedData = JSON.parse(data);
    const sendTime = receivedData.timeStamp;
    const receiveTime = Date.now();
    console.log("Round-trip time: " + (receiveTime - sendTime) + " ms");
    messageCount++;
});

// Log the number of updates per second
setInterval(() => {
    const currentTime = Date.now();
    const elapsedTime = (currentTime - startTime) / 1000; // Convert to seconds
    const updatesPerSecond = messageCount / elapsedTime;
    console.log(`Updates per second: ${updatesPerSecond.toFixed(2)}`);
    messageCount = 0;
    startTime = Date.now();
},  1000); // Every second

let sampleData = {
    vehicleName: "FRA",
    firesDestroyed: 0,
    timeStamp: Date.now()
};


//test 1
setInterval(() => {
    
    sampleData.firesDestroyed++;
    sampleData.timeStamp = Date.now(); // Update timestamp before sending
    webSocket.send(JSON.stringify(sampleData));
    
}, (1 / HERTZ) * 1000); // 1000 milliseconds = 1 second


//send the data in json format by converting the sampleData Object into JSONu 