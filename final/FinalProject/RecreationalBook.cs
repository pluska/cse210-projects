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

  public override void SaveBook()
  {
    throw new NotImplementedException();
  }

  public RecreationalBook(string title, string author, string genre, int publicationYear, string topic, List<Character> mainCharacters, List<string> content): base(title, author, genre, publicationYear, content)
  {
    _mainCharacters = mainCharacters;
    _topic = topic;
  }


}