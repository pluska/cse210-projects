using System;

class Program
{
    /* I have exceeded the requirements for this program adding the following:
     * 1. Setting the user levels
     * 2. Setting a bonus when the user completed all goals
     * 3. Setting a way to delete goals
     * 4. Setting a way to delete goals completed
     */
    static void Main(string[] args)
    {
        List<string> menus = new List<string>();
        menus.Add("Menu Options:\n" + "1. Create New Goal\n" + "2. List Goals\n"+ "3. Save Goals\n" + "4. Load Goals\n" + "5. Record Event\n"+ "6. Delete Goals Completed\n" + "7. Delete Goal\n"  + "8. Quit Program");
        menus.Add("1. Simple Goal\n" + "2. Eternal Goal\n" + "3. Checklist Goal\n");
        MenuManager menuManager = new MenuManager(menus);
        GoalsManager goalsManager = new GoalsManager();
        while (menuManager.GetKeepRunning())
        {
            Console.Clear();
            goalsManager.GetUserGoalsStatus();
            Console.WriteLine($"You are a {goalsManager.GetUserLevel()} (You have {goalsManager.GetUserPoints()} points).\n");
            menuManager.DisplayMenu(0);
            Console.WriteLine("Please select an option from the menu:");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("types of goal are:");
                    menuManager.DisplayMenu(1);
                    Console.WriteLine("Which type of goal would you like to create?");
                    string goalType = Console.ReadLine();
                    goalsManager.SetUserGoal(goalType);
                    break;
                case "2":
                    Console.WriteLine(goalsManager.DisplayUserGoals());
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                case "3":
                    goalsManager.SaveGoals();
                    break;
                case "4":
                    goalsManager.LoadGoals();
                    break;
                case "5":
                    goalsManager.RecordEvent();
                    break;
                case "6":
                    goalsManager.ClearGoalsCompleted();
                    break;
                case "7":
                    goalsManager.DeleteGoal();
                    break;
                case "8":
                    menuManager.QuitProgram();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}