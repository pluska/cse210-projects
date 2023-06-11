using System;

public class ReflectingActivity : Activity
{
  private List<string> _firstPromptList;
  private List<string> _reflectionPromptsList;

  private string displayFirstRandomPromt()
  {
    Random random = new Random();
    int randomNumber = random.Next(0, _firstPromptList.Count());
    return _firstPromptList[randomNumber];
  }

  private string displayReflectionPromts()
  {
    Random random = new Random();
    int randomNumber = random.Next(0, _reflectionPromptsList.Count());
    return _reflectionPromptsList[randomNumber];
  }

  public void reflectingActivityWorkflow()
  {
    Console.WriteLine(startingMsg());
    int duration = (Convert.ToInt32(Console.ReadLine()));
    Console.Clear();
    Console.WriteLine("Get ready...");
    spinnerPause();
    Console.WriteLine("\nConsider the following prompt");
    Console.WriteLine($" --- {displayFirstRandomPromt()} ---");
    Console.WriteLine("\nWhen you have something in mind, press enter to continue");
    Console.ReadLine();
    Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
    Console.WriteLine($"You may begin in: ");
    countDownPause();
    setDuration(duration);
    while (getActivityContinue())
    {
      Console.WriteLine(displayReflectionPromts());
      spinnerPause();
    }
    endingMsg();
  }
  public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
  {
    _firstPromptList = new List<string>{
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."};
    _reflectionPromptsList = new List<string> {
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
    };
  }
}