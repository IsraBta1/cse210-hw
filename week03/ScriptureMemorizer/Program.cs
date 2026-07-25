using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Alma", 32, 21);
        Scripture scripture = new Scripture(reference, "And now as I said concerning faith - faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.");

        Console.WriteLine("Welcome to Scripture Memorizer.");
        Console.WriteLine("At each step, some words in the scripture will be hidden.");
        Console.WriteLine("Press Enter to continue or type 'exit' to quit.");
        Console.WriteLine();

        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide more words: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "exit")
            {
                Console.WriteLine("Activity interrupted. Come back when you want to continue.");
                return;
            }

            scripture.HideRandomWords(3);
            Console.WriteLine();
        }

        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Activity completed!");
        Console.WriteLine($"Reference: {reference.GetDisplayText()}");
    }
}