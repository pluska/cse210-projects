using System;

class GoalsManager
{
  private List<Goal> _goals = new List<Goal>();
  private int _userPoints;

  private int _userLevel;

  private bool _goalsCompleted;

  private List<string> _levels = new List<string>();

  public void SetUserGoal (string option)
  {
    switch (option)
    {
      case "1":
        Console.WriteLine("Please enter the name of the goal:");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter the description of the goal:");
        string description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal:");
        int points = Convert.ToInt32(Console.ReadLine());
        _goals.Add(new SimpleGoal(points, name, description));
        _goalsCompleted = false;
        break;
      case "2":
        Console.WriteLine("Please enter the name of the goal:");
        name = Console.ReadLine();
        Console.WriteLine("Please enter the description of the goal:");
        description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal:");
        points = Convert.ToInt32(Console.ReadLine());
        _goals.Add(new EternalGoal(points, name, description));
        _goalsCompleted = false;
        break;
      case "3":
        Console.WriteLine("Please enter the name of the goal:");
        name = Console.ReadLine();
        Console.WriteLine("Please enter the description of the goal:");
        description = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal:");
        points = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the number of bonus points:");
        int bonusPoints = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter the number of times to complete:");
        int timesToComplete = Convert.ToInt32(Console.ReadLine());
        _goals.Add(new ChecklistGoal(timesToComplete, bonusPoints, points, name, description));
        _goalsCompleted = false;
        break;
      default:
        Console.WriteLine("Invalid Option");
        break;
    }
  }

  public string DisplayUserGoals()
  {
    string completeGoal = "[x]";
    string incompleteGoal = "[ ]";
    string output = "The goals are:";
    int i = 1;
    foreach (Goal goal in _goals)
    {
      if (goal.GetIsComplete())
      {
        if (goal is ChecklistGoal checklistGoal)
        {
          output += $"\n{i}. {completeGoal} {checklistGoal.GetNameGoal()} ({checklistGoal.GetDescriptionGoal()}) -- Currently completed: {checklistGoal.GetTimesCompleted()}/{checklistGoal.GetTimesToComplete()}";
        }
        else
        {
          output += $"\n{i}. {completeGoal} {goal.GetNameGoal()} ({goal.GetDescriptionGoal()})";
        }
      }
      else
      {
        if (goal is ChecklistGoal checklistGoal)
        {
          output += $"\n{i}. {incompleteGoal} {checklistGoal.GetNameGoal()} ({checklistGoal.GetDescriptionGoal()}) -- Currently completed: {checklistGoal.GetTimesCompleted()}/{checklistGoal.GetTimesToComplete()}";
        }
        else
        {
          output += $"\n{i}. {incompleteGoal} {goal.GetNameGoal()} ({goal.GetDescriptionGoal()})";
        }
      }
      i++;
    }
    return output;
  }

  public void SetUserPoints(int points)
  {
    _userPoints += points;
  }
  public int GetUserPoints()
  {
    return _userPoints;
  }
  private string CongratMsg(int points)
  {
    string output = "";
    if (_goalsCompleted)
    {
      _userPoints -= points;
      points += _userLevel * 1000;
      _userPoints += points;
      output = $"\nCongratulations, You have completed all your goal! You have earned {points} points!\nYou now have {_userPoints} points.";
    }
    else
    {
      output = $"\nCongratulations! You have earned {points} points!\nYou now have {_userPoints} points.";
    }
    return output;
  }

  public void GetUserGoalsStatus()
  {
    if (_goalsCompleted)
    {
      Console.WriteLine("Great job! You have completed all your goals.\nSet new goals and continue progressing in your journey!");
    }
  }

  private void CheckGoalsStatus()
  {
    bool goalsCompleted = true;
    for (int i = 0; i < _goals.Count(); i++)
    {
      if (!(_goals[i] is EternalGoal))
      {
        if (!_goals[i].GetIsComplete())
        {
          goalsCompleted = false;
        }
      }
    }
    _goalsCompleted = goalsCompleted;
  }
  public string GetUserLevel()
  {
    return _levels[_userLevel - 1];
  }

  public void SetUserLevel()
  {
    if (_userPoints >= 10000)
    {
      _userLevel = 4;
    }
    else if (_userPoints >= 5000)
    {
      _userLevel = 3;
    }
    else if (_userPoints >= 1000)
    {
      _userLevel = 2;
    }
    else
    {
      _userLevel = 1;
    }
  }

