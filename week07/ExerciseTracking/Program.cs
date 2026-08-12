using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine();

        bool continueAdding = true;

        while (continueAdding)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Running");
            Console.WriteLine("2. Cycling");
            Console.WriteLine("3. Swimming");
            Console.WriteLine("4. Finish and show summary");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    activities.Add(CreateRunning());
                    break;
                case "2":
                    activities.Add(CreateCycling());
                    break;
                case "3":
                    activities.Add(CreateSwimming());
                    break;
                case "4":
                    continueAdding = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        Console.WriteLine("Activity summaries:");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

    static Running CreateRunning()
    {
        Console.WriteLine("Running activity");
        DateTime date = ReadDate("Enter date (MM/dd/yyyy): ");
        int minutes = ReadInt("Enter duration in minutes: ");
        double distance = ReadDouble("Enter distance in miles: ");

        return new Running(date, minutes, distance);
    }

    static Cycling CreateCycling()
    {
        Console.WriteLine();
        Console.WriteLine("Cycling activity");
        DateTime date = ReadDate("Enter date (MM/dd/yyyy): ");
        int minutes = ReadInt("Enter duration in minutes: ");
        double speed = ReadDouble("Enter speed in mph: ");

        return new Cycling(date, minutes, speed);
    }

    static Swimming CreateSwimming()
    {
        Console.WriteLine();
        Console.WriteLine("Swimming activity");
        DateTime date = ReadDate("Enter date (MM/dd/yyyy): ");
        int minutes = ReadInt("Enter duration in minutes: ");
        int laps = ReadInt("Enter number of laps: ");

        return new Swimming(date, minutes, laps);
    }

    static DateTime ReadDate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime result))
            {
                return result;
            }

            Console.WriteLine("Invalid date. Please try again.");
        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            Console.WriteLine("Invalid number. Please try again.");
        }
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out double result))
            {
                return result;
            }

            Console.WriteLine("Invalid number. Please try again.");
        }
    }
}