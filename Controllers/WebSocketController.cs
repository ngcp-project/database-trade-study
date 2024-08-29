using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using database_trade_study.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebSocketsSample.Controllers;

public class WebSocketController : ControllerBase
{
    private readonly InfluxDBService _influxDBService;

    //constructor 
    public WebSocketController (InfluxDBService influxDBService){
            this._influxDBService = influxDBService;
    }

    [HttpGet("/socket")]
    public async Task InitializeWebSocket()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket, _influxDBService);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private static async Task Echo(WebSocket webSocket, InfluxDBService influxDBService)
    {
        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);
            
            string rawData = Encoding.UTF8.GetString(buffer).TrimEnd('\0');
             long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            
            MockData data = new MockData("N/A", 0, timestamp);
            try
            {
                data = JsonSerializer.Deserialize<MockData>(rawData) ?? new MockData("N/A", 0, timestamp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Fires Destroyed: " + data.firesDestroyed);
            await influxDBService.WriteDataAsync(data);


            await webSocket.SendAsync(
                new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                receiveResult.MessageType,
                receiveResult.EndOfMessage,
                CancellationToken.None);
            buffer = new byte[1024 * 4];
        }

        await webSocket.CloseAsync(
            receiveResult.CloseStatus.Value,
            receiveResult.CloseStatusDescription,
            CancellationToken.None);
    }
}