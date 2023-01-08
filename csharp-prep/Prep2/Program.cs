using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage? ");
        string percentage = Console.ReadLine();
        int numGrade = int.Parse(percentage);
        string letterGrade = "";

        if (numGrade >= 90)
        {
            letterGrade = "A";
        }

        else if (numGrade >= 80)
        {
            letterGrade = "B";
        }

        else if (numGrade >= 70)
        {
            letterGrade = "C";
        }

        else if (numGrade >= 60)
        {
            letterGrade = "D";
        }

        else
        {
            letterGrade = "F";
        }

        Console.WriteLine($"your grade is : {letterGrade}");

        if (numGrade >= 70)
        {
            Console.WriteLine("You passed!");
        }

        else 
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}