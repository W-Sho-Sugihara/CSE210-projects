using System;

class Program
{
    static void Main(string[] args)
    {
        int number;
        List<int> numbers = new List<int>();
        do
        {
            Console.Write("Enter a number. ");
            number = int.Parse(Console.ReadLine());
            if(number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int total = numbers.Sum();
        float average = ((float)total) / numbers.Count;
        int max = numbers.Max();
        int min = numbers.Min();
        Console.WriteLine($"Total is {total}");
        Console.WriteLine($"Average is {average}");
        Console.WriteLine($"Max number is {max}");
        Console.WriteLine($"Min number is {min}");
    }
}