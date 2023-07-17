public class Loan
{
    private Book _book;
    private User _user;
    private DateTime _loanDate;
    private DateTime _returnDate;

    private DateTime _dueDate { get; }

    public Loan(Book book, User user)
    {
        this._book = book;
        this._user = user;
        this._loanDate = DateTime.Now;
        this._dueDate = DateTime.Now.AddDays(book.GetMaximumLoanDays());
    }

    public int GetDaysLate()
    {
        int daysLate = (int)Math.Max((DateTime.Now - this._dueDate).TotalDays, 0);
        //By default, it is 3 days late for testing.
        return 3;
        //return daysLate;
    }

    public Book GetBook()
    {
        return _book;
    }

    public User GetUser()
    {
        return _user;
    }

    public DateTime GetLoanDate()
    {
        return _loanDate;
    }

    public DateTime GetReturnDate()
    {
        return _returnDate;
    }
}
