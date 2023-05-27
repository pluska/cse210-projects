using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Alma 32:21", "And now as I said concerning faith—faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.");
        bool continueProgram = true;
        do {
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
                Console.WriteLine("Invalid input");
                continue;
            }
            scripture.SetHiddenWords();
        } while (continueProgram);
    }
}