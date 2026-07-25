using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetFractionValue());

        Fraction f2 = new Fraction();
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetFractionValue());

        Fraction f3 = new Fraction(5);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetFractionValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetFractionValue());
    }
}