// added a menu option for the user to add multiple scriptures and select which scripture to select for memorization (therefore the program stores multiple scriptures)

using System;

class Program
{
    static List<Scripture> scriptures = new();
    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("Welcome to Scripture Memorizer");
            Console.WriteLine("1. Add a Scripture");
            Console.WriteLine("2. Begin Memorization");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    scriptures.Add(NewScripture());
                    break;
                case "2":
                    if (scriptures.Count == 0)
                    {
                        Console.WriteLine("\n!!!  No scriptures added yet.   !!!\n");
                        break;
                    }
                    Scripture selectedScripture = SelectMemorization();
                    StartMemorization(selectedScripture);
                    break;
                case "3":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
        Console.WriteLine("GoodBye!");
    }
    static Scripture NewScripture()
    {
        Reference reference;

        Console.Write("Enter book name: ");
        string book = Console.ReadLine();

        Console.Write("Enter chapter: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Enter verse: ");
        int verse = int.Parse(Console.ReadLine());

        Console.Write("Enter end verse (or 0 if none): ");
        int endVerse = int.Parse(Console.ReadLine());

        Console.Write("Enter scripture text: ");
        string text = Console.ReadLine();

        if(endVerse > 0)
        {
            reference = new Reference(book, chapter, verse, endVerse);
        } else
        {
            reference = new Reference(book, chapter, verse);
        }

        return new Scripture(reference, text);
    }

    static Scripture SelectMemorization()
    {
        Console.WriteLine("\n=== Select a Scripture ===\n");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceText()}");
        }

        Console.Write("\nChoose a scripture: ");
        int choice = int.Parse(Console.ReadLine()) - 1;

        while (choice < 0 || choice >= scriptures.Count)
        {
            Console.WriteLine("Invalid choice.");
            Console.Write("\nChoose a scripture: ");
            choice = int.Parse(Console.ReadLine()) - 1;
        }

        return scriptures[choice];
    }
    static void StartMemorization(Scripture scripture)
    {
        bool quit = false;
        Console.Clear();
        Console.WriteLine($"\n{scripture.GetReferenceText()}");
        Console.WriteLine($"\n{scripture.GetDisplayText()}\n");
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();
        
        quit = input.ToLower() == "quit";
    
        while (!quit)
        {
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words have been hidden. You have memorized this scripture!\n");
                scripture.ResetHiddenWords();
                break;
            }
            Console.Clear();
            Random random = new Random();
            int countHidden = random.Next(2, 4);
            scripture.HideRandomWords(countHidden);
            Console.WriteLine(scripture.GetDisplayText());    
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
            quit = input.ToLower() == "quit";
        }
        scripture.ResetHiddenWords();
        return;
    }
}