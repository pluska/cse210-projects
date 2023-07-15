using System;

class HistoryBook: Book
{
  private string _timePeriod;
  private string _historicalEvent;
  private List<Character> _historicalCharacters;

  public override void DisplayCharacters()
  {
    foreach (Character character in _historicalCharacters)
    {
      character.DisplayCharacterInfo();
    }
  }

  public override void DisplayInformation()
  {
    base.DisplayInformation();
    Console.WriteLine($"Time Period: {_timePeriod}");
    Console.WriteLine($"Historical Event: {_historicalEvent}");
    DisplayCharacters();
  }

  public override string SaveBook()
  {
    string reviews = "";
    if (_reviews.Count == 0)
    {
      foreach (Review review in _reviews)
      {
        reviews += review.GetComment() + ":" + review.GetScore() + "|";
      }
    }
    string characters = "";
    int i = 0;
    foreach (Character character in _historicalCharacters)
    {
      if (i == _historicalCharacters.Count - 1)
      {
        characters += character.GetName() + ":" + character.GetAge() + ":" + character.GetDescription();
      } else
      {
        characters += character.GetName() + ":" + character.GetAge() + ":" + character.GetDescription() + "|" ;
      }
      i++;
    }
    string content = "";
    foreach (string line in _content)
    {
      content += line + "|";
    }
    string saveFormat = $"HistoryBook<>{_title}<{_author}<{_genre}<{_publicationYear}<{reviews}<{_timePeriod}<{_historicalEvent}<{characters}<content>{content}";
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
    _timePeriod = parts[5];
    _historicalEvent = parts[6];
    _historicalCharacters = new List<Character>();
    foreach (string part in parts[7].Split('|'))
    {
      _historicalCharacters.Add(new Character(part.Split(':')[0], int.Parse(part.Split(':')[1]), part.Split(':')[2]));
    }
    string content = parts[8].Split('>')[1];
    List<string> contentParts = content.Split('|').ToList();
    _content = contentParts;
  }
  public HistoryBook()
  {
    _timePeriod = "";
    _historicalEvent = "";
    _historicalCharacters = new List<Character>();
  }
  public HistoryBook(string title, string author, string genre, int publicationYear, string timePeriod, string historicalEvent, List<Character> historicalCharacters, List<string> content): base(title, author, genre, publicationYear, content)
  {
    _timePeriod = timePeriod;
    _historicalEvent = historicalEvent;
    _historicalCharacters = historicalCharacters;
  }

  public HistoryBook(string title, string author, string genre, int publicationYear, List<string> content, List<Review> reviews, string timePeriod, string historicalEvent, List<Character> historicalCharacters): base(title, author, genre, publicationYear, content, reviews)
  {
    _timePeriod = timePeriod;
    _historicalEvent = historicalEvent;
    _historicalCharacters = historicalCharacters;
  }
}