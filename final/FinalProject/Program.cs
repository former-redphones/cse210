using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using NAudio.Wave;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("s/c: ");
        string input = Console.ReadLine();
        if (input == "s") {
            Server server = new Server();

            server.StartListenting();
            Console.ReadLine();
        } else if (input == "c")
        {
            Console.Write("Enter address:port (leave blank for default): ");
            Client client = new Client();
            string address = Console.ReadLine();
            string[] split = address.Split(":");
            try {
                if (split.Length == 2)
                {
                    client.Connect(IPAddress.Parse(split[0]), int.Parse(split[1]));
                } else if (split.Length == 1)
                {
                    client.Connect(IPAddress.Parse(split[0]));
                } else
                {
                    throw new FormatException();
                }
            } catch (FormatException)
            {
                Console.WriteLine("Using default");
                client.Connect();
            }
            MainClientLoop(client);

            await Task.Delay(1000);
            Request message = new PlaySound()
            {
                sound = "beep.wav"
            };
            client.SendRequest(message);

            // Ping ping = new Ping();
            // Console.WriteLine(ping.Sent.ToBinary());
            // string newtime = client.SendRequest(ping);
            // // DateTime.FromBinary(long.Parse(newtime));
            // TimeSpan pingTime = DateTime.FromBinary(long.Parse(newtime)).Subtract(DateTime.Now);
            // Console.WriteLine(pingTime.Milliseconds);

            // while (input != "quit")
            // {
            //     Console.Write("-->| ");
            //     input = Console.ReadLine();
            //     if (input == "reconnect")
            //     {
            //         client.Connect();
            //     } else if (input == "disconnect")
            //     {
            //         client.Discconnect();
            //     } else if (input != "quit")
            //     {
            //         client.SendRequest(input);
            //     }
            // }
        }

        // messageless test-json results in last message being echoed

    }

    public static void MainClientLoop(Client client)
    {
        int input;
        do
        {
            Console.WriteLine("\t1. Send Ping");
            Console.WriteLine("\t2. Increment Counter");
            Console.WriteLine("\t3. Send Simple Message");
            Console.WriteLine("\t4. Send plaintext (debug)");
            Console.WriteLine("\t5. Send PlaySound Reqeust");
            Console.WriteLine("");
            Console.WriteLine("\t6. Reconnect");
            Console.WriteLine("\t0. Disconnect");
            Console.Write("Select a choice from the menu: ");
            input = int.TryParse(Console.ReadLine(), out input) ? input : -1; // Default to -1 if non-integer input
            string response = null;
            switch (input)
            {
                case 1:
                    response = client.SendRequest(new Ping());
                    response = DateTime.FromBinary(long.Parse(response)).Subtract(DateTime.Now).Milliseconds.ToString() + " ms";
                    break;

                case 2:
                    response = client.SendRequest(new Counter());
                    break;
                    
                case 3:
                    Console.Write("Message: ");
                    response = client.SendRequest(new SimpleMessage()
                    {
                        _message = Console.ReadLine()
                    });
                    break;

                case 4:
                    Console.Write("Plaintext: ");
                    response = client.SendRequest(Console.ReadLine());
                    break;

                case 5:
                    Console.Write("Sound: ");
                    response = client.SendRequest(new PlaySound()
                    {
                        sound = Console.ReadLine()
                    });
                    break;
                
                case 6:
                    client.Connect();
                    Console.WriteLine("Reconnected");
                    break;
                
                case 0:
                    client.Discconnect();
                    Console.WriteLine("Disconnected");
                    break;

                default:
                    Console.WriteLine("That is not a valid menu option!");
                    continue;
            }

            if (response != null)
            {
                Console.WriteLine($"Server Response: {response}");
            }

        } while (input != 0);
    }
}

/* TODO
~~~~~~~~~~~
fix test-json bug
add menu/ui for making valid requests (include plaintext send option)
add 3 more request types? (math operation, play a sound on the server machine, latency ping)
figure out client handling better than just printing to console
*/

// https://app.smartdraw.com/editor.aspx?templateId=3f94c5ba-46fb-46ac-80e2-8b13581b08db