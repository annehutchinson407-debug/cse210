using System.Collections.Generic;

class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _length;
    private readonly List<Comment> _comments = new List<Comment>();

    public string Title => _title;
    public string Author => _author;
    public int Length => _length;
    public IReadOnlyList<Comment> Comments => _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
}
