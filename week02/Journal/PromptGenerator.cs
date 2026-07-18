using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see God working in my life today?",
            "What was the hardest part of my day?",
            "What did I learn today?"
        };
    }

    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0)
        {
            return "";
        }

        var rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}
