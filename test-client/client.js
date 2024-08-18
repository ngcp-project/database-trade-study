import WebSocket from "ws";
import axios from "axios";

const CONNECTION_URL = "ws://localhost:5156/socket";
const ENDPOINT = "http://localhost:5156";
const HERTZ = 1;
// HERTZ is the "formal" unit that represents updates per second.
// 1 HERTZ = 1 update per second

const webSocket = new WebSocket(CONNECTION_URL);

webSocket.on("error", console.error);

webSocket.on("message", function message(data) {
    console.log("received: %s", data);
});

let sampleData = {
    id: 1,
    vehicleName: "FRA",
    firesDestroyed: 0,
    timestamp: new Date().getTime(),
};

let totalResponseTime = 0;
let requestCount = 0;

setInterval(() => {
    sampleData.id++;
    sampleData.firesDestroyed++;
    sampleData.timestamp = new Date().getTime();
    webSocket.send(JSON.stringify(sampleData));

    const startTime = new Date().getTime();

    axios
        .post(`${ENDPOINT}/telemetry`, sampleData)
        .then(function (response) {
            const endTime = new Date().getTime();
            const responseTime = endTime - startTime;

            totalResponseTime += responseTime;
            requestCount++;

            const averageResponseTime = totalResponseTime / requestCount;
            console.log(`Success. Response time: ${responseTime} ms, Average time: ${averageResponseTime.toFixed(2)} ms`);
        })
        .catch(function (error) {
            console.log("Error:", error);
        });

}, (1 / HERTZ) * 1000);
