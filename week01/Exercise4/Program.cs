using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        while (true)
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();
            int userNumber = int.Parse(userResponse);

            if (userNumber == 0)
            {
                break;
            }

            numbers.Add(userNumber);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        double average = (double)sum / numbers.Count;
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        Console.ReadLine();
    }
}
