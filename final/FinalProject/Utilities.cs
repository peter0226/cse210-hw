public class Utilities
{
    public string FormatDate(DateTime date)
    {
        return date.ToString("dd/MM/yyyy");
    }

    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }
}
