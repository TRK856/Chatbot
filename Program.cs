#nullable disable
using System;
using System.Text.Json;
using Algorithm;
List<Chatbot> ChatbotData = new List<Chatbot>();

while (true)
{
    // Main Menu
    Console.Clear();
    Console.WriteLine("Welcome to the Main Menu for the chat bot. You can play test the bot or train the bot to your liking...Enjoy!\n      1. Talk to the Bot\n      2. Edit Database\n      3. Request Version\n      4. Exit Main Menu");
    Console.Write("-> "); int MainMenuChoice = Convert.ToInt32(Console.ReadLine());
    Utility.load("Loading Data", 1, 900);
    Console.Clear();
    Utility.load("Opening", 1, 300);
    Console.Clear();

    // Does Action according to choice
    if (MainMenuChoice == 1)
    {
        Chat.Create();
        // actual chat
        while (true)
        {
            Console.Write("[default.jpg] You > "); string mssg = Console.ReadLine();
            if (mssg != "done")
            {
                Chat.BotReply("Hi!");
            }
            else
            {
                break;
            }
        }

    }
    else if (MainMenuChoice == 2)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("*THERE IS NO DATABASE RIGHT NOW, EVERYHTING WILL ONLY BE SAVED WHILE THE BOT IS IN USE*");
            Console.WriteLine("Welcome to the Database Menu!\n      1. Print All Database\n      2. Manipulate Database\n      3. Erase DataBase\n      4. Return to Main Menu");
            Console.Write("-> ");
            int DatabaseChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (DatabaseChoice == 1)
            {
                Console.WriteLine($"\nCurrent Database: ");
                Utility.writeAll(ChatbotData);
                Console.WriteLine("\nPRESS ANY KEY TO RETURN BACK TO DATABASE MENU");
                Console.Write("-> ");
                Console.ReadLine();
            }
            else if (DatabaseChoice == 2)
            {
                Console.WriteLine("Manipulate Database.\n      1. Add to Database\n      2. Remove from Database\n      3. Return to Database Menu");
                Console.Write("-> ");
                int DatabaseMChoice = Convert.ToInt32(Console.ReadLine());
                if (DatabaseMChoice == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        // Possible future implementaion
                        Console.WriteLine("ADD TO DATABASE");
                        Console.Write("User Input: "); string user = Console.ReadLine();
                        Console.Write("Bot Response: "); string bot = Console.ReadLine();
                        ChatbotData.Add(new Chatbot(user, bot));
                        Console.WriteLine("\nAdd More? Y -or- N");
                        Console.Write("-> ");
                        if (Console.ReadLine().ToLower() != "y")
                        {
                            break;
                        }
                    }
                }
                else if (DatabaseMChoice == 3)
                {

                }

            }
            else if (DatabaseChoice == 3)
            {
                ChatbotData.Clear();
            }
            else if (DatabaseChoice == 4)
            {
                break;
            }
        }
    }
    else if (MainMenuChoice == 3)
    {
        // this is for testing
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Version: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("*N/A*\nNotes: Just to let you know, I used this version section for testing : )");
        Console.WriteLine("Test: ");
        Console.WriteLine("\nPRESS ANY KEY TO RETURN BACK TO MAIN MENU");
        Console.Write("-> ");
        Console.ReadLine();
    }
    else if (MainMenuChoice == 4)
    {
        // this is for testing
        Console.WriteLine("Thank You: Have a Good Day!");
        break;
    }

    Utility.load("Returning", 1, 900);
}