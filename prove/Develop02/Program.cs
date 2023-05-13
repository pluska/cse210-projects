using System;

class Program
{

    static List<string> _entries;
    public class  Menu
    {
        public List<string> _options;
        public int DisplayMenuOptions()
        {
            Console.WriteLine("Please select an option:");
            for (int i = 0; i < _options.Count(); i++)
            {
                Console.WriteLine($"{i+1}. {_options[i]}");
            }
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid Option\n");
                return 0;
            }
        }
        public void QuitProgram() {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }
    }
    public class JournalManager
    {
        public List<string> _questions;
        public void CreateEntry()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 4);
            Console.WriteLine($"{_questions[randomNumber]}");
            string entry = Console.ReadLine();
            string now = DateTime.Now.ToString("MM/dd/yyyy");
            string formattedEntry =
            $"Date:{now} - Promt: {_questions[randomNumber]}\n" +
            $"{entry}";
            _entries.Add(formattedEntry);
            Console.WriteLine("Entry created\n");
        }
            public void RemoveEntry() {
                if (_entries.Count() == 0)
                {
                    Console.WriteLine("No entries to remove\n");
                } else
                {
                    Console.WriteLine("Which entry would you like to remove?");
                    int entryNumber = int.Parse(Console.ReadLine());
                    if (entryNumber > _entries.Count() || entryNumber < 1)
                    {
                        Console.WriteLine("Invalid entry number\n");
                    }
                    else
                    {
                        _entries.RemoveAt(entryNumber - 1);
                        Console.WriteLine("Entry removed\n");
                    }
                }
            }
            public void EditEntry() {
                if (_entries.Count() == 0)
                {
                    Console.WriteLine("No entries to edit\n");
                } else
                {
                    Console.WriteLine("Which entry would you like to edit?");
                    int entryNumber = int.Parse(Console.ReadLine());
                    if (entryNumber > _entries.Count() || entryNumber < 1)
                    {
                        Console.WriteLine("Invalid entry number\n");
                    }
                    else
                    {
                        Console.WriteLine("What would you like to change the entry to?");
                        string newEntry = Console.ReadLine();
                        string question = _entries[entryNumber - 1].Split('\n')[0];
                        string editedEntry = $"{question}\n" +
                        newEntry;
                        _entries[entryNumber - 1] = editedEntry;
                        Console.WriteLine("Entry edited\n");
                    }
                }
            }
            public void DisplayEntries()
            {
                if (_entries.Count() == 0)
                {
                    Console.WriteLine("No entries to display\n");
                }
                else
                {
                    int i = 1;
                    foreach (string entry in _entries)
                    {
                        Console.WriteLine($"{i}. {entry}");
                        i++;
                    }
                }
            }
    }
    public class FileManager
    {
        public void SaveEntries(string filename)
        {
            string path = $"./{filename}";
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (string entry in _entries)
                {
                    sw.WriteLine(entry);
                }
            }
            _entries.Clear();
            Console.WriteLine("Entries saved\n");
        }
        public void LoadEntries(string filename)
        {
            string path = $"./{filename}";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string entry = "";
                    while ((entry = sr.ReadLine()) != null)
                    {
                        _entries.Add(entry);
                    }
                    int i = 1;
                    foreach (string entryLoaded in _entries)
                    {
                        Console.WriteLine($"{i}. {entryLoaded}");
                    }
                }
            } else
            {
                Console.WriteLine("File does not exist\n");
            }
        }
    }

        static void Main(string[] args)
        {
            _entries = new List<string>();
            Menu menu = new Menu();
            menu._options = new List<string>() { "New Entry", "Display Entries", "Edit Entry", "Delete Entry" ,"Save Entries", "Load Entries" ,"Quit" };
            JournalManager journalManager = new JournalManager();
            journalManager._questions = new List<string>() {
            "What did you study today?",
            "If your day was a news title, What will be? and Why?",
            "Do you meet someone today? What is his/her name? And How do you meet it?",
            "What are you grateful for today?",
            "What could you have done to make today better?"
            };
            FileManager fileManager = new FileManager();
            Console.WriteLine("Welcome to Journal App");
            int selection = menu.DisplayMenuOptions();
            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        journalManager.CreateEntry();
                        break;
                    case 2:
                        journalManager.DisplayEntries();
                        break;
                    case 3:
                        journalManager.EditEntry();
                        break;
                    case 4:
                        journalManager.RemoveEntry();
                        break;
                    case 5:
                        if (_entries.Count() == 0)
                        {
                            Console.WriteLine("No entries to save");
                            break;
                        }
                        Console.WriteLine("What is the name of the file?");
                        string filenameToSave = Console.ReadLine();
                        fileManager.SaveEntries(filenameToSave);
                        break;
                    case 6:
                        Console.WriteLine("What is the name of the file?");
                        string filenameToLoad = Console.ReadLine();
                        fileManager.LoadEntries(filenameToLoad);
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
                selection = menu.DisplayMenuOptions();
            }
            menu.QuitProgram();
        }
}