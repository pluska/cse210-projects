using System;


class Library
{
  private List<Book> _books = new List<Book>();
  private List<string> _genres = new List<string>();

  public void AddBook(Book book)
  {
    _books.Add(book);
    string genre = book.GetGenre();
    _genres.Add(genre);
  }
  public void RemoveBook(Book book)
  {
    _books.Remove(book);
    string genre = book.GetGenre();
    _genres.Remove(genre);
  }
  public void DisplayBooks()
  {
    foreach (Book book in _books)
    {
      book.DisplayInformation();
    }
  }
  public void AddGenre(string genre)
  {
    _genres.Add(genre);
  }
  public void RemoveGenre(string genre)
  {
    _genres.Remove(genre);
  }
  public void DisplayGenres()
  {
    foreach (string genre in _genres)
    {
      Console.WriteLine(genre);
    }
  }
  public void SearchByGenre(string genre)
  {
    foreach (Book book in _books)
    {
      if (book.GetGenre() == genre)
      {
        book.DisplayInformation();
      }
    }
  }
  public void SearchByAuthor(string author)
  {
    foreach (Book book in _books)
    {
      if (book.GetAuthor() == author)
      {
        book.DisplayInformation();
      }
    }
  }

  public void LoadBooks(string fileName)
  {
    Console.WriteLine("Loading books...");
  }
  public void SaveBooks(string fileName)
  {
    Console.WriteLine("Saving books...");
  }

  public Library(List<Book> books)
  {
    _books = books;
    foreach (Book book in _books)
    {
      string genre = book.GetGenre();
      _genres.Add(genre);
    }
  }

  public Library()
  {
  }

}
