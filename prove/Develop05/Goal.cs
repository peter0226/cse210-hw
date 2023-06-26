abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int RecordEvent(){
        return 0;
    }

    public virtual string Serialize()
    {
        // Implementación de la serialización en la clase base Goal
        return string.Empty;
    }

    public virtual void Deserialize(){}

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual int GetCompletionCount(){
        return -1;
    }

    public virtual int GetTargetCount(){
        return 0;
    }

    public virtual void Save()
    {
    }

    public virtual void Load(){}

    //public abstract string Serialize();
    
    
}
