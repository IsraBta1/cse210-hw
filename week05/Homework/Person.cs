using System;

public class Person
{
    private string _name;

    public Person(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public virtual string GetSummary()
    {
        return $"Name: {_name}";
    }
}
