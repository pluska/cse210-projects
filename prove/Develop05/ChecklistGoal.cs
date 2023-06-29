using System;

class ChecklistGoal: Goal
{
  private bool _isTotallyComplete;
  private int _bonusPoints;
  private int _timesCompleted;
  private int _timesToComplete;

  public override void SetIsComplete (bool isComplete)
  {
    if (true == isComplete)
    {
      _isTotallyComplete = true;
    } else
    {
      _isTotallyComplete = false;
    }
  }

  public override void RecordEvent(GoalsManager manager)
  {
    _timesCompleted++;
    _isTotallyComplete = _timesCompleted == _timesToComplete;
    _isComplete = _isTotallyComplete;
    SetIsComplete(_isTotallyComplete);
    manager.SetUserPoints(GetPoints());
    if (_isTotallyComplete)
    {
      manager.SetUserPoints(_bonusPoints);
    }
  }
  public int GetBonusPoints()
  {
    return _bonusPoints;
  }
  public int GetTimesCompleted()
  {
    return _timesCompleted;
  }
  public int GetTimesToComplete()
  {
    return _timesToComplete;
  }
  public ChecklistGoal(int timesToComplete, int bonusPoints, int points,string name, string description) : base(name, description)
  {
    _timesToComplete = timesToComplete;
    _bonusPoints = bonusPoints;
    _timesCompleted = 0;
    _isTotallyComplete = false;
    _isComplete = false;
    _points = points;
  }
}