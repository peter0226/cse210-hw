public class User
{
    private string name;
    private List<Book> borrowedBooks;
    private List<Loan> loans;

    public User(string name)
    {
        this.name = name;
        this.borrowedBooks = new List<Book>();
        this.loans = new List<Loan>();
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public List<Book> GetBorrowedBooks()
    {
        return borrowedBooks;
    }

    public bool LoanBook(Book book)
    {
        if (book.GetStatus() == BookStatus.Available)
        {
            book.SetStatus(BookStatus.OnLoan);
            borrowedBooks.Add(book);

            Loan loan = new Loan(book, this);
            loans.Add(loan);

            return true;
        }

        return false;
    }

    public bool ReturnBook(Book book)
    {
        if (book.GetStatus() == BookStatus.OnLoan && borrowedBooks.Contains(book))
        {
            book.SetStatus(BookStatus.Available);
            borrowedBooks.Remove(book);
            return true;
        }

        return false;
    }

    public bool HasBorrowedBook(Book book)
    {
        return borrowedBooks.Contains(book);
    }

    public double CalculateTotalLateFees()
    {
        double totalLateFees = 0;
        foreach (var loan in loans)
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
