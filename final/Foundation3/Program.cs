using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an example event of each type
        Lecture lectureEvent = new Lecture("Title1", "Description1", 2023, 4, 10, 14, new Address("123 Main St", "City1", "State1", "Country1"), "Speaker1", 50);
        Reception receptionEvent = new Reception("Title2", "Description2", 2023, 5, 15, 18, new Address("456 Elm St", "City2", "State2", "Country2"), "rsvp@example.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Title3", "Description3", 2023, 6, 20, 10, new Address("789 Oak St", "City3", "State3", "Country3"), "Sunny");

        // Call the methods to generate marketing messages for each event
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine(outdoorEvent.GetShortDescription());
        Console.WriteLine();
    }
}

class Event
{
    private string title;
    private string description;
    private int date;
    private int time;
    private Address address;

    public Event(string title, string description, int year, int month, int day, int hour, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = year * 10000 + month * 100 + day;
        this.time = hour;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {GetFormattedDate()}\nTime: {time} o'clock\nAddress: {address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Type: {GetType().Name}\nTitle: {title}\nDate: {GetFormattedDate()}";
    }

    private string GetFormattedDate()
    {
        int year = date / 10000;
        int month = (date / 100) % 100;
        int day = date % 100;
        return $"{year}-{month}-{day}";
    }
}

class Lecture : Event
{
    private string speakerName;
    private int capacity;

    public Lecture(string title, string description, int year, int month, int day, int hour, Address address, string speakerName, int capacity)
        : base(title, description, year, month, day, hour, address)
    {
        this.speakerName = speakerName;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speakerName}\nCapacity: {capacity}";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, int year, int month, int day, int hour, Address address, string rsvpEmail)
        : base(title, description, year, month, day, hour, address)
{
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, int year, int month, int day, int hour, Address address, string weather)
        : base(title, description, year, month, day, hour, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather: {weather}";
    }
}

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {country}";
    }
}