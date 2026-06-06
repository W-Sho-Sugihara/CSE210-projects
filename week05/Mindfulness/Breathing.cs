using System.Diagnostics;

class Breathing(string title, string description) : Activity(title, description)
{
    public override void Run()
        {
            DisplayStartingMessage();
 
            Stopwatch sw = Stopwatch.StartNew();
            bool breathIn = true;
 
            while (sw.Elapsed.TotalSeconds < Duration)
            {
                if (breathIn)
                {
                    Console.WriteLine("Breath in...");
                }
                else
                {
                    Console.WriteLine("Breath out...");
                }
 
                int remaining = (int)(Duration - sw.Elapsed.TotalSeconds);
                int pauseTime = Math.Min(5, remaining);
                if (pauseTime > 0)
                {
                    ShowCountdown(pauseTime);
                };
                if (pauseTime <= 0) break;
                breathIn = !breathIn;
            }
 
            DisplayEndingMessage();
        }

}