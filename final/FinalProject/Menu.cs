public class Menu
{
    private Library library;

    public Menu(Library library)
    {
        this.library = library;
    }

    public void ShowMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("==== Library Menu ====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Search Book");
            Console.WriteLine("3. Loan Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Exit");

            int option = ReadOption();

            switch (option)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    SearchBook();
                    break;
                case 3:
                    LoanBook();
                    break;
                case 4:
                    ReturnBook();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public int ReadOption()
    {
        Console.Write("Enter your option: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    public void AddBook()
    {
        Console.Write("Enter the title of the book: ");
        string title = Console.ReadLine();

        Console.Write("Enter the author of the book: ");
        string author = Console.ReadLine();

        Console.Write("Enter the genre of the book: ");
        string genre = Console.ReadLine();

        Console.Write("Enter the status of the book: ");
        string status = Console.ReadLine();

        // Additional properties specific to the book type
        Console.Write("Enter the publisher of the book (for FictionBook): ");
        string publisher = Console.ReadLine();

        Console.Write("Enter the topic of the book (for NonFictionBook): ");
        string topic = Console.ReadLine();

        Console.Write("Enter the edition of the book (for ReferenceBook): ");
        int edition = Convert.ToInt32(Console.ReadLine());

        // Determine the book type based on user input
        Console.Write("Enter the book type (1. Fiction, 2. Non-Fiction, 3. Reference): ");
        int bookType = Convert.ToInt32(Console.ReadLine());

        Book book;

        switch (bookType)
        {
            case 1:
                book = new FictionBook(title, author, genre, status, publisher);
                break;
            case 2:
                book = new NonFictionBook(title, author, genre, status, topic);
                break;
            case 3:
                book = new ReferenceBook(title, author, genre, status, edition);
                break;
            default:
                Console.WriteLine("Invalid book type.");
                return;
        }

        library.AddBook(book);
        Console.WriteLine("Book added successfully!");
    }

    public void SearchBook()
    {
        // Implementation for searching books by title, author, or genre
    }

    public void LoanBook()
    {
        // Implementation for loaning a book to a user
    }

    public void ReturnBook()
    {
        // Implementation for returning a book borrowed by a user
    }
}