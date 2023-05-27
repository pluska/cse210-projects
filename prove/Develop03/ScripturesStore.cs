using System;

class ScripturesStore
{
    private List<Scripture> _scriptures;
    private string _filePath;

    public List<Scripture> GetScriptures()
    {
        return _scriptures;
    }
    public Scripture GetScripture(int index)
    {
        return _scriptures[index];
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int randomNumber = random.Next(0, _scriptures.Count());
        return _scriptures[randomNumber];
    }

    public void DisplayScriptures()
    {
        foreach (Scripture scripture in _scriptures)
        {
            Console.WriteLine(scripture.GetRenderedText());
        }
    }
    public ScripturesStore ()
    {
        _filePath = "./scriptures.txt";
        _scriptures = new List<Scripture>();
        string[] lines = System.IO.File.ReadAllLines(_filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Scripture scripture = new Scripture(parts[0], parts[1]);
            _scriptures.Add(scripture);
        }
    }

    public ScripturesStore(string filePath)
    {
        _filePath = filePath;
        _scriptures = new List<Scripture>();
        string[] lines = System.IO.File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Scripture scripture = new Scripture(parts[0], parts[1]);
            _scriptures.Add(scripture);
        }
    }


}