using System;
class Entry
{
    private const string Separator = "~|~";    
    public string Date { get; private set; }
    public string Prompt { get; private set; }
    public string Response { get; private set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine("Date: " + Date + " - Prompt: " + Prompt);
        Console.WriteLine(Response);
    }

    public string ToFileLine()
    {
        return Date + Separator + Prompt + Separator + Response;
    }
    public static Entry FromFileLine(string line)
    {
        string[] fields = line.Split(new[] { Separator }, 3, StringSplitOptions.None);

        if (fields.Length != 3)
        {
            throw new FormatException("A journal entry in the file is not in the expected format.");
        }

        return new Entry(fields[0], fields[1], fields[2]);
    }
}
