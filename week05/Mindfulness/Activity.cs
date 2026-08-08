abstract class Activity
{
    protected string Name { get; }
    protected string Description { get; }
    protected int Duration { get; private set; }

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public abstract void Run();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name}");
        Console.WriteLine();
        Console.WriteLine(Description);
        Console.WriteLine();
        Duration = ReadDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine($"You have completed another {Duration} seconds of the {Name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int index = 0; index < seconds * 4; index++)
        {
            Console.Write(spinner[index % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int count = seconds; count > 0; count--)
        {
            Console.Write(count);
            Thread.Sleep(1000);
            Console.Write("\b ");
            Console.Write("\b");
        }
    }

    protected int ReadDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                return duration;
            }

            Console.WriteLine("Please enter a positive whole number.");
        }
    }
}