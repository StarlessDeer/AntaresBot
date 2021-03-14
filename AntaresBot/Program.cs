using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace Antares_Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(() => new Program().RunBot().GetAwaiter().GetResult());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        public async Task RunBot()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            _client.Log += Client_Log;
            // Bot Authentification init
            RegisterCommandsAsync();
            //var token = File.ReadAllText("TOKEN.txt");
            var token = Environment.GetEnvironmentVariable("TOKEN");
            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

            await Task.Delay(-1);
        }

        private void RegisterCommandsAsync()
        {
            MessageAddedHandler messageAddedHandler = new MessageAddedHandler(_client, _commands, _services);
            _client.MessageReceived += messageAddedHandler.HandleCommandAsync;
        }

        private Task Client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
    }
}
