using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest");
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    keepRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string shortName = Console.ReadLine();
        Console.Write("What is the description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the point value? ");
        int points = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(shortName, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(shortName, description, points));
                break;
            case "3":
                Console.Write("How many times must this goal be completed? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for completing it? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        Console.WriteLine("Goal created successfully.");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("There are no goals to record.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you complete? ");

        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice < 0 || choice >= _goals.Count)
        {
            Console.WriteLine("That goal does not exist.");
            return;
        }

        int pointsEarned = _goals[choice].RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete or no points were awarded.");
        }

        Console.WriteLine($"Your score is now {_score}.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        using StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine(_score);
        writer.WriteLine(_goals.Count);

        foreach (Goal goal in _goals)
        {
            if (goal is SimpleGoal simpleGoal)
            {
                writer.WriteLine($"SimpleGoal|{simpleGoal.ShortName}|{simpleGoal.Description}|{simpleGoal.Points}|{simpleGoal.IsComplete()}");
            }
            else if (goal is EternalGoal eternalGoal)
            {
                writer.WriteLine($"EternalGoal|{eternalGoal.ShortName}|{eternalGoal.Description}|{eternalGoal.Points}");
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                writer.WriteLine($"ChecklistGoal|{checklistGoal.ShortName}|{checklistGoal.Description}|{checklistGoal.Points}|{checklistGoal.AmountCompleted}|{checklistGoal.Target}|{checklistGoal.Bonus}");
            }
        }

        Console.WriteLine($"Goals saved to {fileName}.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        _score = int.Parse(lines[0]);
        int count = int.Parse(lines[1]);
        _goals.Clear();

        for (int i = 0; i < count; i++)
        {
            string line = lines[i + 2];
            string[] parts = line.Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                    if (bool.Parse(parts[4]))
                    {
                        ((SimpleGoal)_goals[_goals.Count - 1]).RecordEvent();
                    }
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6])));
                    int amountCompleted = int.Parse(parts[4]);
                    for (int j = 0; j < amountCompleted; j++)
                    {
                        ((ChecklistGoal)_goals[_goals.Count - 1]).RecordEvent();
                    }
                    break;
            }
        }

        Console.WriteLine($"Goals loaded from {fileName}.");
    }
}
