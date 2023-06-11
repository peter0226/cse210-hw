class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity(int seconds)
        : base("Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            seconds)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void DisplayReflection()
    {
        DisplayingStartMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine("--- "+prompt+" ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.\n");


        DateTime startTime = DateTime.Now;
        TimeSpan elapsedTime = TimeSpan.Zero;

        foreach (string question in _questions)
        {
            Console.WriteLine(question);
            PauseSpinner();

            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }

                elapsedTime = DateTime.Now - startTime;

                if (elapsedTime.TotalSeconds >= _seconds)
                {
                    Console.WriteLine();
                    return;
                }
            }

        }
        DisplayingEndMessage();
    }
}
