using System;
using System.Collections.Generic;
using System.IO;

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
        List<string> lines = new List<string>();
        foreach (Entry entry in _entries)
        {
            lines.Add(entry.ToFileLine());
        }

        File.WriteAllLines(filename, lines);
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        List<Entry> loadedEntries = new List<Entry>();
        foreach (string line in lines)
        {
            loadedEntries.Add(Entry.FromFileLine(line));
        }

        _entries.Clear();
        _entries.AddRange(loadedEntries);
    }
}
