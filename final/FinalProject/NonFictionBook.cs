public class NonFictionBook : Book
{
    private string _topic;
    private int _maximumLoanDays=7;

    public NonFictionBook(string title, string author, string genre, BookStatus status, string topic) : base(title, author, genre, status)
    {
        this._topic = topic;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public void SetTopic(string topic)
    {
        this._topic = topic;
    }

    public override double CalculateLateFee(int daysLate)
    {
        double lateFeePerDay = 0.5; 
        double totalLateFee = lateFeePerDay * daysLate;
        return totalLateFee;
    }
}
