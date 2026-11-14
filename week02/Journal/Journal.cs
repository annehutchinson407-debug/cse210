using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Journal
{
    private readonly List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no journal entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(filename, json);
    }

    public void LoadFromFile(string filename)
    {
        List<Entry> loadedEntries = new List<Entry>();
        string contents = File.ReadAllText(filename);
        string trimmedContents = contents.TrimStart();

        if (trimmedContents.StartsWith("[", StringComparison.Ordinal))
        {
            loadedEntries = JsonSerializer.Deserialize<List<Entry>>(contents);
            if (loadedEntries == null)
            {
                throw new FormatException("The journal file does not contain a journal entry list.");
            }
        }
        else
        {
            foreach (string line in File.ReadAllLines(filename))
            {
                loadedEntries.Add(Entry.FromFileLine(line));
            }
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);
    }
}
