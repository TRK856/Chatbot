#nullable disable
using System;
using System.Text.Json;
using ConsoleApp;
List<Chatbot> ChatbotData = new List<Chatbot>();

// JSON
string jsonCurrentPath = @$"{Directory.GetCurrentDirectory()}/data.json";

if (File.Exists(jsonCurrentPath))
{
    string jsonStringFromFile = File.ReadAllText(jsonCurrentPath);
    ChatbotData = JsonSerializer.Deserialize<List<Chatbot>>(jsonStringFromFile);
}
else
{
    Console.WriteLine("No JSON File Found, are you sure you want to Countiue?");
}


// UI
while (true)
{
    // Main Menu
    Console.Clear();
    Console.WriteLine("");
    string[] MainMenuOptions = { "Talk to the Bot", "Edit Database", "Request Version", "Exit Main Menu" };
    Utility.CreateMenu(
        "Welcome to the Main Menu for the chat bot. You can play test the bot or train the bot to your liking...Enjoy!",
        MainMenuOptions
        );
    int MainMenuChoice = Convert.ToInt32(Console.ReadLine());
    Utility.Load("Loading Data", 1, 900);
    Console.Clear();
    Utility.Load("Opening", 1, 300);
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
            Console.WriteLine("*NO CHANGES ARE PERMENENT UNLESS SAVED*");
            string[] DataOptions = { "Print All Database", "Manipulate Database", "Reset Database (fetch from local file)", "Save Changes (save to local file)", "Return to Main Menu" };
            Utility.CreateMenu(
                "Welcome to the Database Menu!",
                DataOptions
                );
            int DatabaseChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (DatabaseChoice == 1)
            {
                Console.WriteLine($"\nCurrent Database: ");
                Utility.WriteAll(ChatbotData);
                Console.WriteLine("\nPRESS ANY KEY TO RETURN BACK TO MAIN MENU");
                Console.Write("-> ");
                Console.ReadLine();
            }
            else if (DatabaseChoice == 2)
            {

                Console.WriteLine("Manipulate Database.\n      1. Add to Database\n      2. Remove from Database\n      3. Erase All of DataBase\n      4. Return to Database Menu");
                string[] DataMOptions = { "Add to Database", "Remove from Database", "Erase All of DataBase", "Return to Database Menu" };
                Utility.CreateMenu(
                    "Manipulate Database.",
                    DataMOptions
                    );
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
                        Console.WriteLine("\nReturn to Database Menu? Y -or- N");
                        Console.Write("-> ");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            break;
                        }
                    }
                }
            }
            else if (DatabaseChoice == 3)
            {
                string jsonStringFromFile = File.ReadAllText(jsonCurrentPath);
                ChatbotData = JsonSerializer.Deserialize<List<Chatbot>>(jsonStringFromFile);
            }
            else if (DatabaseChoice == 4)
            {
                string jsonString = JsonSerializer.Serialize(ChatbotData);
                File.WriteAllText(jsonCurrentPath, jsonString);
            }
            else if (DatabaseChoice == 5)
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
        Console.WriteLine("Thank You~ Have a Good Day!");
        break;
    }

    Utility.Load("Returning", 1, 900);
}