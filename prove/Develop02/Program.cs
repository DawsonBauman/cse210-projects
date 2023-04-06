using System;
using System.Collections.Generic;
using System.IO;

namespace DailyJournal
{
    class Program
    {
        static List<Entry> entries = new List<Entry>();
        static List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("DAILY JOURNAL");
                Console.WriteLine("=============");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        WriteNewEntry();
                        break;
                    case "2":
                        DisplayJournal();
                        break;
                    case "3":
                        SaveJournalToFile();
                        break;
                    case "4":
                        LoadJournalFromFile();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void WriteNewEntry()
        {
            Console.Clear();
            Console.WriteLine("WRITE A NEW ENTRY");
            Console.WriteLine("=================");
            Console.WriteLine("Answer the following prompt:");
            string prompt = prompts[new Random().Next(prompts.Count)];
            Console.WriteLine(prompt);
            Console.Write("Your answer: ");
            string answer = Console.ReadLine();
            entries.Add(new Entry(prompt, answer, DateTime.Now.ToString()));
            Console.WriteLine("Entry saved. Press any key to continue.");
            Console.ReadKey();
        }

        static void DisplayJournal()
        {
            Console.Clear();
            Console.WriteLine("JOURNAL ENTRIES");
            Console.WriteLine("===============");
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries yet.");
            }
            else
            {
                foreach (Entry entry in entries)
                {
                    Console.WriteLine($"[{entry.Date}] {entry.Prompt}: {entry.Answer}");
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static void SaveJournalToFile()
        {
            Console.Clear();
            Console.WriteLine("SAVE JOURNAL TO FILE");
            Console.WriteLine("====================");
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry.Prompt}|{entry.Answer}|{entry.Date}");
                }
            }
            Console.WriteLine("Journal saved to file. Press any key to continue.");
            Console.ReadKey();
        }

        static void LoadJournalFromFile()
        {
            Console.Clear();
            Console.WriteLine("LOAD JOURNAL FROM FILE");
            Console.WriteLine("======================");
            Console.Write("Enter filename: ");
            string filename = Console.ReadLine();
            entries.Clear();
            using (StreamReader reader = new
            StreamReader(filename))
{
string line;
while ((line = reader.ReadLine()) != null)
{
string[] fields = line.Split('|');
string prompt = fields[0];
string answer = fields[1];
string date = fields[2];
entries.Add(new Entry(prompt, answer, date));
}
}
Console.WriteLine("Journal loaded from file. Press any key to continue.");
Console.ReadKey();
}
}
class Entry
{
    public string Prompt { get; }
    public string Answer { get; }
    public string Date { get; }

    public Entry(string prompt, string answer, string date)
    {
        Prompt = prompt;
        Answer = answer;
        Date = date;
    }
}
}