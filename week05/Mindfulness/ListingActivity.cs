using System.Diagnostics;

class ListingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "What are some good things happening in your life right now?"
    };

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine(GetRandomItem(_prompts));
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        Stopwatch timer = Stopwatch.StartNew();
        int count = 0;
        while (timer.Elapsed.TotalSeconds < _duration)
        {
            Console.Write(" ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} items!");
        DisplayEndingMessage();
    }

    private static string GetRandomItem(List<string> items)
    {
        return items[Random.Shared.Next(items.Count)];
    }
}