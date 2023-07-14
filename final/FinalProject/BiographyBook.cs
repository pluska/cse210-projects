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
    DisplayQuotes();
  }

  public override void SaveBook()
  {
    throw new NotImplementedException();
  }

  public override void DisplayInformation()
  {
    base.DisplayInformation();
    Console.WriteLine($"Subject: {_subject}");
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