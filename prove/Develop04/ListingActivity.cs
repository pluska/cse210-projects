using System;

public class ListingActivity : Activity
  {
    private List<string> _listingPrompts;

    private string displayRandomPromt()
    {
      Random random = new Random();
    int randomNumber = random.Next(0, _listingPrompts.Count());
    return _listingPrompts[randomNumber];
    }

    public void listingActivityWorkflow()
    {
      Console.WriteLine(startingMsg());
      int duration = (Convert.ToInt32(Console.ReadLine()));
      Console.Clear();
      Console.WriteLine("Get ready...");
      spinnerPause();
      Console.WriteLine("\nList as many repsonses you can to the following prompt:");
      Console.WriteLine($" --- {displayRandomPromt()} ---");
      Console.WriteLine($"You may begin in: ");
      countDownPause();
      setDuration(duration);
      int counter = 0;
      while (getActivityContinue())
      {
        Console.WriteLine(">");
        Console.ReadLine();
        counter++;
      }
      Console.WriteLine($"You listed {counter} items!");
      endingMsg();
    }
    public ListingActivity(): base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
      _listingPrompts = new List<string> {
      "Who are people that you appreciate?",
      "What are personal strengths of yours?",
      "Who are people that you have helped this week?",
      "When have you felt the Holy Ghost this month?",
      "Who are some of your personal heroes?"
      };
    }
  }