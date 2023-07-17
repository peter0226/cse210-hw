public class FictionBook : Book
{
    private string _publisher;
    private int _maximumLoanDays=3;

    public FictionBook(string title, string author, string genre, BookStatus status, string publisher) : base(title, author, genre, status)
    {
        this._publisher = publisher;
    }

    public string GetPublisher()
    {
        return _publisher;
    }

    public void SetPublisher(string publisher)
    {
        this._publisher = publisher;
    }

    public override double CalculateLateFee(int daysLate)
    {
        double lateFeePerDay = 1.0;
        double totalLateFee = lateFeePerDay * daysLate;
        return totalLateFee;
    }
}
