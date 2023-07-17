public class ReferenceBook : Book
{
    private int _edition;
    private int _maximumLoanDays=6;

    public ReferenceBook(string title, string author, string genre, BookStatus status, int edition) : base(title, author, genre, status)
    {
        this._edition = edition;
    }

    public int GetEdition()
    {
        return _edition;
    }

    public void SetEdition(int edition)
    {
        this._edition = edition;
    }

    public override double CalculateLateFee(int daysLate)
    {
        return 0;
    }
}
