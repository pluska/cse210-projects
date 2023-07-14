using System;

abstract class Book
{
  string _title;
  string _author;
  string _genre;
  int _publicationYear;
  List<string> _content;
  List<Review> _reviews;

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
      "Return to Main Menu",
    };
    Menu menu = new Menu(options);
    while (keepReading)
    {
      Console.WriteLine($"{_content[page]}");
      menu.DisplayMenu();
      Console.WriteLine("Enter your choice: ");
      int choice = int.Parse(Console.ReadLine());
      switch (choice)
      {
        case 1:
          page++;
          break;
        case 2:
          page--;
          break;
        case 3:
          keepReading = false;
          break;
        default:
          Console.WriteLine("Invalid choice");
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

  public abstract void SaveBook();

  public Book(string title, string author, string genre, int publicationYear, List<string> content)
  {
    _title = title;
    _author = author;
    _genre = genre;
    _publicationYear = publicationYear;
    _content = content;
    _reviews = new List<Review>();
  }

}