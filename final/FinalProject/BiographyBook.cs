using System;

class BiographyBook : Book
{
  private Character _subject;
  private int _birthYear;
  private int _deathYear;
  private List<string> _famousQuotes;

  public void DisplayQuotes()
  {
    foreach (string quote in _famousQuotes)
    {
      Console.WriteLine(quote);
    }
  }
  public override void DisplayCharacters()
  {
    _subject.DisplayCharacterInfo();
    Console.WriteLine($"Birth Year: {_birthYear}");
    Console.WriteLine($"Death Year: {_deathYear}");
    Console.WriteLine($"These are some of the famous quotes of {_subject.GetName()}:");
    DisplayQuotes();
  }

  public override string SaveBook()
  {
    string reviews = "";
    if (_reviews.Count == 0)
    {
      for (int i = 0; i < _reviews.Count; i++)
      {
        if (i == _reviews.Count - 1)
        {
          reviews += _reviews[i].GetComment() + ":" + _reviews[i].GetScore();
        } else
        {
          reviews += _reviews[i].GetComment() + ":" + _reviews[i].GetScore() + "|";
        }
      }
    }
    string famousQuotes = "";
    foreach (string quote in _famousQuotes)
    {
      famousQuotes += quote + "|";
    }
    string subject = $"{_subject.GetName()}|{_birthYear}|{_deathYear}";
    string content = "";
    foreach (string line in _content)
    {
      content += line + "|";
    }
    string saveFormat = $"BiographyBook<>{_title}<{_author}<{_genre}<{_publicationYear}<{reviews}<{_birthYear}<{_deathYear}<{famousQuotes}<{subject}<content>{_content}";
    return saveFormat;
  }

  public override void LoadBook(string book)
  {
    List<string> parts = book.Split('<').ToList();
    _title = parts[0];
    _author = parts[1];
    _genre = parts[2];
    _publicationYear = int.Parse(parts[3]);
    _reviews = new List<Review>();
    if (!(parts[4] == ""))
    {
      foreach (string part in parts[4].Split('|'))
      {
        string comment = part.Split(':')[0];
        int rating = int.Parse(part.Split(':')[1]);
        _reviews.Add(new Review(comment, rating));
      }
    }
    _birthYear = int.Parse(parts[5]);
    if (parts[6] != "")
    {
      _deathYear = int.Parse(parts[6]);
    }
    _famousQuotes = parts[7].Split('|').ToList();
    _subject = new Character(parts[8].Split('|')[0], int.Parse(parts[8].Split('|')[1]), parts[8].Split('|')[2]);
    string content = parts[9].Split('>')[1];
    List<string> contentParts = content.Split('|').ToList();
    _content = contentParts;
  }

  public override void DisplayInformation()
  {
    base.DisplayInformation();
    Console.WriteLine($"Subject: {_subject.GetName()}");
  }



  public BiographyBook()
  {
  }

  public BiographyBook(string title, string author, string genre, int publicationYear, List<string> content ,Character subject, int birthYear, int deathYear, List<string> famousQuotes): base(title, author, genre, publicationYear, content)
  {
    _subject = subject;
    _birthYear = birthYear;
    _deathYear = deathYear;
    _famousQuotes = famousQuotes;
  }

  public BiographyBook(string title, string author, string genre, int publicationYear, List<string> content ,Character subject, List<string> famousQuotes, int birthYear): base(title, author, genre, publicationYear, content)
  {
    _subject = subject;
    _famousQuotes = famousQuotes;
    _birthYear = birthYear;
  }

}