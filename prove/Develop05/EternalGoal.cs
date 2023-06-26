class EternalGoal : Goal
{
    private int _rewardPoints;
    public string Title { get; set; }
    public bool IsAchieved { get; set; }

    


    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public EternalGoal()
        : base("", "", 0)
    {
    }

    // Constructor sin parámetros
    
    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public static EternalGoal Create()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        return new EternalGoal(name, description, points);
    }

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }

    public static EternalGoal Deserialize(string[] data)
    {
        string name = data[1];
        string description = data[2];
        int points = int.Parse(data[3]);
        
        return new EternalGoal(name,description,points);
        
    }
    
}
