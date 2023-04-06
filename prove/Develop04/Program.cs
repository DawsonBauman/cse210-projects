using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    BreathingActivity();
                }
                else if (choice == 2)
                {
                    ReflectionActivity();
                }
                else if (choice == 3)
                {
                    ListingActivity();
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void BreathingActivity()
        {
            Console.WriteLine("Breathing Activity");
            Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

            int duration = GetDuration("minutes");

            Console.WriteLine("Get ready to begin in 5 seconds...");
            Thread.Sleep(5000);

            int breathsPerMinute = 6;
            int totalBreaths = breathsPerMinute * duration;

            for (int i = 0; i < totalBreaths; i++)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(10000 / breathsPerMinute);

                Console.WriteLine("Breathe out...");
                Thread.Sleep(10000 / breathsPerMinute);
            }

            EndActivity("Breathing", duration);
        }

        static void ReflectionActivity()
        {
            Console.WriteLine("Reflection Activity");
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

            int duration = GetDuration("minutes");

            Console.WriteLine("Get ready to begin in 5 seconds...");
            Thread.Sleep(5000);

            string[] prompts = { "Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless." };

            Random rand = new Random();
            string prompt = prompts[rand.Next(prompts.Length)];

            Console.WriteLine(prompt);

            string[] questions = { "Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?" };

            int secondsPerQuestion = 30;
            int totalQuestions = (duration * 60) / secondsPerQuestion;

            for (int i = 0; i < totalQuestions; i++)
            {
                string question = questions[rand.Next(questions.Length)];

                Console.WriteLine(question);
                Thread.Sleep(secondsPerQuestion * 1000);
            }

            EndActivity("Reflection", duration);
        }

        static void ListingActivity()
        {
            Console.WriteLine("Listing Activity");
            Console.WriteLine("This activity will help you clear your mind by listing things that come to mind. Start by focusing on a category and listing as many things as you can think of within that category.");
                    int duration = GetDuration("minutes");

        Console.WriteLine("Get ready to begin in 5 seconds...");
        Thread.Sleep(5000);

        string[] categories = { "Fruits", "Animals", "Books", "Movies", "Colors" };

        Random rand = new Random();
        string category = categories[rand.Next(categories.Length)];

        Console.WriteLine("Category: " + category);

        int secondsPerItem = 10;
        int totalItems = (duration * 60) / secondsPerItem;

        for (int i = 0; i < totalItems; i++)
        {
            Console.WriteLine("Item " + (i + 1) + ": ");
            Thread.Sleep(secondsPerItem * 1000);
        }

        EndActivity("Listing", duration);
    }

    static int GetDuration(string unit)
    {
        Console.WriteLine("How long would you like to do this activity for (in " + unit + ")?");
        int duration = Convert.ToInt32(Console.ReadLine());

        return duration;
    }

    static void EndActivity(string activityName, int duration)
    {
        Console.WriteLine("You have completed the " + activityName + " activity for " + duration + " minutes.");
        Console.WriteLine();
    }
}
}
