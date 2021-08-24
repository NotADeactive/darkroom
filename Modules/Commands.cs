using System.Data;
using System.Threading.Tasks;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Server;

namespace Template.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private readonly ILogger<Commands> _logger;

        public Commands(ILogger<Commands> logger)
            => _logger = logger;

        [Command("ping")]
        public async Task PingAsync()
        {
            await ReplyAsync($"Pong! {this.Context.Client.Latency}ms");
            
        }

        [Command("echo")]
        public async Task EchoAsync([Remainder] string text)
        {
            await ReplyAsync(text);
            _logger.LogInformation($"{Context.User.Username} executed the echo command!");
        }

        [Command("math")]
        public async Task MathAsync([Remainder] string math)
        {
            var dt = new DataTable();
            var result = dt.Compute(math, null);
            
            await ReplyAsync($"Result: {result}");
            _logger.LogInformation($"{Context.User.Username} executed the math command!");
        }

        [Command("salavat")]
        public async Task saLAVAT()
        {

            var builder = new EmbedBuilder()
                .WithTitle("ٱللَّٰهُمَّ صَلِّ عَلَىٰ مُحَمَّدٍ وَآلِ مُحَمَّدٍ")
            .AddField("<:doggoPray:808278008224808970> ", "May the God bless you with this sa**lavat**")
                .WithColor(new Color(18, 166, 58));
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed, options: new RequestOptions()
            {



            });
            _logger.LogInformation($"{Context.User.Username} executed the saLavat command!");
        }
        [Command("PressF")]
        public async Task F()
        {
            //var builder = new EmbedBuilder()
            //    .WithTitle($"Ping : {C}");

            await ReplyAsync("<a:PressF:811135779040264192> \n  F  F  F  F  F  F F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F  F ");
        
        }
        [Command("kir")]
        public async Task dick()
        {
            var builder = new EmbedBuilder()
                .WithDescription("Even with these glasses, I can't see what you are talking about. <:WutCat:858459979068997663>")
                .WithImageUrl("https://media.discordapp.net/attachments/584427761074962476/858449799798849586/image.png");
            var embed = builder.Build();
            await ReplyAsync(null, false, embed);
            //($"Even with these glasses, I can't see what you are talking about. <:WutCat:858459979068997663>"+ glasses );
            //"https://media.discordapp.net/attachments/584427761074962476/858449799798849586/image.png");
       
        }

        [Command("kos")]
        [Alias("kobs")]
        public async Task kobs()
        {
            var builder = new EmbedBuilder()
                .WithColor(new Color(235, 14, 14))
                .WithImageUrl("https://media.discordapp.net/attachments/620166723273752607/830504826076659752/imageonline-co-textimage.png?width=562&height=473")
                .WithAuthor("YouTube" + "\n" + "How to get KOBS")
                .WithUrl("https://www.youtube.com/watch?v=dQw4w9WgXcQ")
                .WithTitle("dakhel in video be shoma amoozesh dade mishe chetori kobs begirid ! :flushed:");
            var embed = builder.Build();
            await ReplyAsync(null, false, embed);

        }
        #region info

        [Command("pfp")]
        public async Task Profile_picture(SocketGuildUser user = null)
        {

            if (user == null)
            {


                var builder = new EmbedBuilder()
                    .WithAuthor($"{Context.User.Username}")
                    .WithTitle("Profile Picture :small_blue_diamond: ")
                    .WithUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                   .WithImageUrl(Context.User.GetAvatarUrl().ToString() ?? Context.User.GetDefaultAvatarUrl())
                    .WithFooter("Frida | PFP")
                    .WithColor(new Color(155, 89, 182));
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);

                //ImageFormat format = Auto, ushort size = 128
            }
            else
            {


                var builder = new EmbedBuilder()
                    .WithAuthor($"{user.Username}")
                    .WithTitle("Profile Picture :small_blue_diamond: ")
                    .WithUrl(user.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithImageUrl(user.GetAvatarUrl().ToString() ?? Context.User.GetDefaultAvatarUrl().ToString())
                    .WithFooter("Frida | PFP")
                    .WithColor(new Color(155, 89, 182));
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);

            }
        }


        [Command("user-info")]

        public async Task userinfo(SocketGuildUser user = null)
        {
            if (user == null)
            {
                var builder = new EmbedBuilder()
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .AddField("Username", Context.User.Username, true)
                    .AddField("Member Role Amount", string.Join("", (Context.User as SocketGuildUser).Roles.Count), true)
                    .AddField("Roles", string.Join("", (Context.User as SocketGuildUser).Roles.Select(x => x.Mention)))
                   .AddField("Member Joined", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("MM/dd/yyyy"), true)
                   .AddField("Created At", Context.User.CreatedAt.ToString("MM/dd/yyyy"), true)
                   .AddField("User ID", Context.User.Id)
                    .WithColor(new Color(155, 89, 182));
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else
            {
                var builder = new EmbedBuilder()
                   .WithThumbnailUrl(user.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                   .AddField("Username", user.Username, true)
                   .AddField("Member Role Amount", string.Join("", user.Roles.Count), true)
                   .AddField("Roles", string.Join("", user.Roles.Select(x => x.Mention)))
                  .AddField("Member Joined", user.JoinedAt.Value.ToString("MM/dd/yyyy"), true)
                  .AddField("Created At", user.CreatedAt.ToString("MM/dd/yyyy"), true)
                  .AddField("User ID", user.Id)
                   .WithColor(new Color(155, 89, 182));
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);

            }
            _logger.LogInformation($"{Context.User.Username} executed the info command!");

        }
        [Command("server-info")]
        public async Task serverinfo()
        {

            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.Guild.IconUrl)
                .AddField("Server Name", Context.Guild.Name, true)
                .AddField("Total Member Count", string.Join("", (Context.Guild as SocketGuild).MemberCount), true)
                .AddField("Emoji Count", string.Join("", (Context.Guild as SocketGuild).Emotes.Count), true)
                .AddField("Creation Date", ($"{Context.Guild.CreatedAt.DayOfWeek}" + $"  {Context.Guild.CreatedAt.UtcDateTime} (UTC Time)" + $"  {Context.Guild.CreatedAt.LocalDateTime}(Iran Standard Time)"))
                .AddField("Channels Count", Context.Guild.Channels.Count)
                .AddField("Region", Context.Guild.VoiceRegionId)
                //  .AddField("Server Boost Tier", Context.Guild.PremiumTier)
                .WithColor(new Color(155, 89, 182));
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
            _logger.LogInformation($"{Context.User.Username} executed the server info command!");
        }

        ///here's some information that may help you how to behave with Frida
        ///it's not compeleted yet
        ///wait till the END
        /// :)))
        //[Command("help")]
        //public async Task help()
        //{
        //    await ReplyAsync("");
        //}
        #endregion


    }
}