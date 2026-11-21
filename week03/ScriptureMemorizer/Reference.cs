class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int _endVerse;
    private readonly string _translation;

    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse, null)
    {
    }

    public Reference(string book, int chapter, int verse, string translation)
        : this(book, chapter, verse, verse, translation)
    {
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
        : this(book, chapter, startVerse, endVerse, null)
    {
    }

    private Reference(string book, int chapter, int startVerse, int endVerse, string translation)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _translation = translation;
    }

    public override string ToString()
    {
        string verseRange = _startVerse == _endVerse
            ? _startVerse.ToString()
            : $"{_startVerse}-{_endVerse}";

        string reference = $"{_book} {_chapter}:{verseRange}";
        return string.IsNullOrEmpty(_translation) ? reference : $"{reference} ({_translation})";
    }
}
