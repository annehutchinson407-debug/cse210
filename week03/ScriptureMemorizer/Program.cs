//Added more scriptures, added a randomizer to pick a new scripture each run


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture[] scriptures =
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(
                new Reference("Ephesians", 6, 4),
                "Fathers, do not provoke your children to anger, but bring them up in the discipline " +
                "and instruction of the Lord"),
            new Scripture(
                new Reference("Romans", 12, 2),
                "Do not be conformed to this world, but be transformed by the renewal of your mind..."),
            new Scripture(
                new Reference("Philippians", 1, 6),
                "Being confident of this, that he who began a good work in you will carry it on to " +
                "completion until the day of Christ Jesus"),
            new Scripture(
                new Reference("2 Timothy", 2, 15),
                "Do your best to present yourself to God as one approved, a worker who has no need of " +
                "being ashamed, rightly handling the word of truth.")
        };
        Scripture scripture = scriptures[Random.Shared.Next(scriptures.Length)];

        ClearScreen();
        Console.WriteLine(scripture);

        while (!scripture.IsCompletelyHidden)
        {
            Console.WriteLine();
            Console.Write("Please press enter to hide more words, or type quit to exit: ");
            string input = Console.ReadLine();

            if (string.Equals(input?.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Have a blessed day!");
                break;
            }

            scripture.HideRandomWords(3);
            ClearScreen();
            Console.WriteLine(scripture);
        }
    }

    private static void ClearScreen()
    {
        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }
    }
}

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

class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public override string ToString()
    {
        if (!_isHidden)
        {
            return _text;
        }

        return string.Concat(_text.Select(character =>
            char.IsLetter(character) ? '_' : character));
    }
}

class Scripture
{
    private const int WordsToHidePerTurn = 3;
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(word => new Word(word))
            .ToList();
        _random = new Random();
    }

    public bool IsCompletelyHidden => _words.All(word => word.IsHidden);

    public void HideRandomWords(int count = WordsToHidePerTurn)
    {
        List<Word> visibleWords = _words.Where(word => !word.IsHidden).ToList();
        int wordsToHide = Math.Min(count, visibleWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int wordIndex = _random.Next(visibleWords.Count);
            visibleWords[wordIndex].Hide();
            visibleWords.RemoveAt(wordIndex);
        }
    }

    public override string ToString()
    {
        return $"{_reference}\n{string.Join(" ", _words)}";
    }
}
