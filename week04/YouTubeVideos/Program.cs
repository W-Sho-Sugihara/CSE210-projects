using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = [];

        Video v1 = new("C# Tutorial", "CodeWithMosh", 600);
        v1.AddComment("Alice", "Great tutorial, very clear!");
        v1.AddComment("Bob", "Helped me understand OOP finally.");
        v1.AddComment("Carol", "Could you make one on interfaces?");

        Video v2 = new("10 C# Tips", "IAmTimCorey", 480);
        v2.AddComment("Dave", "Tip #5 blew my mind.");
        v2.AddComment("Eve", "Short and straight to the point.");
        v2.AddComment("Frank", "Using this in my project right now!");

        Video v3 = new("Async Await Explained", "NickChapsas", 720);
        v3.AddComment("Grace", "Finally understand async!");
        v3.AddComment("Heidi", "Best explanation on YouTube.");
        v3.AddComment("Ivan", "The examples were super helpful.");

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (var video in videos)
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Title:     {video.GetVideoTitle()}");
            Console.WriteLine($"Author:    {video.GetVideoAuthor()}");
            Console.WriteLine($"Length:    {video.GetVideoLength()} seconds");
            Console.WriteLine($"Comments:  {video.GetVideoCommentCount()}");
            Console.WriteLine("---------------------------------");
            video.DisplayAllComments();
        }
    }
}