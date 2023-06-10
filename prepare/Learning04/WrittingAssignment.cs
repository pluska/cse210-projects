using System;

public class WrittingAssignment : Assignment
  {
    private string _title;

    public WrittingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
      _title = title;
    }

    public string GetWrittingInformation()
    {
      return $"{base.GetSummary()} \n{_title}";
    }

  }