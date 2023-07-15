using System;

class Program
{
    /*Progress Report
    * The program creates a library
    * that stores books and genres with Library.AddBook()
    *
    * The program creates a menu with the following options:
    * 1. Display Books - Displays all books in the library and their information using Library.DisplayBooks()
    * 2. Display Genres - Displays all genres in the library and their information using Library.DisplayGenres()
    * 3. Search by Genre - Displays all books in the library that have the specified genre using Library.SearchByGenre()
    * 4. Search by Author - Displays all books in the library that have the specified author using Library.SearchByAuthor()
    * 5. Load Books - Loads books from a file using Library.LoadBooks() (It is in progress)
    * 6. Save Books - Saves books to a file using Library.SaveBooks() (It is in progress)
    * 7. Exit
    */
    static void Main(string[] args)
    {
        Library library = new Library();
        /* Recreational Book Example: */
        List<Character> harryPotterMainCharacters = new List<Character>();
        harryPotterMainCharacters.Add(new Character("Harry Potter", 14, "Messy hair and glasses who became famous within the wizard community by surviving the curse of a powerful wizard. Harry frequently finds himself entangled in dangerous adventures but he always lives to tell the tale. Harry's character represents good intentions, innocence, and the fantasies of childhood."));
        harryPotterMainCharacters.Add(new Character("Ron Weasley", 14, "Ron is tall, red-haired, and from a respected but poor family. Ron is one of Harry's two best friends at Hogwarts."));
        harryPotterMainCharacters.Add(new Character("Hermione Granger", 14, "Hermione is a very intelligent and caring person. She is the head of the Hogwarts school of Witchcraft and Wizardry."));
        List<string> harryPotterContent = new List<string>();
        harryPotterContent.Add("Chapter 1: The Riddle House.\nFrank Bryce, an elderly gardener who lives in a village called Little Hangleton. Frank is awakened in the middle of the night by the sound of voices and lights coming from the Riddle House, an old and deserted mansion located near his home. Curious, Frank stealthily approaches the mansion and peeks through a window.");
        harryPotterContent.Add("Inside the mansion, Frank sees a group of people arguing and planning something. He recognizes Tom Riddle, the former butler of the mansion, and a young, evil-looking man named Lord Voldemort. Frank overhears fragments of their conversation, where they mention Voldemort's return and his plans to regain his power.");
        harryPotterContent.Add("Suddenly, Frank is discovered by Nagini, Voldemort's pet snake. Terrified, Frank flees from the mansion as Nagini pursues him. He manages to escape but is deeply disturbed by what he has witnessed.");
        library.AddBook(new RecreationalBook("Harry Potter and the Goblet of Fire", "J.K. Rowling", "Recreational", 2000, "Fantasy", harryPotterMainCharacters, harryPotterContent));

        /* History Book Example: */
        List<Character> historyMainCharacters = new List<Character>();
        historyMainCharacters.Add(new Character("Adolt Hitler", 56, "Leader of the Nazi Party and Chancellor of Germany"));
        historyMainCharacters.Add(new Character("Joseph Goebbels", 52, "Minister of Propaganda for the Third Reich. He played a crucial role in promoting and disseminating Nazi ideology."));
        historyMainCharacters.Add(new Character("Heinrich Himmler", 47, "Head of the SS (Schutzstaffel) and one of the key architects of the Holocaust."));
        List<string> historyContent = new List<string>();
        historyContent.Add("Chapter 1: The Third Reich.\nAdolf Hitler was born in 1889 in a small town in Germany. He was the youngest of four children, and his parents were Jewish.");
        historyContent.Add("He was a member of the Nazi Party, which was founded in 1923. He was the leader of the Nazi Party and Chancellor of Germany. He played a crucial role in promoting and disseminating Nazi ideology.");
        historyContent.Add("He was a member of the SS (Schutzstaffel) and one of the key architects of the Holocaust.");
        library.AddBook(new HistoryBook("The Rise and Fall of the Third Reich", "William L. Shirer", "History", 1960, "1920-1945", "The rise and fall of the Nazi regime in Germany.",historyMainCharacters, historyContent));

        /* Biography Book Example: */
        Character steveJobs = new Character("Steve Jobs", 56, "Steve Jobs was an American business magnate, industrial designer, and visionary entrepreneur. He co-founded Apple Inc., one of the world's most influential technology companies, and played a crucial role in revolutionizing the personal computer, music, and mobile industries.");
        List<string> biographyContent = new List<string>();
        biographyContent.Add("Chapter 1: Steve Jobs.\nSteve Jobs was born in 1955 in San Francisco, California. He was the youngest of four children, and his parents were both of German descent.");
        biographyContent.Add("He was a member of the Apple Computer Company and a co-founder of the company.");
        biographyContent.Add("He played a crucial role in revolutionizing the personal computer industry.");
        List<string> steveJobsQuotes = new List<string>();
        steveJobsQuotes.Add("Stay hungry, stay foolish.");
        steveJobsQuotes.Add("Innovation distinguishes between a leader and a follower.");
        steveJobsQuotes.Add("Your work is going to fill a large part of your life, and the only way to be truly satisfied is to do what you believe is great work. And the only way to do great work is to love what you do.");
        library.AddBook(new BiographyBook("Steve Jobs", "Walter Isaacson", "Biography", 2011, biographyContent, steveJobs, 1955, 2011, steveJobsQuotes));

        List<string> options = new List<string>(){"Display Books", "Remove Book", "Search by Genre", "Search by Author", "Load Books", "Save Books" ,"Exit"};
        Menu menu = new Menu(options);
        bool keepRunning = true;
        while (keepRunning)
        {
            string fileName = "";
            menu.DisplayMenu();
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    library.DisplayBooks();
                    break;
                case 2:
                    library.DisplayBooks();
                    Console.WriteLine("Wich book would you like to remove? ");
                    int bookToRemove = int.Parse(Console.ReadLine());
                    library.RemoveBook(library.GetBook(bookToRemove));
                    break;
                case 3:
                    library.DisplayGenres();
                    Console.WriteLine("Enter a genre: ");
                    string genre = Console.ReadLine();
                    library.SearchByGenre(genre);
                    break;
                case 4:
                    library.DisplayAuthors();
                    Console.WriteLine("Enter an author: ");
                    string author = Console.ReadLine();
                    library.SearchByAuthor(author);
                    break;
                case 5:
                    Console.WriteLine("Enter the file name: ");
                    fileName = Console.ReadLine();
                    library.LoadBooks(fileName);
                    break;
                case 6:
                    Console.WriteLine("Enter the file name: ");
                    fileName = Console.ReadLine();
                    library.SaveBooks(fileName);
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