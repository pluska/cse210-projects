using System;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public string GetRenderedText()
    {
        string renderedText = $"{_reference.GetReference()}: ";
        foreach (Word word in _words)
        {
            renderedText += $"{word.GetWord()} ";
        }
        renderedText += "\n";
        return renderedText;
    }
    public void SetHiddenWords()
    {
        if (IsCompleteHidden())
        {
            return;
        } else
        {
            for (int i = 0; i < 5; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, _words.Count());
                if (_words[randomNumber].GetHidden() & !IsCompleteHidden())
                {
                    i--;
                } else
                {
                    _words[randomNumber].SetHidden(true);
                }
            }
        }
    }

    public string GetReference()
    {
        return _reference.GetReference();
    }
    public bool IsCompleteHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.GetHidden())
            {
                return false;
            }
        }
        return true;
    }

    public Scripture()
    {
        _reference = new Reference("John", "3", "16");
        string content = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        _words = new List<Word>();
        foreach (string word in content.Split(" "))
        {
            _words.Add(new Word(word));
        }
    }

    public Scripture(string reference, string content) {
        char[] delimiterChars = { ' ', ':', '-'};
        List<string> parts = new List<string>();
        foreach (var part in reference.Split(delimiterChars))
        {
            parts.Add(part);
        }
        if (parts.Count() == 3)
        {
            _reference = new Reference(parts[0], parts[1], parts[2]);
        } else {
            _reference = new Reference(parts[0], parts[1], parts[2], parts[3]);
        }
        _words = new List<Word>();
        foreach (string word in content.Split(" ")) {
            _words.Add(new Word(word));
        }
    }

}