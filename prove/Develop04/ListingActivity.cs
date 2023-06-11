class ListingActivity : Activity
{
    private List<string> _prompts;

    private List<string> _items = new List<string>();

    public ListingActivity(int seconds)
        : base("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            seconds)
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void DisplayListing()
    {
        DisplayingStartMessage();

        Console.WriteLine("List as many responses you can to the following prompt:");
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine("--- "+prompt+" ---");

        Console.WriteLine("You may begin in:");
        _items = new List<string>();
        CancellationTokenSource cts = new CancellationTokenSource();
        Task task = Task.Run(() => ReadInputLines(cts.Token));

        TimeSpan tiempoEspera = TimeSpan.FromSeconds(_seconds);
        if (task.Wait(tiempoEspera))
        {}
        else
        {
            cts.Cancel();
        }

        Console.WriteLine($"You listed {_items.Count} items.");

        DisplayingEndMessage();
    }

    public void ReadInputLines(CancellationToken cancellationToken)
    {
        

        while (!cancellationToken.IsCancellationRequested)
        {
            string item = Console.ReadLine();
            _items.Add(item);
        }

    }
}