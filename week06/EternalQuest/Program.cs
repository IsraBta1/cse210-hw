using System;

// Additional feature that could be added: a confirmation message before deleting a goal
// or a user-friendly "goal summary" screen after recording an event.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}