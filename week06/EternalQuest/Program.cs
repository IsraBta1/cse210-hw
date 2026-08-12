using System;

// Possible improvements for this project:
// - Add a confirmation step before deleting or resetting goals to avoid accidental data loss.
// - Improve the user experience by displaying a clearer summary after each event is recorded.
// - Add validation for invalid menu choices, negative scores, and empty goal names/descriptions.
// - Include a feature to edit existing goals or mark them as complete manually.
// - Improve saving/loading logic with stronger error handling and more structured file formats.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}