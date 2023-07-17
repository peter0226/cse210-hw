[Serializable]
public class NonFictionBook : Book
{
    private string topic;
    private int MaximumLoanDays=7;

    public NonFictionBook(string title, string author, string genre, BookStatus status, string topic) : base(title, author, genre, status)
    {
        this.topic = topic;
    }

    public string GetTopic()
    {
        return topic;
    }

    public void SetTopic(string topic)
    {
        this.topic = topic;
    }

    public override double CalculateLateFee(int daysLate)
    {
        double lateFeePerDay = 0.5; 
        double totalLateFee = lateFeePerDay * daysLate;
        return totalLateFee;
    }
}
