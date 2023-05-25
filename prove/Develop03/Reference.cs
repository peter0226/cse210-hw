class Reference
{
    private string _book;
    private int _chapter;
    private int _initialVerse;
    private int _finalVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _initialVerse = verse;
        _finalVerse = verse;
    }

    public Reference(string book, int chapter, int initialVerse, int finalVerse)
    {
        _book = book;
        _chapter = chapter;
        _initialVerse = initialVerse;
        _finalVerse = finalVerse;
    }

    public string GetReference()
    {
        if (_initialVerse == _finalVerse)
            return $"{_book} {_chapter}:{_initialVerse}";
        else
            return $"{_book} {_chapter}:{_initialVerse}-{_finalVerse}";
    }
}