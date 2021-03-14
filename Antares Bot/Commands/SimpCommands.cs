using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antares_Bot
{
    public class SimpCommands : ModuleBase<SocketCommandContext>
    {
        [Command("starless")]
        public async Task StarlessCommand() {
            await ReplyAsync("Starless is the cutest and sweetest stag ever <3");
        }
        [Command("cocaine")]
        public async Task CocaineCommand()
        {
            await ReplyAsync("Praise the Omnissiah!!!");
        }
        [Command("skye")]
        public async Task SkyeCommand() {
            Emote skyeHug = Emote.Parse("<:skyeStarlessHug:813449589897297920>");
            await ReplyAsync(@$"Skye is the cutest woofie >w< {skyeHug}");
        }
        [Command("ping")]
        public async Task PingCommand()
        {
            await ReplyAsync($"Pong {Context.Message.Author.Username} <@{Context.Message.Author.Id}>");
        }
        [Command("weeb")]
        public async Task WeebCommand()
        {
            if (Context.Message.Author.Username.Contains("Starless")) {
                await ReplyAsync($"{Context.Message.Author.Username} is 100% weeb");
            } else {
                Random rand = new Random();
                int randomPercent = rand.Next(0, 100);
                await ReplyAsync($"{Context.Message.Author.Username} is {randomPercent}% weeb");
            }
        }
        [Command("silksong")]
        public async Task SilksongCommand() {
            await ReplyAsync("https://www.youtube.com/watch?v=ib5AfwGmnZE");
        }

        [Command("cute")]
        public async Task CuteCommand() {
            Random rand = new Random();
            int randomN = rand.Next(1000, 100000);
            /*if (Context.Message.Author.Username.Contains("Skye") || Context.Message.Author.Username.Contains("Zeno")) {
                await ReplyAsync($"{Context.Message.Author.Username} is ∞% cute!");
            }*/
            await ReplyAsync($"{Context.Message.Author.Username} is {randomN}% cute!");
            
        }
        [Command("rapax")]
        public async Task RapaxCommand() {
            await ReplyAsync("Cute translator foxy friend ^^");
        }
        [Command("say")]
        public async Task SayCommand([Remainder] string message) {
            
            await ReplyAsync(message);
            await Context.Message.DeleteAsync();
        }
        [Command("pat")]
        public async Task PatCommand()
        {
            string message = "";
            Random rand = new Random();
            int temp = rand.Next(1, 30);
            for (int i = 0; i < temp; i++) {
                message = message + "pat" + " ";
            }
            await ReplyAsync(message);
        }
        [Command("shark")]
        public async Task SharkCommand()
        {
            await ReplyAsync("Definitely not a furry :wink: ");
        }
        [Command("fiz")]
        public async Task FizCommand() {
            await ReplyAsync(":wolf: Awesome wolf homie! ^^");
        }
        [Command("pyru")]
        public async Task PyruCommand() {
            await ReplyAsync("Smart French gamer friend hon hon hon ^^");
        }
        [Command("aurora")]
        public async Task AuroraCommand() {
            await ReplyAsync("Cute Belgian friend who loves psychology :3");
        }
        [Command("mere")]
        public async Task MereCommand() {
            await ReplyAsync("One of the smartest, kindest, friendliest and cutest people in the world >w<");
        }
        [Command("antares")]
        public async Task AntaresCommand() {
            await ReplyAsync("Dumbass doe who created this bot");
        }
    }
}
