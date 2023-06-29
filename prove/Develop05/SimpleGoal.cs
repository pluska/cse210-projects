using System;

class SimpleGoal : Goal
{

  public override void SetIsComplete (bool isComplete)
  {
    _isComplete = isComplete;
  }
  public override void RecordEvent (GoalsManager manager)
  {
    SetIsComplete(true);
    manager.SetUserPoints(GetPoints());
  }

  public SimpleGoal(int points, string name, string description) : base(name, description)
  {
    _points = points;
  }

}