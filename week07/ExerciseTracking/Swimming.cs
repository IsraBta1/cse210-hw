using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public int Laps => _laps;

    public override double GetDistance()
    {
        return (_laps * 50.0 / 1000.0) * 0.62;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (Minutes == 0 || distance == 0)
        {
            return 0;
        }

        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0)
        {
            return 0;
        }

        return Minutes / distance;
    }
}
