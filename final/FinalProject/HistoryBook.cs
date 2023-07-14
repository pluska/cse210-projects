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

  public override void SaveBook()
  {
    throw new NotImplementedException();
  }

  public HistoryBook(string title, string author, string genre, int publicationYear, string timePeriod, string historicalEvent, List<Character> historicalCharacters, List<string> content): base(title, author, genre, publicationYear, content)
  {
    _timePeriod = timePeriod;
    _historicalEvent = historicalEvent;
    _historicalCharacters = historicalCharacters;
  }

}