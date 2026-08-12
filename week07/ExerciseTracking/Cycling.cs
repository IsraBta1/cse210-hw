using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed;
    }

    public double Speed => _speed;

    public override double GetDistance()
    {
        if (_speed == 0)
        {
            return 0;
        }

        return (_speed * Minutes) / 60.0;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        if (_speed == 0)
        {
            return 0;
        }

        return 60.0 / _speed;
    }
}
