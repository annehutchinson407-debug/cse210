using System;

class Word
{
    private string _text;
    private bool _isHidden = false;

    public Word(string text)
    {
        _text = text;
    }

    public bool IsHidden
    {
        get
        {
            return _isHidden;
        }
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public override string ToString()
    {
        if (_isHidden == false)
        {
            return _text;
        }

        string hiddenWord = "";

        for (int i = 0; i < _text.Length; i++)
        {
            if (char.IsLetter(_text[i]))
            {
                hiddenWord += "_";
            }
            else
            {
                hiddenWord += _text[i];
            }
        }

        return hiddenWord;
    }
}
