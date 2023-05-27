using System;

class Program
{
    static void Main(string[] args)
    {
        // Exceeding Requirements
        // Create a new class called ScripturesStore that has the following properties:
        //      a. A private List<Scripture> property called _scriptures
        //      b. A private string property called _filePath
        //      c. A public List<Scripture> method called GetScriptures() that returns the _scriptures property
        //      d. A public Scripture method called GetScripture(int index) that returns the scripture at the given index
        //      e. A public Scripture method called GetRandomScripture() that returns a random scripture from the _scriptures property
        //      f. A public void method called DisplayScriptures() that displays all the scriptures in the _scriptures property
        //      g. A public constructor that takes no parameters and does the following:
        //          i. Sets the _filePath property to "./scriptures.txt"
        //          ii. Initializes the _scriptures property to a new List<Scripture>
        //          iii. Reads all the lines from the file at the _filePath property
        //          iv. For each line in the file, splits the line by the "|" character and creates a new Scripture object with the parts
        //          v. Adds the new Scripture object to the _scriptures property
        //      h. A public constructor that takes a string parameter called filePath and does the following:
        //          i. Sets the _filePath property to the filePath parameter
        //          ii. Initializes the _scriptures property to a new List<Scripture>
        //          iii. Reads all the lines from the file at the _filePath property
        //          iv. For each line in the file, splits the line by the "|" character and creates a new Scripture object with the parts
        //          v. Adds the new Scripture object to the _scriptures property
        ScripturesStore scripturesStore = new ScripturesStore();
        List<Scripture> scriptures = scripturesStore.GetScriptures();
        Scripture scripture = scripturesStore.GetRandomScripture();
        bool continueProgram = false;
        int scriptureIndex = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorizer! \n");
            Console.WriteLine("Select a scripture to memorize: \n");
            for (int i = 0; i < scriptures.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetReference()}");
            }
            Console.WriteLine("\nType the number of the scripture you would like to memorize or type 'Random' and the program will select the scripture: ");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "random")
            {
                continueProgram = true;
                break;
            } else if (userInput == "" || userInput.GetType() != typeof(int))
            {
                continue;
            } else
            {
                scriptureIndex = int.Parse(userInput);
                if (scriptureIndex > scriptures.Count() || scriptureIndex < 1)
                {
                    continue;
                } else
                {
                    scripture = scriptures[scriptureIndex - 1];
                    continueProgram = true;
                }
            }
        } while (!continueProgram);
        continueProgram = true;
        do {
            Console.Clear();
            continueProgram = !scripture.IsCompleteHidden();
            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine("Press enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input == "quit")
            {
                continueProgram = false;
                break;
            } else if (input != "")
            {
                continue;
            }
            scripture.SetHiddenWords();
        } while (continueProgram);
    }
}