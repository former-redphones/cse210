using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

// For managing the clientside connection, *not* interacting with the user!
public class Client
{
    private TcpClient _client;
    private IPAddress _address = IPAddress.Loopback;
    private int _port = 5000;

    public void Connect()
    {
        Connect(_address, _port);
    }

    public void Connect(IPAddress address)
    {
        Connect(address, _port);
    }
    public void Connect(IPAddress address, int port)
    {
        Discconnect();
        _client = new();
        _address = address;
        _port = port;
        _client.Connect(address, port);
    }

    public string SendRequest(Request request)
    {
        string jsonString = JsonSerializer.Serialize(request, request.GetType());
        return SendRequest(jsonString);
    }

    public string SendRequest(string message)
    {
        Stream stream = _client.GetStream();
        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);

        byte[] buffer = new byte[1024];
        try
        {
            int bytes = stream.Read(buffer, 0, buffer.Length);

            if (bytes == 0)
            {
                Console.WriteLine($"Server disconnected: {_address}:{_port}");
                stream.Close();
                return "";
            }

            string response = Encoding.UTF8.GetString(buffer, 0, bytes);
            return response;

        } catch (IOException)
        {
            Console.WriteLine($"Connection lost: {_address}:{_port}");
            stream.Close();
            return "";
        }
    }

    public void Discconnect() {
        try {
            _client.Close();
        } catch (NullReferenceException) { }
    }
}