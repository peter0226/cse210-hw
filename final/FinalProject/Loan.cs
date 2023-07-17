public class Loan
{
    private Book book;
    private User user;
    private DateTime loanDate;
    private DateTime returnDate;

    private DateTime dueDate { get; }

    public Loan(Book book, User user)
    {
        this.book = book;
        this.user = user;
        this.loanDate = DateTime.Now;
        this.dueDate = DateTime.Now.AddDays(book.GetMaximumLoanDays());
    }

    public int GetDaysLate()
    {
        int daysLate = (int)Math.Max((DateTime.Now - this.dueDate).TotalDays, 0);
        //By default, it is 3 days late for testing.
        return 3;
        //return daysLate;
    }

    public Book GetBook()
    {
        return book;
    }

    public User GetUser()
    {
        return user;
    }

    public DateTime GetLoanDate()
    {
        return loanDate;
    }

    public DateTime GetReturnDate()
    {
        return returnDate;
    }
}
