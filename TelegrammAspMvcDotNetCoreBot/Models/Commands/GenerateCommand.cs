using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegrammAspMvcDotNetCoreBot.Models.Commands
{
    public class GenerateCommand : Command
    {
        public override string Name => @"/generate";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.TextMessage)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            string url = "https://evilinsult.com/generate_insult.php?lang=en&type=json";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            InsultInfo insultInfo = JsonConvert.DeserializeObject<InsultInfo>(response);
            await client.SendTextMessageAsync(chatId, insultInfo.Insult, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