  public void levelUp(int userLevel)
  {
    if (_userLevel > userLevel)
    {
      Console.WriteLine("Awesome! You have reached the next level!\nYou received a bonus of 500 points!");
      _userPoints += 500;
    }
  }
  public void RecordEvent()
  {
    Console.WriteLine("The goals are:");
    for (int i = 0; i < _goals.Count(); i++)
    {
      Console.WriteLine($"{1 + i}. {_goals[i].GetNameGoal()}");
    }
    Console.WriteLine("Which goal did you complete?");
    string option = Console.ReadLine();
    int userLevel = _userLevel;
    _goals[Convert.ToInt32(option) - 1].RecordEvent(this);
    CheckGoalsStatus();
    Console.WriteLine(CongratMsg(_goals[Convert.ToInt32(option) - 1].GetPoints()));
    SetUserLevel();
    levelUp(userLevel);
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
  }

  public void SaveGoals()
  {
    Console.WriteLine("Please enter the name of the file: ");
    string fileName = Console.ReadLine();
    string savingFormat = $"{GetUserPoints()},{_goalsCompleted}\n";
    foreach (var goal in _goals)
    {
      switch (goal)
      {
        case SimpleGoal simple:
          savingFormat += $"SimpleGoal:{simple.GetNameGoal()},{simple.GetDescriptionGoal()},{simple.GetPoints()},{simple.GetIsComplete()}\n";
          break;
        case EternalGoal eternal:
          savingFormat += $"EternalGoal:{eternal.GetNameGoal()},{eternal.GetDescriptionGoal()},{eternal.GetPoints()}\n";
          break;
        case ChecklistGoal checklist:
          savingFormat += $"ChecklistGoal:{checklist.GetNameGoal()},{checklist.GetDescriptionGoal()},{checklist.GetPoints()},{checklist.GetBonusPoints()},{checklist.GetTimesToComplete()},{checklist.GetTimesCompleted()}\n";
          break;
        default:
          break;
      }
    }
    File.WriteAllText(fileName, savingFormat);
  }

  public void LoadGoals()
  {
    Console.WriteLine("Please enter the name of the file: ");
    string fileName = Console.ReadLine();
    string[] lines = File.ReadAllLines(fileName);
    string[] firstLine = lines[0].Split(',');
    _userPoints = Convert.ToInt32(firstLine[0]);
    _goalsCompleted = Convert.ToBoolean(firstLine[1]);
    SetUserLevel();
    for (int i = 1; i < lines.Length; i++)
    {
      string goalType = lines[i].Split(':')[0];
      string goalContent = lines[i].Split(':')[1];
      string[] parts = goalContent.Split(',');
      switch (goalType)
      {
        case "SimpleGoal":
          SimpleGoal simple = new SimpleGoal(int.Parse(parts[2]), parts[0], parts[1]);
          simple.SetIsComplete(parts[3] == "True");
          _goals.Add(simple);
          break;
        case "EternalGoal":
          EternalGoal eternal = new EternalGoal(int.Parse(parts[2]), parts[0], parts[1]);
          _goals.Add(eternal);
          break;
        case "ChecklistGoal":
          ChecklistGoal checklist = new ChecklistGoal(int.Parse(parts[4]), int.Parse(parts[3]), int.Parse(parts[2]), parts[0], parts[1]);
          checklist.SetIsComplete(parts[5] == checklist.GetTimesCompleted().ToString());
          _goals.Add(checklist);
          break;
        default:
          break;
      }
    }
  }
  public void ClearGoalsCompleted()
  {
    _goalsCompleted = false;
    List<Goal> temp = new List<Goal>(_goals);
    int counter = 0;
    foreach (Goal goal in temp)
    {
      if (goal.GetIsComplete())
      {
        _goals.Remove(goal);
        counter++;
      }
    }
    Console.WriteLine($"{counter} goal(s) have been deleted.");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
  }

  public void DeleteGoal()
  {
    Console.WriteLine(DisplayUserGoals());
    Console.WriteLine("Which goal would you like to delete?");
    string option = Console.ReadLine();
    _goals.Remove(_goals[Convert.ToInt32(option) - 1]);
    Console.WriteLine("Goal deleted!");
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
  }
  public GoalsManager()
  {
    _levels.Add("Beginner");
    _levels.Add("Intermediate");
    _levels.Add("Advanced");
    _levels.Add("Expert");
    _goalsCompleted = false;
    _userLevel = 1;
    _userPoints = 0;
  }
}