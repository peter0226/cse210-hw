[Serializable]
public class FictionBook : Book
{
    private string publisher;
    private int MaximumLoanDays=3;

    public FictionBook(string title, string author, string genre, BookStatus status, string publisher) : base(title, author, genre, status)
    {
        this.publisher = publisher;
    }

    public string GetPublisher()
    {
        return publisher;
    }

    public void SetPublisher(string publisher)
    {
        this.publisher = publisher;
    }

    public override double CalculateLateFee(int daysLate)
    {
        double lateFeePerDay = 1.0;
        double totalLateFee = lateFeePerDay * daysLate;
        return totalLateFee;
    }
}
