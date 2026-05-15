using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Journal Menu ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Edit an entry");
            Console.WriteLine("4. Delete an entry");
            Console.WriteLine("5. Save journal to file");
            Console.WriteLine("6. Load journal from file");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    journal.AddEntry(date, prompt, response);
                    Console.WriteLine("Entry saved!");
                    break;

                case "2":
                    Console.WriteLine("\n=== Journal Entries ===");
                    journal.DisplayAll();
                    break;

                case "3":
                    journal.DisplayAll();
                    Console.Write("Enter entry number to edit: ");
                    int editNumber = int.Parse(Console.ReadLine());
                    Console.Write("New response: ");
                    string newText = Console.ReadLine();
                    journal.EditEntry(editNumber, newText);
                    Console.WriteLine("Entry updated!");
                    break;

                case "4":
                    journal.DisplayAll();
                    Console.Write("Enter entry number to delete: ");
                    int deleteNumber = int.Parse(Console.ReadLine());
                    journal.DeleteEntry(deleteNumber);
                    Console.WriteLine("Entry deleted!");
                    break;

                case "5":
                    Console.Write("Enter filename to save to: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved!");
                    break;

                case "6":
                    Console.Write("Enter filename to load from: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded!");
                    break;

                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}