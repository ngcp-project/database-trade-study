using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Cassandra.Mapping;
using database_trade_study.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebSocketsSample.Controllers;

public class WebSocketController : ControllerBase
{
    private static double timeAverage = 0;
    private static int count = 0;
    [HttpGet("/socket")]
    public async Task InitializeWebSocket()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            await Echo(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    private static async Task Echo(WebSocket webSocket)
    {

        IMapper dbConnection = DBController.Instance();

        var buffer = new byte[1024 * 4];
        var receiveResult = await webSocket.ReceiveAsync(
            new ArraySegment<byte>(buffer), CancellationToken.None);

        while (!receiveResult.CloseStatus.HasValue)
        {
            receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            string rawData = Encoding.UTF8.GetString(buffer).TrimEnd('\0');

            MockData data = new MockData("N/A", 0);
            try
            {
                data = JsonSerializer.Deserialize<MockData>(rawData) ?? new MockData("N/A", 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Fires Destroyed: " + data.firesDestroyed);
            DateTime start = DateTime.Now;
            await dbConnection.InsertAsync(data);
            DateTime end = DateTime.Now;
            timeAverage = (timeAverage * count + (end - start).TotalMilliseconds) / (count + 1);
            count++;
            Console.WriteLine("Average time: " + timeAverage);


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