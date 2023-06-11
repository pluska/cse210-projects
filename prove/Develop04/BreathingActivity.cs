using System;

public class BreathingActivity : Activity
{
    private string _breatheIn = "Breathe In...";
    private string _breatheOut = "Now breathe Out...";

    public void breathingActivityWorkflow()
    {
        Console.WriteLine(startingMsg());
        int duration = (Convert.ToInt32(Console.ReadLine()));
        Console.Clear();
        Console.WriteLine("Get ready...");
        spinnerPause();
        setDuration(duration);
        while (getActivityContinue())
        {
            Console.WriteLine(_breatheIn);
            countDownPause();
            Console.WriteLine(_breatheOut);
            countDownPause();
        }
        endingMsg();
    }
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") { }
}
