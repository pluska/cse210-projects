using System;


class Library
{
  private List<Book> _books = new List<Book>();
  private List<string> _genres = new List<string>();

  public Book GetBook(int index)
  {
    return _books[index];
  }
  public void AddBook(Book book)
  {
    _books.Add(book);
    string newGenre = book.GetGenre();
    if (!_genres.Contains(newGenre))
    {
      _genres.Add(newGenre);
    }
  }
  public void RemoveBook(Book book)
  {
    _books.Remove(book);
    string genre = book.GetGenre();
    Console.WriteLine($"Do you want to remove the genre \"{genre}\" too? (Y/N)");
    string answer = Console.ReadLine();
    if (answer == "Y")
    {
      _genres.Remove(genre);
    }
  }
  public void DisplayBooks()
  {
    int choice = 0;
    List<string> options = new List<string>() {
      "Display information",
      "Display character(s)",
      "Read",
      "Change book",
      "Return to Main Menu",
    };
    Menu menu = new Menu(options);
    Console.Clear();
    Console.WriteLine("These are the books in the library:");
    for (int i = 0; i < _books.Count; i++)
    {
      Console.WriteLine($"{i + 1}. {_books[i].GetTitle()}");
    }
    Console.WriteLine("Wich book would you like to choose? ");
    try
    {
      choice = Convert.ToInt32(Console.ReadLine());
    }
    catch (System.Exception)
    {
      Console.WriteLine("Invalid choice");
      Console.WriteLine("Press any key to continue");
      Console.ReadLine();
      return;
    }
    if (choice > _books.Count)
    {
      Console.WriteLine("Invalid choice");
      Console.WriteLine("Press any key to continue");
      Console.ReadLine();
      return;
    }
    Book book = _books[choice - 1];
    bool keepDisplaying = true;
    while (keepDisplaying)
    {
      Console.Clear();
      menu.DisplayMenu();
      Console.WriteLine("Enter your choice: ");
      try
      {
        choice = Convert.ToInt32(Console.ReadLine());
      }
      catch (System.Exception)
      {
        Console.WriteLine("Invalid choice");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
      }
      switch (choice)
      {
        case 1:
          book.DisplayInformation();
          Console.WriteLine("Press any key to continue");
          Console.ReadLine();
          break;
        case 2:
          book.DisplayCharacters();
          Console.WriteLine("Press any key to continue");
          Console.ReadLine();
          break;
        case 3:
          book.Read();
          break;
        case 4:
          this.DisplayBooks();
          break;
        case 5:
          keepDisplaying = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          break;
      }
    }
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
    List<Book> books = new List<Book>();
    foreach (Book book in _books)
    {
      if (book.GetGenre().ToLower() == genre.ToLower())
      {
        books.Add(book);
      }
    }
    if (books.Count == 0)
    {
      Console.WriteLine("No books found with this genre");
    } else
    {
      Console.WriteLine("These are the books with this genre:");
      int choice = 0;
      int i = 0;
      foreach (Book book in books)
      {
        Console.WriteLine($"{i + 1}. {book.GetTitle()}");
        i++;
      }
      Console.WriteLine("Wich book would you like to choose? ");
      try
      {
        choice = Convert.ToInt32(Console.ReadLine());
        books[choice - 1].DisplayInformation();
        Console.WriteLine("Do you want to read this book? (Y/N)");
        string answer = Console.ReadLine();
        if (answer.ToLower() == "y")
        {
          books[choice - 1].Read();
        }
      } catch (System.Exception)
      {
        Console.WriteLine("Invalid choice");
      }
    }
  }
  public void DisplayAuthors()
  {
    foreach (Book book in _books)
    {
      Console.WriteLine(book.GetAuthor());
    }
  }
  public void SearchByAuthor(string author)
  {
    List<Book> books = new List<Book>();
    foreach (Book book in _books)
    {
      if (book.GetAuthor().ToLower() == author.ToLower())
      {
        books.Add(book);
      }
    }
    if (books.Count == 0)
    {
      Console.WriteLine("No books found with this author");
    } else
    {
      Console.WriteLine("These are the books with this author:");
    }
    int choice = 0;
    int i = 0;
    foreach (Book book in books)
    {
      Console.WriteLine($"{i + 1}. {book.GetTitle()}");
      i++;
    }
    Console.WriteLine("Wich book would you like to choose? ");
    try
    {
      choice = Convert.ToInt32(Console.ReadLine());
      books[choice - 1].DisplayInformation();
      Console.WriteLine("Do you want to read this book? (Y/N)");
      string answer = Console.ReadLine();
      if (answer.ToLower() == "y")
      {
        books[choice - 1].Read();
      }
    } catch (System.Exception)
    {
      Console.WriteLine("Invalid choice");
    }
  }

  public void LoadBooks(string fileName)
  {
    Console.Clear();
    Console.WriteLine("Loading books...");
    string books = File.ReadAllText(fileName);
    string[] booksArray = books.Split("<|>");
    Console.WriteLine(booksArray.Count());
    foreach (string book in booksArray)
    {
      string bookType = book.Split("<>")[0];
      string bookSplit = book.Split("<>")[1];
      switch (bookType)
      {
        case "HistoryBook":
          HistoryBook historyBook = new HistoryBook();
          historyBook.LoadBook(bookSplit);
          _books.Add(historyBook);
          break;
        case "BiographyBook":
          BiographyBook biographyBook = new BiographyBook();
          biographyBook.LoadBook(bookSplit);
          _books.Add(biographyBook);
          break;
        case "RecreationalBook":
          RecreationalBook recreationalBook = new RecreationalBook();
          recreationalBook.LoadBook(bookSplit);
          _books.Add(recreationalBook);
          break;
      }
    }
    Console.WriteLine("Books loaded.\nPress any key to continue");
  }
  public void SaveBooks(string fileName)
  {
    Console.Clear();
    Console.WriteLine("Saving books...");
    string saveFormat = "";
    for (int i = 0; i < _books.Count; i++)
    {
      if (i == _books.Count - 1)
      {
        saveFormat += _books[i].SaveBook();
      } else {
        saveFormat += _books[i].SaveBook() + "<|>";
      }
    }
    File.WriteAllText(fileName, saveFormat);
    Console.WriteLine("Books saved.\nPress any key to continue");
    Console.ReadLine();
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
