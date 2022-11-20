using ConsoleApp;
using System.Text.RegularExpressions;

namespace Algorithms
{
    public class Chat
    {
        public static void Create()
        {
            // Intial chat setup
            Console.Write("[cat.jpg] Chat Bot | ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("● ");
            Console.ForegroundColor = GlobalVar.DefaultColorForeground;
            Console.WriteLine("Online");
            Console.WriteLine("--------------------------");
            Console.WriteLine("History will be erased after conversation is over.");
            Console.WriteLine("--------------------------\n");
        }

        public static void BotReply(string whatToSay)
        {
            // Bot Text
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[cat.jpg] Chat Bot > {whatToSay}");
            Console.ForegroundColor = GlobalVar.DefaultColorForeground;
        }
    }

    public class Algorithm
    {
        public static void Run(string userInput, List<Chatbot> aList)
        {
            Random rnd = new Random();
            int indexOfInput = Search.LinearUserInput(
                aList,
                Regex.Replace(userInput, @"[^a-zA-Z ]+", "")
            );
            if (indexOfInput != -1)
            {
                Chat.BotReply(
                    aList[indexOfInput].botResponses[
                        rnd.Next(0, aList[indexOfInput].botResponses.Count)
                    ]
                );
            }
            else
            {
                List<string> splitInput = new List<string>();
                splitInput = Regex.Replace(userInput, @"[^a-zA-Z ]+", "@#o;").Split("@#o;").ToList();

                for (int i = 0; i < splitInput.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(splitInput[i]))
                    {
                        splitInput.RemoveAt(i);
                    }
                }
                for (int i = 0; i < splitInput.Count; i++)
                {
                    indexOfInput = Search.LinearUserInput(aList, splitInput[i].Trim());
                    if (indexOfInput != -1)
                    {
                        Chat.BotReply(
                            aList[indexOfInput].botResponses[
                                rnd.Next(0, aList[indexOfInput].botResponses.Count)
                            ]
                        );
                    }
                    else
                    {
                        Chat.BotReply($"ERROR - {splitInput[i]} --- Bot Not trained to handle exception");
                    }
                }
            }
        }
    }
}
