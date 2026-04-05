using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

public class Server
{
    private TcpListener _listener;

    public async void StartListenting(int port = 5000)
    {
        _listener = new TcpListener(IPAddress.Any, port);
        _listener.Start();
        Console.Clear();
        Console.WriteLine($"Listening on port {port}");
        Console.WriteLine("Press enter to quit at any time");

        while (true)
        {
            TcpClient client = await _listener.AcceptTcpClientAsync();
            Console.WriteLine($"Connected to {client.Client.RemoteEndPoint}");
             _ = Task.Run(() => HandleClient(client));
        }
    }

    private async void HandleClient(TcpClient client)
    {
        string name = "";
        Dictionary<string, Request> requestInstances = new();
        while (true) {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            try
            {
                int bytes = stream.Read(buffer, 0, buffer.Length);

                if (bytes == 0)
                {
                    Console.WriteLine($"Client disconnected: {client.Client.RemoteEndPoint}");
                    client.Dispose();
                    stream.Close();
                    return;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, bytes);
                string response = "";
                try
                {
                    Console.WriteLine("attempting");
                    JsonObject request = JsonSerializer.Deserialize<JsonObject>(message);
                    string type = (string)request["Type"].AsValue();
                    Console.WriteLine("deserialized");

                    // parse structured request
                    Console.WriteLine($"{request["Type"]}");
                    Request handler;

                    handler = type switch
                    {
                        SimpleMessage.RequestName => request.Deserialize<SimpleMessage>(),
                        Counter.RequestName => request.Deserialize<Counter>(),
                        Ping.RequestName => request.Deserialize<Ping>(),
                        PlaySound.RequestName => request.Deserialize<PlaySound>(),
                        Exponent.RequestName => request.Deserialize<Exponent>(),
                        _ => throw new JsonException("Invalid type")
                    };

                    if (requestInstances.TryGetValue(type, out var existing)) {
                        Console.WriteLine("Found");
                        
                        using var doc = JsonDocument.Parse(request.ToJsonString());

                        foreach (var prop in doc.RootElement.EnumerateObject())
                        {
                            var propertyInfo = handler.GetType().GetProperty(prop.Name);
                            if (propertyInfo == null) continue;
                            if (!propertyInfo.CanWrite) continue;

                            var value = prop.Value.Deserialize(propertyInfo.PropertyType);
                            Console.WriteLine($"{propertyInfo}, {value}");
                            propertyInfo.SetValue(existing, value);
                        }
                        handler = existing;
                    }

                    // call request
                    Console.WriteLine(handler?.GetType());
                    response = handler.HandleRequest();

                    byte[] data = Encoding.UTF8.GetBytes(response);
                    stream.Write(data, 0, data.Length);

                    // update instance list
                    if (requestInstances.ContainsKey(type)) {
                        requestInstances[type] = handler;
                    } else
                    {
                        requestInstances.Add(type, handler);
                    }
                }
                catch (Exception ex) when (ex is JsonException || ex is NullReferenceException)
                {
                    // Console.WriteLine(ex);
                    // treat message as plain text
                    if (name != "")
                    {
                        Console.Write($"{name}: {message}");
                    } else
                    {
                        Console.Write(message);
                    }

                    if (!message.EndsWith("\n"))
                    {
                        Console.WriteLine();
                    }
                    
                    byte[] data = Encoding.UTF8.GetBytes($"Invalid JSON: {message}\n");
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (IOException)
            {
                Console.WriteLine($"Connection lost: {client.Client.RemoteEndPoint}");
                client.Dispose();
                stream.Close();
                return;
            }
        }
    }
}