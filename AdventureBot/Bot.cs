using AdventureBot.Commands;
using AdventureBot.Models;
using Guilded;
using Guilded.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Websocket.Client;

namespace AdventureBot
{
    public class Bot
    {
        private static readonly string? json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json"));
        private static readonly string? token = JsonSerializer.Deserialize<ConfigJson>(json!)!.Token!;
        private static readonly string? prefix = JsonSerializer.Deserialize<ConfigJson>(json!)!.Prefix!;
        private static readonly string? timePattern = "hh:mm:ss tt";

        public async Task RunAsync()
        {
            await using var client = new GuildedBotClient(token!)
                .AddCommands(new MemberCommands(), prefix!)
                .AddCommands(new MemberCommands(), prefix!);


            client.Prepared
                    .Subscribe(me =>
                    {
                        var time = DateTime.Now.ToString(timePattern);
                        var date = DateTime.Now.ToShortDateString();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"[{date}][{time}][INFO]  [{me.ParentClient.Name}] connecting to gateway...");
                        Console.ResetColor();
                    });

            client.Disconnected
                .Where(e => e.Type != DisconnectionType.NoMessageReceived)
                .Subscribe(me =>
                {
                    var time = DateTime.Now.ToString(timePattern);
                    var date = DateTime.Now.ToShortDateString();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"[{date}][{time}][ERROR] [{client.Name}] disconnected from gateway...");
                    Console.ResetColor();
                });

            client.Reconnected
                .Where(x => x.Type != ReconnectionType.Initial)
                .Where(x => x.Type != ReconnectionType.NoMessageReceived)
                .Subscribe(me =>
                {

                    var time = DateTime.Now.ToString(timePattern);
                    var date = DateTime.Now.ToShortDateString();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] reconnected to gateway...");
                    Console.ResetColor();

                });


            await client.ConnectAsync();
            await client.SetStatusAsync("adventuring", 90002579);
            var time = DateTime.Now.ToString(timePattern);
            var date = DateTime.Now.ToShortDateString();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] connected...");
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] registering command modules...");
            await Task.Delay(200);
            Console.WriteLine($"[{date}][{time}][INFO]  [{client.Name}] listening for events...");
            await Task.Delay(-1);
        }
    }
}
