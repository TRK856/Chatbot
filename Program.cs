#nullable disable
using System;
using System.Text.Json;
using ConsoleApp;
List<Chatbot> Database = new List<Chatbot>();

// JSON
string jsonCurrentPath = @$"{Directory.GetCurrentDirectory()}/data.json";
Utility.Load("Searching for Data File", 1, 700);

if (File.Exists(jsonCurrentPath))
{
    Database = JsonSerializer.Deserialize<List<Chatbot>>(File.ReadAllText(jsonCurrentPath));
}
else
{
    Utility.Load("No Data File Found, Creating File", 2, 500);
    File.WriteAllText(jsonCurrentPath, JsonSerializer.Serialize(Database));
    Console.Clear();
    Console.WriteLine("By continuing, you understand that the algorithm will not function without Training...Pls go to github and download the pre-rendered data file in order to use the bot immediately");
    Console.WriteLine("\nPRESS ANY KEY TO CONTINUE");
    Console.Write("-> ");
    Console.ReadLine();
}


// New UI (rn UI is super messy, so it needs a reset)

// Current UI 
while (true)
{
    // Main Menu
    Console.Clear();
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
            Console.WriteLine("*NO CHANGES ARE PERMENENT UNLESS SAVED*\n*DATABASE = NON-PERSISTANT STORAGE*\n*LOCAL FILE = PERSISTANT-STORAGE*");
            string[] DataOptions = { "Print All Database", "Manipulate Database", "Reset Database (fetch from local file)", "Save Changes (save to local file)", "Clear Local File", "Return to Main Menu" };
            Utility.CreateMenu(
                "Welcome to the Database Menu!",
                DataOptions
                );
            int DatabaseChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (DatabaseChoice == 1)
            {
                Console.WriteLine($"\nCurrent Database: ");
                Utility.WriteAll(Database);
                Console.WriteLine("\nPRESS ANY KEY TO RETURN BACK TO MAIN MENU");
                Console.Write("-> ");
                Console.ReadLine();
            }
            else if (DatabaseChoice == 2)
            {
                string[] DataMOptions = { "Add to Database", "Remove from Database", "Edit an Existing Catagory", "Erase All of DataBase", "Return to Database Menu" };
                Utility.CreateMenu(
                    "Manipulate Database Menu.",
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
                        Console.Write("Enter a catagory for these phrases: "); string catagory = Console.ReadLine().ToLower().Trim();
                        if (Search.LinearCatagory(Database, catagory) != -1)
                        {
                            Console.Write("Catagory already exsists, please use the edit feature to change what alredy exsists in the database.");
                            Utility.Load("Returning to Database Menu", 1, 900);
                        }
                        Console.Write("Possible User Inputs (seperate responses with a ','): "); List<string> user = Console.ReadLine().Split(',').ToList();
                        Console.Write("Possible Bot Responses (seperate responses with a ','): "); List<string> bot = Console.ReadLine().Split(',').ToList();
                        Database.Add(new Chatbot(catagory, user, bot));
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
                Database = JsonSerializer.Deserialize<List<Chatbot>>(File.ReadAllText(jsonCurrentPath));
                Utility.Load("Fetching", 3, 400);
                Utility.Load("Success, Returning", 1, 600);

            }
            else if (DatabaseChoice == 4)
            {
                File.WriteAllText(jsonCurrentPath, JsonSerializer.Serialize(Database));
                Utility.Load("Writing", 3, 400);
                Utility.Load("Success, Returning", 1, 600);
            }
            else if (DatabaseChoice == 5)
            {
                Database.Clear();
                File.WriteAllText(jsonCurrentPath, JsonSerializer.Serialize(Database));
                Utility.Load("Clearing Local File", 3, 400);
                Utility.Load("Success, Returning", 1, 600);
            }
            else if (DatabaseChoice == 6)
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
        Console.WriteLine("*N/A*\nNotes: UI will get a refresher after i have done the chatbot algorithm");
        Console.WriteLine("\nTest: ");
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