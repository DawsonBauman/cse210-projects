using System;

public abstract class Activity
{
    protected int minutes; // protected to allow access in derived classes
    protected DateTime date;

    public Activity(int minutes, DateTime date)
    {
        this.minutes = minutes;
        this.date = date;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    public abstract string GetSummary();
}

public class Running : Activity
{
    private double distance; // distance in miles

    public Running(int minutes, double distance, DateTime date) : base(minutes, date)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (minutes / 60.0);
    }

    public override double GetPace()
    {
        return minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Running ({minutes} min) - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Cycling : Activity
{
    private double speed; // speed in mph

    public Cycling(int minutes, double speed, DateTime date) : base(minutes, date)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return speed * (minutes / 60.0);
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Cycling ({minutes} min) - Distance: {GetDistance()} miles, Speed: {speed} mph, Pace: {GetPace()} min per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(int minutes, int laps, DateTime date) : base(minutes, date)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0 * 0.62; // distance in miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / (minutes / 60.0);
    }

    public override double GetPace()
    {
        return minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Swimming ({minutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create activity objects
        Running running = new Running(30, 3.0, new DateTime(2022, 11, 3));
        Cycling cycling = new Cycling(45, 15.0, new DateTime(2022, 11, 4));
        Swimming swimming = new Swimming(40, 10, new DateTime(2022, 11, 5));

        // Put activities in a list
        var activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
