using System;

class Goal {
  private string _nameGoal;
  private string _descriptionGoal;
  protected int _points;
  protected bool _isComplete;
  public virtual void SetIsComplete (bool isComplete) {
    _isComplete = isComplete;
  }
  public virtual void RecordEvent (GoalsManager manager) {
    return;
  }
  public string GetNameGoal() {
    return _nameGoal;
  }
  public string GetDescriptionGoal() {
    return _descriptionGoal;
  }
  public int GetPoints() {
    return _points;
  }
  public bool GetIsComplete() {
    return _isComplete;
  }

  public Goal (string nameGoal, string descriptionGoal) {
    _nameGoal = nameGoal;
    _descriptionGoal = descriptionGoal;
  }

}