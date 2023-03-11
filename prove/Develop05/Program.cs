using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GoalTracker
{
    class Goal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }
        public bool Completed { get; set; }

        public virtual int RecordEvent()
        {
            return PointValue;
        }

        public virtual bool IsComplete()
        {
            return Completed;
        }

    }

    class SimpleGoal : Goal
    {
        public override int RecordEvent()
        {
            Completed = true;
            return PointValue;
        }
    }

    class EternalGoal : Goal
    {
        public override int RecordEvent()
        {
            return PointValue;
        }
    }

    class ChecklistGoal : Goal
    {
        public int NumTotal { get; set; }
        public int NumCompleted { get; set; }

        public override int RecordEvent()
        {
            NumCompleted++;

            if (NumCompleted == NumTotal)
            {
                Completed = true;
                return PointValue + 500;
            }

            return PointValue;
        }

        public override bool IsComplete()
        {
            return NumCompleted == NumTotal;
        }
    }

    class User
    {
        public string Username { get; set; }
        public List<Goal> Goals { get; set; }
        public int Score { get; set; }

        public User(string username)
        {
            Username = username;
            Goals = new List<Goal>();
            Score = 0;
        }

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void RecordEvent(int index)
        {
            Goal goal = Goals[index];
            Score += goal.RecordEvent();

            Console.WriteLine($"Event recorded for goal '{goal.Name}'.");
            Console.WriteLine($"You earned {goal.PointValue} points.");

            if (goal.IsComplete())
            {
                Console.WriteLine($"Congratulations! You completed the goal '{goal.Name}'. Here is a bonus 500 points.");
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"You have completed this goal {checklistGoal.NumCompleted}/{checklistGoal.NumTotal} times.");
            }
        }

        public int GetScore()
        {
            return Score;
        }

        public List<string> GetGoals()
        {
            List<string> goalsList = new List<string>();

            foreach (Goal goal in Goals)
            {
                string goalStatus = $"[{(goal.Completed ? "X" : " ")}] {goal.Name}";

                if (goal is ChecklistGoal checklistGoal)
                {
                    goalStatus += $" (Completed {checklistGoal.NumCompleted}/{checklistGoal.NumTotal} times)";
                }

                goalsList.Add(goalStatus);
            }

            return goalsList;
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText($"{Username}.json", json);
        }

        public static User Load(string username)
        {
            if (File.Exists($"{username}.json"))
            {
                string json = File.ReadAllText($"{username}.json");
                return JsonSerializer.Deserialize<User>(json);
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Goal Tracker app!");

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            User user = User.Load(username);
            if (user == null)
            {
                Console.WriteLine($"user'{username}' not found. Creating new user...");
                user = new User(username);
            }
            else
            {
                Console.WriteLine($"Welcome back, {username}!");
            }

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a goal");
                Console.WriteLine("2. View goals");
                Console.WriteLine("3. Record an event");
                Console.WriteLine("4. View score");
                Console.WriteLine("5. Save and exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("What type of goal would you like to add?");
                        Console.WriteLine("1. Simple goal");
                        Console.WriteLine("2. Eternal goal");
                        Console.WriteLine("3. Checklist goal");

                        string goalTypeInput = Console.ReadLine();

                        Console.Write("Enter the name of the goal: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter a description for the goal: ");
                        string description = Console.ReadLine();

                        Console.Write("Enter the point value for the goal: ");
                        int pointValue = int.Parse(Console.ReadLine());

                        Goal goal = null;

                        switch (goalTypeInput)
                        {
                            case "1":
                                goal = new SimpleGoal();
                                break;
                            case "2":
                                goal = new EternalGoal();
                                break;
                            case "3":
                                Console.Write("Enter the number of items on the checklist: ");
                                int numTotal = int.Parse(Console.ReadLine());
                                goal = new ChecklistGoal()
                                {
                                    NumTotal = numTotal
                                };
                                break;
                            default:
                                Console.WriteLine("Invalid input.");
                                break;
                        }

                        if (goal != null)
                        {
                            goal.Name = name;
                            goal.Description = description;
                            goal.PointValue = pointValue;

                            user.AddGoal(goal);

                            Console.WriteLine($"Goal '{name}' added successfully.");
                        }

                        break;
                    case "2":
                        Console.WriteLine("Your goals:");
                        List<string> goals = user.GetGoals();

                        if (goals.Count > 0)
                        {
                            foreach (string goalStatus in goals)
                            {
                                Console.WriteLine(goalStatus);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have any goals yet.");
                        }

                        break;
                    case "3":
                        Console.WriteLine("Which goal would you like to record an event for?");
                        List<string> userGoals = user.GetGoals();

                        if (userGoals.Count > 0)
                        {
                            for (int i = 0; i < userGoals.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {userGoals[i]}");
                            }

                            int goalIndex = int.Parse(Console.ReadLine()) - 1;

                            if (goalIndex >= 0 && goalIndex < user.Goals.Count)
                            {
                                user.RecordEvent(goalIndex);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You don't have any goals yet.");
                        }

                        break;
                    case "4":
                        Console.WriteLine($"Your current score is: {user.GetScore()}");
                        break;
                    case "5":
                        user.Save();
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }
    }
}