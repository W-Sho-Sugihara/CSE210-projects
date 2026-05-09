using System;

class Program
{
    static void Main(string[] args)
    {
    
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = SquareNumber(number);
        DisplayResult(name, squared);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squared)
    {
        Console.WriteLine($"{name}, your number squared is {squared}.");
    }  
}