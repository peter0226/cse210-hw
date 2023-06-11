class Activity
{
    private string _activityName;
    private string _description;
    private string _startingMessage;
    private string _endingMessage;
    protected int _seconds;
    private List<string> _animationStrings;

    public Activity(string activityName, string description, int seconds)
    {
        _activityName = activityName;
        _description = description;
        _startingMessage = "Get ready ...";
        _endingMessage = "Well done!!";
        _seconds = seconds;
        _animationStrings = new List<string> { "|", "/", "-", "\\" };
    }

    public void DisplayingStartMessage()
    {
        Console.WriteLine(_activityName);
        Console.WriteLine(_description);

        Console.Write("How long, in seconds, would you like for your session?");
        _seconds = Convert.ToInt32(Console.ReadLine());

        Console.Clear();
        Console.WriteLine(_startingMessage);
        PauseSpinner();
    }

    public void DisplayingEndMessage()
    {
        Console.WriteLine(_endingMessage);
        Thread.Sleep(2000);

        string message = $"You have completed another {_seconds} seconds of the {_activityName}.";
        Console.WriteLine(message);
        PauseSpinner();
        Console.Clear();
    }

    public void PauseSpinner()
    {
        for (int i = 0; i < 4; i++)
        {
            Console.Write("\r{0}", _animationStrings[i % _animationStrings.Count]);
            Thread.Sleep(1000);
        }
        Console.Write("\b \b");
        Console.WriteLine();
    }

    public void PauseCountTimer()
    {
        for (int i = _seconds; i > 0; i--)
        {
            Console.Write("\r{0:00}", i);
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}