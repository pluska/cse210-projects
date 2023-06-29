using System;

class EternalGoal : Goal
{
  public override void RecordEvent(GoalsManager manager)
  {
    manager.SetUserPoints(GetPoints());
  }

  public EternalGoal(int points, string name, string description) : base(name, description)
  {
    _points = points;
  }
}