public class User
{
    private string _name;
    private List<Book> _borrowedBooks;
    private List<Loan> _loans;

    public User(string name)
    {
        this._name = name;
        this._borrowedBooks = new List<Book>();
        this._loans = new List<Loan>();
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        this._name = name;
    }

    public List<Book> GetBorrowedBooks()
    {
        return _borrowedBooks;
    }

    public bool LoanBook(Book book)
    {
        if (book.GetStatus() == BookStatus.Available)
        {
            book.SetStatus(BookStatus.OnLoan);
            _borrowedBooks.Add(book);

            Loan loan = new Loan(book, this);
            _loans.Add(loan);

            return true;
        }

        return false;
    }

    public bool ReturnBook(Book book)
    {
        if (book.GetStatus() == BookStatus.OnLoan && _borrowedBooks.Contains(book))
        {
            book.SetStatus(BookStatus.Available);
            _borrowedBooks.Remove(book);
            return true;
        }

        return false;
    }

    public bool HasBorrowedBook(Book book)
    {
        return _borrowedBooks.Contains(book);
    }

    public double CalculateTotalLateFees()
    {
        double totalLateFees = 0;
        foreach (var loan in _loans)
        {
            int daysLate = loan.GetDaysLate();
            double lateFee = loan.GetBook().CalculateLateFee(daysLate);
            totalLateFees += lateFee;
        }
        return totalLateFees;
    }

    public void MakePayment()
    {
        double totalLateFees = CalculateTotalLateFees();
        if (totalLateFees > 0)
        {
            Console.WriteLine($"Total Late Fees to Pay: {totalLateFees:C}");
            Console.WriteLine("Select Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Cash");
            Console.WriteLine("3. PayPal");
            Console.WriteLine("4. Wire Transfer");

            int option = ReadOption();
            PaymentMethod paymentMethod = GetPaymentMethod(option);

            if (paymentMethod != null)
            {
                paymentMethod.MakePayment(totalLateFees);
                
            }
            else
            {
                Console.WriteLine("Invalid payment method selected.");
            }
        }
        else
        {
            Console.WriteLine("No late fees to pay.");
        }
    }

    private PaymentMethod GetPaymentMethod(int option)
    {
        switch (option)
        {
            case 1:
                return new CreditCardPayment();
            case 2:
                return new CashPayment();
            case 3:
                return new PayPalPayment();
            case 4:
                return new WireTransferPayment();

            default:
                return null;
        }
    }

    public int ReadOption()
    {
        Console.Write("Enter your option: ");
        return Convert.ToInt32(Console.ReadLine());
    }
}
