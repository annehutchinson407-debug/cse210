class Comment
{
    private readonly string _name;
    private readonly string _text;

    public string Name => _name;
    public string Text => _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
}
