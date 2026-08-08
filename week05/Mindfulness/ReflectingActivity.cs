using System.Diagnostics;

class ReflectingActivity : Activity
{
    private readonly List<string> _prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you learned something important about yourself."
    };

    private readonly List<string> _questions = new()
    {
        "Why was this experience meaningful to you?",
        "How did this experience change you?",
        "What did you learn from this experience?",
        "What could you do differently next time?",
        "How can you use this lesson in the future?"
    };

    public ReflectingActivity()
        : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine(GetRandomItem(_prompts));
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.WriteLine();

        Stopwatch timer = Stopwatch.StartNew();
        List<string> availableQuestions = new(_questions);
        while (timer.Elapsed.TotalSeconds < _duration)
        {
            if (availableQuestions.Count == 0)
            {
                availableQuestions = new List<string>(_questions);
            }

            string question = GetRandomItem(availableQuestions);
            availableQuestions.Remove(question);
            Console.Write($"> {question} ");
            ShowSpinner(5);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private static string GetRandomItem(List<string> items)
    {
        return items[Random.Shared.Next(items.Count)];
    }
}