// idk what to name this but its useful stuff
namespace ConsoleApp
{
    // picked the best search idk if i use it tho
    public class Search
    {
        public static int LinearCatagory(List<Chatbot> aList, string catagory)
        {
            for (int i = 0; i < aList.Count; i++)
            {
                if (aList[i].catagory == catagory)
                {
                    return i;
                }
            }

            // Went through for loop without finding item, so...
            return -1;
        }

        // string linear search
        public static int LinearUserInput(List<Chatbot> aList, string inputToSearch)
        {
            for (int i = 0; i < aList.Count; i++)
            {
                for (int f = 0; f < aList[i].userInputs.Count; f++)
                {
                    if (aList[i].userInputs[f].ToLower() == inputToSearch.ToLower())
                    {
                        return i;
                    }
                }
            }

            // Went through for loop without finding item, so...
            return -1;
        }
    }

    // picked the best sort idk if i use it tho
    public class Sort
    {
        static public void Insertion(int[] anArray)
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

        static public void Insertion(string[] anArray)
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
        static public void WriteAll(int[] anArray)
        {
            Console.Write("[");
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                Console.Write($"{anArray[i]}, ");
            }
            Console.WriteLine($"{anArray[anArray.Length - 1]}]");
        }

        static public void WriteAll(string[] anArray)
        {
            Console.Write("[");
            for (int i = 0; i < anArray.Length - 1; i++)
            {
                Console.Write($"{anArray[i]}, ");
            }
            Console.WriteLine($"{anArray[anArray.Length - 1]}]");
        }

        static public void WriteAll(List<Chatbot> aList)
        {
            Console.WriteLine("[");
            for (int i = 0; i < aList.Count; i++)
            {
                Utility.Tab(1);
                Console.WriteLine("{");
                Console.ForegroundColor = ConsoleColor.Blue;
                Utility.Tab(2);
                Console.WriteLine($"'Catagory': '{aList[i].catagory}',");
                Utility.Tab(2);
                Console.WriteLine("'UserInputs':");
                Utility.Tab(3);
                Console.WriteLine("{");
                for (int f = 0; f < aList[i].userInputs.Count; f++)
                {
                    Utility.Tab(4);
                    Console.Write($"'{aList[i].userInputs[f]}'");
                    if (f != aList[i].userInputs.Count - 1)
                    {
                        Console.WriteLine(",");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
                Utility.Tab(3);
                Console.WriteLine("},");
                Utility.Tab(2);
                Console.WriteLine("'BotRespnses':");
                Utility.Tab(3);
                Console.WriteLine("{");
                for (int j = 0; j < aList[i].botResponses.Count; j++)
                {
                    Utility.Tab(4);
                    Console.Write($"'{aList[i].botResponses[j]}'");
                    if (j != aList[i].botResponses.Count - 1)
                    {
                        Console.WriteLine(",");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
                Utility.Tab(3);
                Console.WriteLine("}");
                Console.ForegroundColor = GlobalVar.DefaultColorForeground;
                Utility.Tab(1);
                if (i == aList.Count - 1)
                {
                    Console.WriteLine("}");
                }
                else
                {
                    Console.WriteLine("},");
                }
            }
            Console.WriteLine("]");
        }

        static public void Swap(int[] anArray, int pos1, int pos2)
        {
            int swap = anArray[pos1];
            anArray[pos1] = anArray[pos2];
            anArray[pos2] = swap;
        }

        static public void Swap(string[] anArray, int pos1, int pos2)
        {
            string swap = anArray[pos1];
            anArray[pos1] = anArray[pos2];
            anArray[pos2] = swap;
        }

        static public void Tab(int numOfTab)
        {
            for (int i = 0; i < numOfTab; i++)
            {
                Console.Write("      ");
            }
        }

        static public void Load(string message, int animationRepition, int animationLength)
        {
            for (int i = 0; i < animationRepition; i++)
            {
                Console.Clear();
                Console.Write($"{message}.");
                Thread.Sleep(animationLength);
                Console.Write(".");
                Thread.Sleep(animationLength);
                Console.Write(".");
                Thread.Sleep(animationLength);
            }
        }

        static public void CreateMenu(string menuIntro, string[] options)
        {
            Console.WriteLine($"{menuIntro}");
            for (int i = 0; i < options.Length; i++)
            {
                Utility.Tab(1);
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.Write("-> ");
        }
    }
}
