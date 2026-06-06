using System.Diagnostics;

class Reflection(string title, string description) : Activity(title, description)
{
    private List<string> _prompts =
    [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];

    private List<string> _questions =
    [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    public override void Run()
        {
            DisplayStartingMessage();
 
            Random rand = new();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.Clear();
            Console.WriteLine($"\n--- Prompt ---\n{prompt}\n");
            ShowSpinner(10);
            Console.WriteLine("Reflect on the following questions. Take your time.\n");
 
            List<string> shuffled = [.. _questions];
            Stopwatch sw = Stopwatch.StartNew();
 
            int qi = 0;
            while (sw.Elapsed.TotalSeconds < Duration)
            {
                // using a  Fisher-Yates shuffle to randomize the questions
                if (qi == 0)
                {
                    for (int i = shuffled.Count - 1; i > 0; i--)
                    {
                        int j = rand.Next(i + 1);
                    (shuffled[j], shuffled[i]) = (shuffled[i], shuffled[j]);
                }
            }
 
                Console.Write($"\n> {shuffled[qi]}  ");
                int remaining = (int)(Duration - sw.Elapsed.TotalSeconds);
                int pauseTime = Math.Min(8, remaining);
                if (pauseTime <= 0) break;
                if (pauseTime > 0)
                    ShowSpinner(pauseTime);
 
                qi = (qi + 1) % shuffled.Count;
            }
 
            DisplayEndingMessage();
        }
}