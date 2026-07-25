using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
                        //Default constructor that sets the fraction to 1/1
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
                        //Constructor that takes a whole number and sets the fraction to that number over 1
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
                        //Constructor that takes a numerator and denominator and sets the fraction accordingly
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
                        //Returns the fraction as a string in the form "numerator/denominator"
        return $"{_top}/{_bottom}";
    }

    public double GetFractionValue()
    {
                        //Returns the decimal value of the fraction
        return (double)_top / _bottom;
    }


}
