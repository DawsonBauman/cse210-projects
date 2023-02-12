using System;
using System.Collections.Generic;

namespace ScriptureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new scripture
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            // Display the scripture
            Console.WriteLine(scripture);
            Console.WriteLine("Press enter to hide words or type 'quit' to exit");

            // Loop until all words are hidden or the user types quit
            while (!scripture.IsHidden)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                // Clear the console screen and hide some words
                Console.Clear();
                scripture.HideWords();

                // Display the scripture
                Console.WriteLine(scripture);
                Console.WriteLine("Press enter to hide words or type 'quit' to exit");
            }
        }
    }

    class Scripture
    {
        private string reference;
        private string text;
        private bool[] hiddenWords;

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            this.hiddenWords = new bool[text.Split(' ').Length];
        }

        public bool IsHidden
        {
            get
            {
                foreach (bool isHidden in hiddenWords)
                {
                    if (!isHidden)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void HideWords()
        {
            Random rand = new Random();
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (!hiddenWords[i])
                {
                    if (rand.NextDouble() < 0.5)
                    {
                        hiddenWords[i] = true;
                    }
                }
            }
        }

        public override string ToString()
        {
            string[] words = text.Split(' ');
            string result = reference + ": ";
            for (int i = 0; i < words.Length; i++)
            {
                if (hiddenWords[i])
                {
                    result += "[...] ";
                }
                else
                {
                    result += words[i] + " ";
                }
            }
            return result;
        }
    }
}