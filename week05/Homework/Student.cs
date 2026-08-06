using System;

public class Student : Person
{
    private string _number;

    public Student(string name, string number) : base(name)
    {
        _number = number;
    }

    public string GetNumber()
    {
        return _number;
    }

    public void SetNumber(string number)
    {
        _number = number;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, ID: {_number}";
    }
}
