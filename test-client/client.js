import WebSocket from "ws";

const CONNECTION_URL = "ws://localhost:5156/socket";
const HERTZ = 1;
// HERTZ is the "formal" unit that represents updates per second.
// 1 HERTZ = 1 update per second

const webSocket = new WebSocket(CONNECTION_URL);

webSocket.on("error", console.error);

webSocket.on("message", function message(data) {
    console.log("received: %s", data);
});

webSocket.on("open", () => {
    setInterval(() => {
        sampleData.firesDestroyed++;
        const startTime = performance.now();
        webSocket.send(JSON.stringify(sampleData));
        webSocket.once("message", (response) => {
            const endTime = performance.now();
            const elapsedTime = endTime - startTime;
            console.log(`Received time ${elapsedTime}`);
        });
    });
});

let sampleData = {
    vehicleName: "FRA",
    firesDestroyed: 0,
};

setInterval(() => {
    sampleData.firesDestroyed++;
    webSocket.send(JSON.stringify(sampleData));
}, (1 / HERTZ) * 1000);
