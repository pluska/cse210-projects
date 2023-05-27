using System;

class Word
{
  private string _word;
  private bool _isHidden;

  public string GetWord()
  {
    if (_isHidden)
    {
      string hiddenWord = "";
      foreach (char letter in _word)
      {
        hiddenWord += "_";
      }
      return hiddenWord;
    }
    else
    {
      return _word;
    }
  }

  public bool GetHidden()
  {
    return _isHidden;
  }

  public void SetHidden(bool isHidden)
  {
    _isHidden = isHidden;
  }

  public Word(string word)
  {
    _word = word;
    _isHidden = false;
  }
}