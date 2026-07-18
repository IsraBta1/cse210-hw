using System;

class Program
{
    static void Main(string[] args)
    {
        Journal TheJournal = new Journal();
        Entry newEntry = new Entry();
        TheJournal.AddEntry(newEntry);
        TheJournal.DisplayAll();
        newEntry.Display();
       
        Console.WriteLine("Hello World! This is the Journal Project.");

    }
}