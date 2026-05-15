using System;

class PromptGenerator
{
    List<string> _prompts = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "What am I most grateful for today?",
        "What is one thing I could have done better today?",
        "What made me smile or laugh today?",
        "What is one goal I want to focus on tomorrow?"
    ];

     public string GetRandomPrompt()
    {
        Random random = new();
        return _prompts[random.Next(_prompts.Count)];
    }
}