namespace Algorithm
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

    // picked the best search idk if i use it tho
    public class Search
    {
        public static int linear(int[] anArray, int item)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                if (anArray[i] == item)
                {
                    return i;
                }
            }

            // Went through for loop without finding item, so...
            return -1;
        }

        // string linear search
        public static int linear(string[] anArray, string item)
        {
            for (int i = 0; i < anArray.Length; i++)
            {
                if (anArray[i] == item)
                {
                    return i;
                }
            }

            // Went through for loop without finding item, so...
            return -1;
        }

    }

    // picked the best sort idk if i use it tho
    public class Sort
    {
        static public void insertion(int[] anArray)
        {
            for (int i = 1; i < anArray.Length; i++)
            {
                int insertPos = i;
                int insertValue = anArray[i];

                while (insertPos > 0 && anArray[insertPos - 1] > insertValue)
                {
                    anArray[insertPos] = anArray[insertPos - 1];
                    insertPos--;
                }

                anArray[insertPos] = insertValue;
            }
        }

        static public void insertion(string[] anArray)
        {
            for (int i = 1; i < anArray.Length; i++)
            {
                int insertPos = i;
                string insertValue = anArray[i];

                while (insertPos > 0 && String.Compare(anArray[insertPos - 1], insertValue) > 0)
                {
                    anArray[insertPos] = anArray[insertPos - 1];
                    insertPos--;
                }

                anArray[insertPos] = insertValue;
            }
        }
    }

    // just to help make life a lil easier
    public class Utility
    {
        static public void writeAll(int[] anArray)
        {
            Console.Write("[");
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                Console.Write($"{anArray[i]}, ");
            }
            Console.WriteLine($"{anArray[anArray.Length - 1]}]");
        }

        static public void writeAll(string[] anArray)
        {
            Console.Write("[");
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                Console.Write($"{anArray[i]}, ");
            }
            Console.WriteLine($"{anArray[anArray.Length - 1]}]");
        }
        static public void writeAll(List<Chatbot> anArray)
        {
            Console.WriteLine("[");
            for (int i = 0; i < anArray.Count - 1; i++)
            {
                Utility.tab(1);
                Console.WriteLine("{");
                Utility.tab(2);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"UserInput: {anArray[i].userInput},");
                Utility.tab(2);
                Console.WriteLine($"BotResponse: {anArray[i].botResponse}");
                Console.ForegroundColor = GlobalVar.DefaultColorForeground;
                Utility.tab(1);
                Console.WriteLine("}, ");
            }
            Utility.tab(1);
            Console.WriteLine("{");
            Utility.tab(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"UserInput: {anArray[anArray.Count - 1].userInput},");
            Utility.tab(2);
            Console.WriteLine($"BotResponse: {anArray[anArray.Count - 1].botResponse}");
            Console.ForegroundColor = GlobalVar.DefaultColorForeground;
            Utility.tab(1);
            Console.WriteLine("}");
            Console.WriteLine("]");
        }

        static public void swap(int[] anArray, int pos1, int pos2)
        {
            int swap = anArray[pos1];
            anArray[pos1] = anArray[pos2];
            anArray[pos2] = swap;
        }

        static public void swap(string[] anArray, int pos1, int pos2)
        {
            string swap = anArray[pos1];
            anArray[pos1] = anArray[pos2];
            anArray[pos2] = swap;
        }

        static public void tab(int numOfTab)
        {
            for (int i = 0; i < numOfTab; i++)
            {
                Console.Write("      ");
            }
        }
        static public void load(string message, int animationRepition, int animationLength)
        {
            for (int i = 0; i < animationRepition; i++)
            {
                Console.Clear();
                Console.WriteLine($"{message}.");
                Thread.Sleep(animationLength);
                Console.Clear();
                Console.WriteLine($"{message}..");
                Thread.Sleep(animationLength);
                Console.Clear();
                Console.WriteLine($"{message}...");
                Thread.Sleep(animationLength);
            }
        }
    }
}