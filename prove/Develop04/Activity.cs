using System;

public class Activity
{
    private string _activityname;
    private string _description;
    private DateTime _startTime;
    private DateTime _endTime;
    private int _duration;

    protected int getDuration()
    {
        return _duration;
    }
    protected void setDuration(int seconds)
    {
        _duration = seconds;
        setStartTimer();
        setEndTimer();
    }

    protected void setStartTimer()
    {
        _startTime = DateTime.Now;
    }

    private void setEndTimer()
    {
        _endTime = _startTime.AddSeconds(_duration);
    }

    protected bool getActivityContinue() {
      setStartTimer();
      bool activityContinue = _startTime < _endTime;
      return activityContinue;
    }
    protected void spinnerPause()
    {
      for (int i = 0; i < 3; i++)
      {
        Console.Write("|");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("/");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("-");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("\\");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("|");
        Thread.Sleep(500);
        Console.Write("\b \b");
      }
    }

    protected void countDownPause()
    {
        for (int i = 1; i < 6; i++)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
        }
    }

    protected string startingMsg() {
        Console.Clear();
        return $"Welcome to the {_activityname} Activity.\n\n{_description}\n\nHow long, in seconds, would you like for your session? ";
    }
    protected void endingMsg() {
        Console.WriteLine("\nWell done!");
        spinnerPause();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_activityname} Activity.");
        Console.ReadLine();
    }
    public Activity(string activityname, string description)
    {
        _activityname = activityname;
        _description = description;
    }

}