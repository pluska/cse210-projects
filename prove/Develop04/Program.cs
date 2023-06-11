using System;

class Program
{
    static void Main(string[] args)
    {
        bool runningProgram = true;
        string menu = "Menu Options:\n" +
        "  1. Start breating activity\n" +
        "  2. Start reflectiong activity\n" +
        "  3. Start listing activity\n" +
        "  4. Quit\n" +
        "Select a choice from the menu: ";
        void displayMenu()
        {
            Console.Clear();
            Console.WriteLine(menu);
        }

        while (runningProgram)
        {
            displayMenu();
            string option = Console.ReadLine();
            BreathingActivity breathingActivity = new BreathingActivity();
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            ListingActivity listingActivity = new ListingActivity();
            switch (option)
            {
                case "1":
                    breathingActivity.breathingActivityWorkflow();
                    break;
                case "2":
                    reflectingActivity.reflectingActivityWorkflow();
                    break;
                case "3":
                    listingActivity.listingActivityWorkflow();
                    break;
                case "4":
                    runningProgram = false;
                    break;
                default:
                    Console.WriteLine("/nInvalid option.");
                    Console.Clear();
                break;
            }
        }

    }
}