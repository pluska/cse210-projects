using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        library.AddBook(new RecreationalBook("Book1", "Author1", "Genre1", 2022, "Topic1", new List<Character>(), new List<string>()));
        library.AddBook(new BiographyBook("Book2", "Author2", "Genre2", 2022, new List<string>(), new Character("Character1", 40, "Description1"), 1962, 2002, new List<string>()));
        library.AddBook(new HistoryBook("Book3", "Author3", "Genre3", 2022, "TimePeriod1", "HistoricalEvent1", new List<Character>(), new List<string>()));
        List<string> options = new List<string>(){"Display Books", "Display Genres", "Search by Genre", "Search by Author", "Load Books", "Save Books" ,"Exit"};
        Menu menu = new Menu(options);
        bool keepRunning = true;
        while (keepRunning)
        {
            menu.DisplayMenu();
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    library.DisplayBooks();
                    break;
                case 2:
                    library.DisplayGenres();
                    break;
                case 3:
                    Console.WriteLine("Enter a genre: ");
                    string genre = Console.ReadLine();
                    library.SearchByGenre(genre);
                    break;
                case 4:
                    Console.WriteLine("Enter an author: ");
                    string author = Console.ReadLine();
                    library.SearchByAuthor(author);
                    break;
                case 5:
                    Console.WriteLine("Enter a book title: ");
                    library.LoadBooks("Books.txt");
                    break;
                case 6:
                    Console.WriteLine("Enter a book title: ");
                    library.SaveBooks("Books.txt");
                    break;
                case 7:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}