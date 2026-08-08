# Mindfulness Project Explanation

## Overview

The Mindfulness project is a console application that guides the user through three different mindfulness activities: breathing, reflecting, and listing. The program uses inheritance and a shared base class to avoid duplicating common behavior.

## Program Structure

The code is divided into separate C# files to make the project easier to read, maintain, and extend:

- `Program.cs` contains the main menu and controls the user's activity selection.
- `Activity.cs` contains the abstract base class shared by all activities.
- `BreathingActivity.cs` contains the breathing activity.
- `ReflectingActivity.cs` contains the reflecting activity.
- `ListingActivity.cs` contains the listing activity.

## Inheritance and the Base Class

The abstract `Activity` class stores the common information for every activity:

- The activity name.
- The activity description.
- The session duration.

It also provides shared methods for displaying the starting and ending messages, showing a spinner animation, displaying countdowns, and reading a valid session duration from the user.

The three activity classes inherit from `Activity` and override the `Run()` method with their own behavior. This demonstrates polymorphism because each activity can be used through the same general activity structure while performing a different task.

## Breathing Activity

The `BreathingActivity` guides the user through repeated breathing cycles. It displays instructions to breathe in and breathe out, using countdowns for each part of the cycle. A stopwatch ensures that the activity runs for the number of seconds selected by the user.

## Reflecting Activity

The `ReflectingActivity` helps the user think about meaningful or challenging experiences. It selects a random reflection prompt and then displays reflection questions during the session. Questions are removed from a temporary list after being selected so they do not immediately repeat until all questions have been used.

## Listing Activity

The `ListingActivity` displays a random prompt and asks the user to list as many responses as possible before the session ends. It counts each non-empty response and displays the final number of items listed.

## User Input and Validation

The application validates the menu selection and only accepts positive whole numbers for the activity duration. If the user enters invalid information, the program displays an error message and asks for input again.

## Program Flow

1. The program displays the main menu.
2. The user selects an activity or chooses to quit.
3. The selected activity displays its instructions.
4. The user chooses the duration.
5. The activity runs with countdowns, prompts, and animations.
6. A completion message is displayed.
7. The program returns to the main menu.

## Verification

The project was compiled using the `Mindfulness.csproj` file with .NET 10. The build completed successfully, and no errors were reported in the source files.

## Conclusion

The project applies object-oriented programming principles, especially abstraction, inheritance, encapsulation, and polymorphism. Separating each class into its own file also makes the program more organized and easier to maintain without changing its functionality.
