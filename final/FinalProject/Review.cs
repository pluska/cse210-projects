using System;

class Review
{
  private string _comment;
  private int _score;

  public string GetComment()
  {
    return _comment;
  }
  public int GetScore()
  {
    return _score;
  }
  public void DisplayReview()
  {
    Console.WriteLine($"Review: {_comment} {_score}");
  }
  public Review(string comment, int score)
  {
    _comment = comment;
    _score = score;
  }

}