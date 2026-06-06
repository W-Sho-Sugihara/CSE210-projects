using System.Diagnostics;

class Listing(string title, string description) : Activity(title, description)
{
    private List<string> _prompts =
        [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];
        public override void Run()
        {
            DisplayStartingMessage();
            Console.Clear();
            Random rand = new();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine($"\n--- List Prompt ---\n{prompt}\n");
            Console.WriteLine("You have a few seconds to think before you start listing...");
            ShowCountdown(5);
 
            Console.WriteLine("\nStart listing items (press Enter after each one):");
 
            List<string> items = [];
            Stopwatch sw = Stopwatch.StartNew();
 
            while (sw.Elapsed.TotalSeconds < Duration)
            {
                Console.Write($"  > ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input.Trim());
            }
 
            Console.WriteLine($"\nYou listed {items.Count} item{(items.Count == 1 ? "" : "s")}!");
            DisplayEndingMessage();
        }
}