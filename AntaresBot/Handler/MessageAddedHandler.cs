using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antares_bot_uwu
{
    class MessageAddedHandler
    {
        public MessageAddedHandler(DiscordSocketClient _client, CommandService _commands, IServiceProvider _services)
        {
            this._client = _client;
            this._commands = _commands;
            this._services = _services;
        }

        private readonly DiscordSocketClient _client;
        private readonly CommandService _commands;
        private readonly IServiceProvider _services;
        // Handle each message recieved into the right command (if it exists)
        public async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            // command prompt
            int argPos = 0;
            if (message.HasStringPrefix("%", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
