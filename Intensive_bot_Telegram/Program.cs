using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace Intensive_bot_Telegram
{
    class Program
    {
        static List<string> CreateAnswers (string userInput, Dictionary<string,string> answersOnQuestions)
        {
            var answers = new List<string>();
            foreach (var Entry in answersOnQuestions)
            {
                if (userInput.Contains(Entry.Key))
                {
                    answers.Add(Entry.Value);
                }
            }
            return answers;
        }

        static bool ShoulExit (string userInput)
        {
            if (userInput.Contains("buy"))
            {
                Console.WriteLine("See you later");
                return true;
            }
            else
                return false;
        }

        static void KnowTime (List<string> answers)
        {
            Console.WriteLine(">>Bot: Date or hour?");
            Console.Write(">>user: ");
            var userInput = Console.ReadLine().ToLower();
            if (userInput.Contains("date"))
            {
                var timeDate =DateTime.Now.ToString("dd.MM.yy");
                answers.Add(timeDate);
            }
            else
            {
                var timeHour = DateTime.Now.ToString("HH.mm.ss");
                answers.Add(timeHour);
            } 
        }

        static string BotWork (Dictionary<string,string> answersOnQuestions)
        {
            var stop = false;
            Console.WriteLine(">>Bot: Hello, My name is IVT-19-1, i'm can tell you our timetable, time or hometask");
            var finalAnswer = "";
            while (!stop)
            {
                Console.Write(">>user: ");
                var userInput = Console.ReadLine().ToLower();
                var answers = CreateAnswers(userInput, answersOnQuestions);
                if (userInput.Contains("what time"))
                    KnowTime(answers);
                finalAnswer = String.Join(", ", answers);
                stop = ShoulExit(userInput);
            }
            return finalAnswer;
        }

        static void Main()
        {
            var api = new TelegramAPI();
            api.sendMessagw("Hello", 912669501);
            var data = File.ReadAllText(@"C:\Users\molch\Desktop\синх2019\С#\остальное\Intensive_bot_Telegram\answers.json");
            var answersOnQuestions = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            var finalAnswer = BotWork(answersOnQuestions);
            Console.WriteLine($">>Bot: {finalAnswer}");
            
            while (true)
            {
                var updates = api.getUpdates();
                foreach(var update in updates)
                {
                    var answer = answersOnQuestions();
                    
                }
            } 
        }
    }
}
