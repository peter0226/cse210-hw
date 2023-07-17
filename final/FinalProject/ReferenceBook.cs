[Serializable]
public class ReferenceBook : Book
{
    private int edition;
    private int MaximumLoanDays=6;

    public ReferenceBook(string title, string author, string genre, BookStatus status, int edition) : base(title, author, genre, status)
    {
        this.edition = edition;
    }

    public int GetEdition()
    {
        return edition;
    }

    public void SetEdition(int edition)
    {
        this.edition = edition;
    }

    public override double CalculateLateFee(int daysLate)
    {
        return 0;
    }
}
