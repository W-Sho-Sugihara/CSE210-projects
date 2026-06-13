// added a user score history option to see progress with dates and scores
// each goal is saves in its own goal type txt file for easier filtering and separating file loading functionality

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new();
        goalManager.Start();
    }
}