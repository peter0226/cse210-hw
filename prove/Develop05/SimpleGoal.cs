class SimpleGoal : Goal
{
    private bool _status=false;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {

    }

    public SimpleGoal(string name, string description, int points, bool status)
        : base(name, description, points)
    {
        _status=status;
    }

    public override int RecordEvent()
    {
        if(_status==true){
            Console.WriteLine("This task is already completed");
            return 0;
        }else{
            _status=true;
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _status;
    }

    public static SimpleGoal Create()
    {
        Console.Write("What is the name of your goal?");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it?");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        return new SimpleGoal(name, description, points);
    }

    public override string Serialize()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_status}";
    }

    public static SimpleGoal Deserialize(string[] data)
    {
        string name = data[1];
        string description = data[2];
        int points = int.Parse(data[3]);
        bool status = bool.Parse(data[4]);
        
        return new SimpleGoal(name,description,points,status);
        
    }

    

    
}
