using System;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying = "yes";
        int guess = 0;

        while (keepPlaying == "yes")
        {
            guess = 0;

            Console.Write("What is the magic number? ");
            int magicNumber = int.Parse(Console.ReadLine());

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }

                else if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }

                else 
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.Write("Do you wish to play again? ");
            keepPlaying = Console.ReadLine();

        }
    }
}