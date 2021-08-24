using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Template.Modules
{
    public class Fun : ModuleBase
    {

        private readonly ILogger<Fun> _logger;

        public Fun (ILogger<Fun> logger)
            => _logger = logger;

        #region reddit
        [Command("meme")]
        [Alias("reddit")]
        public async Task Meme(string subreddit = null)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://reddit.com/r/{subreddit ?? "memes"}/random.json?limit=1");
            if (!result.StartsWith("["))
            {
                await Context.Channel.SendMessageAsync(" This subreddit doesnt exixt, bro <:BotWut:851605135918104586> ");
                return;
            }
            JArray arr = JArray.Parse(result);

            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
            .WithColor(new Color(255, 69, 0))
            .WithTitle(post["title"].ToString())
            .WithUrl("https://reddit.com" + post["permalink"].ToString())
            .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}");
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);


        }

        [Command("aww")]

        public async Task aww(string subreddit = null)
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://reddit.com/r/aww/random.json?limit=1");

            JArray arr = JArray.Parse(result);

            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
            .WithColor(new Color(255, 69, 0))
            .WithTitle(post["title"].ToString())
            .WithUrl("https://reddit.com" + post["permalink"].ToString())
            .WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}");
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);


        }

        [Command("thighs")]

        public async Task Ort()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://www.reddit.com/r/animelegwear/random.json?limit=1");

            JArray arr = JArray.Parse(result);

            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
            .WithColor(new Color(255, 69, 0))
            .WithTitle(post["title"].ToString())
            .WithUrl("https://reddit.com" + post["permalink"].ToString());
            //.WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}");
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);


        }

        [Command("ecchi")]
        public async Task WaifuOrt()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"https://www.reddit.com/r/WaifusOnCouch/random.json?limit=1");

            JArray arr = JArray.Parse(result);

            JObject post = JObject.Parse(arr[0]["data"]["children"][0]["data"].ToString());

            var builder = new EmbedBuilder()
                .WithImageUrl(post["url"].ToString())
            .WithColor(new Color(255, 69, 0))
            .WithTitle(post["title"].ToString())
            .WithUrl("https://reddit.com" + post["permalink"].ToString());
            //.WithFooter($"🗨️ {post["num_comments"]} ⬆️ {post["ups"]}");
            var embed = builder.Build();

            await Context.Channel.SendMessageAsync(null, false, embed);
        }


        #endregion


    }
}
