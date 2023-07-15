using System;

abstract class Book
{
  protected string _title;
  protected string _author;
  protected string _genre;
  protected int _publicationYear;
  protected List<string> _content;
  protected List<Review> _reviews;

  public string GetTitle()
  {
    return _title;
  }
  public string GetGenre()
  {
    return _genre;
  }
  public string GetAuthor()
  {
    return _author;
  }
  public virtual void Read()
  {
    bool keepReading = true;
    int page = 0;
    List<string> options = new List<string>() {
      "Next page",
      "Previous page",
      "Create review",
      "Return to Main Menu",
    };
    Menu menu = new Menu(options);
    while (keepReading)
    {
      Console.Clear();
      Console.WriteLine($"{_content[page]}");
      menu.DisplayMenu();
      Console.WriteLine("Enter your choice: ");
      int choice = 0;
      try
      {
        choice = int.Parse(Console.ReadLine());
      }
      catch (System.Exception)
      {
        Console.WriteLine("Invalid choice");
        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
        continue;
      }
      switch (choice)
      {
        case 1:
          page++;
          break;
        case 2:
          if (page > 0)
          {
            page--;
          } else
          {
            Console.WriteLine("You are on the first page.");
          }
          break;
        case 3:
          CreateReview();
          break;
        case 4:
          keepReading = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
          Console.WriteLine("Press any key to continue");
          Console.ReadLine();
          break;
      }
    }
  }

  public void CreateReview()
  {
    Console.WriteLine("Enter a review: ");
    string review = Console.ReadLine();
    Console .WriteLine("Enter a rating between 1 and 5: ");
    int rating = int.Parse(Console.ReadLine());
    _reviews.Add(new Review(review, rating));
  }

  public abstract void DisplayCharacters();

  public virtual void DisplayInformation()
  {
    Console.WriteLine($"Title: {_title}");
    Console.WriteLine($"Author: {_author}");
    Console.WriteLine($"Genre: {_genre}");
    Console.WriteLine($"Publication Year: {_publicationYear}");
    DisplayRating();
  }

  private void DisplayRating()
  {
    if (_reviews.Count == 0)
    {
      Console.WriteLine("No reviews yet");
      return;
    }
    int rating = 0;
    foreach (Review review in _reviews)
    {
      rating += review.GetScore();
    }
    Console.WriteLine($"Average rating: {rating/_reviews.Count}");
  }

  public abstract string SaveBook();
  public abstract void LoadBook(string book);

  public Book(string title, string author, string genre, int publicationYear, List<string> content)
  {
    _title = title;
    _author = author;
    _genre = genre;
    _publicationYear = publicationYear;
    _content = content;
    _reviews = new List<Review>();
  }

  public Book(string title, string author, string genre, int publicationYear, List<string> content, List<Review> reviews)
  {
    _title = title;
    _author = author;
    _genre = genre;
    _publicationYear = publicationYear;
    _content = content;
    _reviews = reviews;
  }

  public Book()
  {
    _title = "";
    _author = "";
    _genre = "";
    _publicationYear = 0;
    _content = new List<string>();
    _reviews = new List<Review>();
  }

}