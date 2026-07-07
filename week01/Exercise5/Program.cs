using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userAge = PromptUserAge();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, userAge, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program function!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int PromptUserAge()
    {
        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());

        return age;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int age, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square} and your age is {age}.");
    }
}