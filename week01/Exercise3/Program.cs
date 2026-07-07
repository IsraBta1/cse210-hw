using System;
using System.Security.Cryptography;
// while
// do-while
// for
// foreach
class Program

{
    static void Main(string[] args)
    { Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 10);
        int guess;
        int attempts = 0;

        Console.WriteLine("Guess the number between 1 and 10!");

        do
        {
            Console.Write("Enter your guess: ");
            guess = Convert.ToInt32(Console.ReadLine());
            attempts++;

            if (guess < number)
            {
                Console.WriteLine("Too low! Try again.");
            }
            else if (guess > number)
            {
                Console.WriteLine("Too high! Try again.");
            }
            else
            {
                Console.WriteLine($"Congratulations! You've guessed the number {number} in {attempts} attempts.");
            }
        } while (guess != number);

    }
}