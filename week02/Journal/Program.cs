using System;

class Program
{
    static void Main(string[] args)
    {
        Journal TheJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        const string fileName = "journal.txt";
        TheJournal.LoadFromFile(fileName);

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                var entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = promptGen.GetRandomPrompt();
                Console.WriteLine(entry._promptText);
                Console.Write("Your response: ");
                entry._entryText = Console.ReadLine();
                TheJournal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                TheJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                TheJournal.LoadFromFile(fileName);
                Console.WriteLine("Loaded entries from file.");
            }
            else if (choice == "4")
            {
                TheJournal.SaveToFile(fileName);
                Console.WriteLine("Saved entries to file.");
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}