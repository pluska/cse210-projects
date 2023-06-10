using System;

public class MathAssignment: Assignment {

  private string _textbooksection;
  private string _problemns;
  public MathAssignment(string studentName, string topic, string textbooksection, string problemns): base(studentName, topic) {
    _textbooksection = textbooksection;
    _problemns = problemns;
  }
  public string GetHomeworkList() {

    return $"{base.GetSummary()} \n Section {_textbooksection} Problems {_problemns}";
  }
}