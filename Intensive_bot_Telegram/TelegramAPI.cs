using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Intensive_bot_Telegram
{
    class TelegramAPI
    {
        public class ApiResult
        {
            public Update[] result { get; set; }
        }

        public class Update
        {
            public int update_id { get; set; };
            public Message message { get; set; };
        }

        public class Message
        {
            public Chat chat { get; set; }
            public string text { get; set; }
        }

        public class Chat
        {
            public int id { get; set; }
            public string first_name { get; set; }
        }

        const string API_URL = @"https://api.telegram.org/bot" + Secretkey.apiKey + "/";

        RestClient RC = new RestClient();

        public void sendMessagw (string text, int chatId)
        {
            sendApiRequest("sendMessage", $"chat_id{chatId}&text{text}");
        }

        public void getUpdates ()
        {
           var json = sendApiRequest("getUpdates", "");
            var apiResult = JsonConvert.DeserializeObject<ApiResult>(json);
                foreach (var update in apiResult.result)
            {
                //Console.WriteLine($"Получаен апдейт {update.update_id}," +
                //    $"Сообщение ot {update.message.chat.first_name}," +
                //    $"текст {update.message.text}");
            }

        }

        public string sendApiRequest(string apiMethod, string arguments)
        {
            var url = API_URL + "?" + arguments;
            var request = new RestRequest(url);
            var Response = RC.Get(request);
            return Response.Content;
        }
    }
}
