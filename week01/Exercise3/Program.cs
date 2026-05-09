using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        int guess;
        Console.WriteLine("Welcome to Guess the Magic Number! ");
        do
        {
            Console.Write("What is your guess? ");
            string inputGuess = Console.ReadLine();
            guess = int.Parse(inputGuess);
            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if(guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
        } while (guess != magicNumber);
        Console.WriteLine("You guessed it!!");

    }
}