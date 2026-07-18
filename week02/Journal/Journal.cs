using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var e in _entries)
        {
            e.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string file)
    {
        using (var writer = new StreamWriter(file))
        {
            foreach (var e in _entries)
            {
                // replace newlines in entry text to preserve single-line records
                var safeText = e._entryText?.Replace("\n", "\\n").Replace("\r", "") ?? "";
                writer.WriteLine($"{e._date}|{e._promptText}|{safeText}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        if (!File.Exists(file)) return;

        var lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
            var parts = line.Split('|');
            if (parts.Length < 3) continue;
            var entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2].Replace("\\n", "\n");
            _entries.Add(entry);
        }
    }
}