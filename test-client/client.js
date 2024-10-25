import WebSocket from "ws";

const CONNECTION_URL = "ws://localhost:5156/socket";
const HERTZ = 10;
// HERTZ is the "formal" unit that represents updates per second.
// 1 HERTZ = 1 update per second

const webSocket = new WebSocket(CONNECTION_URL);

webSocket.on("error", console.error);

webSocket.on("message", function message(data) {
    console.log("received: %s", data);
});

let sampleData = {
    vehicleName: "FRA",
    firesDestroyed: 0,
};

setInterval(() => {
    sampleData.firesDestroyed++;
    webSocket.send(JSON.stringify(sampleData));
}, (1 / HERTZ) * 1000);
