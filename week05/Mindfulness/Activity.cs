abstract class Activity(string title, string description)
{
    private string _title = title;
    private string _description = description;
    private int _duration;
 
    protected int Duration => _duration;

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_title} ===\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long would you like the activity to last (in seconds)? ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number: ");
        }
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_title} activity for {_duration} seconds.");
        ShowSpinner(3);
    }
    protected void ShowSpinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        int totalFrames = seconds * 10;
        for (int i = 0; i < totalFrames; i++)
        {
            Console.Write($"\r{frames[i % frames.Length]} ");
            Thread.Sleep(100);
        }
        Console.Write("\r  \r");
    }
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}  ");
            Thread.Sleep(1000);
        }
        Console.Write("\r   \r");
    }
    public abstract void Run();
}