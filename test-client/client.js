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

let sampleData1 = {
    id: 1,
    vehicleName: "FRA",
    firesDestroyed: 0,
    timestamp: new Date().getTime(),
};

let sampleData2 = {
    id: 2,
    vehicleName: "AWAWA",
    firesDestroyed: 0,
    timestamp: new Date().getTime(),
};

let sampleData3 = {
    id: 3,
    vehicleName: "WOOP DE DOO",
    firesDestroyed: 0,
    timestamp: new Date().getTime(),
};

let totalResponseTime = 0;
let requestCount = 0;

function runSim(sampleData) {
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
                console.log(
                    `Success. Response time: ${responseTime} ms, Average time: ${averageResponseTime.toFixed(
                        2
                    )} ms`
                );
            })
            .catch(function (error) {
                console.log("Error:", error);
            });
    }, (1 / HERTZ) * 1000);
}

runSim(sampleData1);
runSim(sampleData2);
runSim(sampleData3);
