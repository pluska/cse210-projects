using System;

class RecreationalBook : Book
{
  private List<Character> _mainCharacters;
  private string _topic;

  public override void DisplayCharacters()
  {
    foreach (Character character in _mainCharacters)
    {
      character.DisplayCharacterInfo();
    }
  }

  public override void DisplayInformation()
  {
    base.DisplayInformation();
    Console.WriteLine($"Topic: {_topic}");
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
    string mainCharacters = "";
    int i = 0;
    foreach (Character character in _mainCharacters)
    {
      if (i == _mainCharacters.Count - 1)
      {
        mainCharacters += character.GetName() + ":" + character.GetAge() + ":" + character.GetDescription();
      }
      else
      {
        mainCharacters += character.GetName() + ":" + character.GetAge() + ":" + character.GetDescription() + "|";
      }
      i++;
    }
    string content = "";
    foreach (string line in _content)
    {
      content += line + "|";
    }
    string saveFormat = $"RecreationalBook<>{_title}<{_author}<{_genre}<{_publicationYear}<{reviews}<{mainCharacters}<{_topic}<content>{content}";
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
    _mainCharacters = new List<Character>();
    foreach (string part in parts[5].Split('|'))
    {
      string name = part.Split(':')[0];
      int age = int.Parse(part.Split(':')[1]);
      string description = part.Split(':')[2];
      _mainCharacters.Add(new Character(name, age, description));
    }
    _topic = parts[6];
    string content = parts[7].Split('>')[1];
    List<string> contentParts = content.Split('|').ToList();
    _content = contentParts;
  }
  public RecreationalBook()
  {
    _mainCharacters = new List<Character>();
    _topic = "";
  }
  public RecreationalBook(string title, string author, string genre, int publicationYear, string topic, List<Character> mainCharacters, List<string> content): base(title, author, genre, publicationYear, content)
  {
    _mainCharacters = mainCharacters;
    _topic = topic;
  }


}