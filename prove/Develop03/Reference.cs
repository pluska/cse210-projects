using System;

class Reference
{
    private string _book;
    private string _chapter;
    private string _verse;
    private string _endVerse;

    public string GetReference()
    {
        if (_endVerse == "")
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }

    public Reference(string book, string chapter, string verse, string endVext)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVext;
    }

    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = "";
    }
}