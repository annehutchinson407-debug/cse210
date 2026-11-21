using System;
using System.Collections.Generic;
using System.Linq;

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
