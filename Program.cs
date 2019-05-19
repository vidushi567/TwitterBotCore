using System;
using TwitterBotCore.Logging;
using System.Threading;

namespace TwitterBotCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var logger = new Log4NetLogger();

            logger.Log("Starting process..");

            var twitterBot = new TwitterBot();

            var thread = new Thread(new ThreadStart(twitterBot.Start))
            {
                IsBackground = true
            };

            thread.Start();

            thread.Join();
        }
    }
}