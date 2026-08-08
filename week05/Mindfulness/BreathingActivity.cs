using System.Diagnostics;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity will help you relax by walking you through slow breathing. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Stopwatch timer = Stopwatch.StartNew();
        while (timer.Elapsed.TotalSeconds < Duration)
        {
            int remaining = Duration - (int)timer.Elapsed.TotalSeconds;
            int inhaleSeconds = Math.Min(4, remaining);
            Console.Write("\nBreathe in... ");
            ShowCountDown(inhaleSeconds);
            if (timer.Elapsed.TotalSeconds >= Duration)
            {
                break;
            }

            remaining = Duration - (int)timer.Elapsed.TotalSeconds;
            int exhaleSeconds = Math.Min(6, remaining);
            Console.Write("\nNow breathe out... ");
            ShowCountDown(exhaleSeconds);
        }

        DisplayEndingMessage();
    }
}