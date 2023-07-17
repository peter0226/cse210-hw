using System;

public class Menu
{
    private Library _library;
    private LibraryFile _libraryFile;

    public Menu(Library library, LibraryFile libraryFile)
    {
        this._library = library;
        this._libraryFile = libraryFile;
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
            Console.WriteLine("5. Display Borrowed Books By User");
            Console.WriteLine("6. Calculate Late Fee");
            Console.WriteLine("7. Save Books to File");
            Console.WriteLine("8. Load Books from File");
            Console.WriteLine("9. List Books");
            Console.WriteLine("10. Create User");
            Console.WriteLine("11. Show Users");
            Console.WriteLine("12. Pay Late Fees");
            Console.WriteLine("13. Exit");

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
                    DisplayBorrowedBooksByUser();
                    break;
                case 6:
                    CalculateLateFee();
                    break;
                case 7:
                    SaveBooksToFile();
                    break;
                case 8:
                    LoadBooksFromFile();
                    break;
                case 9:
                    _library.ListAllBooks();
                    break;
                case 10:
                    CreateUser();
                    break;
                case 11:
                    ShowUsers();
                    break;
                case 12:
                    PayLateFees();
                    break;
                case 13:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void ReturnBook(){
        Console.Write("Enter the title of the book to return: ");
        string title = Console.ReadLine();

        List<Book> foundBooks = _library.SearchBookByTitle(title);

        if (foundBooks.Count == 0)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        Book selectedBook;
        if (foundBooks.Count > 1)
        {
            // If multiple books with similar titles are found, let the user choose one.
            Console.WriteLine("Multiple books found with similar titles. Please select one:");
            int i = 1;
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"{i}. {book.GetTitle()}");
                i++;
            }

            int selectedIndex;
            do
            {
                Console.Write("Enter the number of the book to return: ");
            } while (!int.TryParse(Console.ReadLine(), out selectedIndex) || selectedIndex < 1 || selectedIndex > foundBooks.Count);

            selectedBook = foundBooks[selectedIndex - 1];
            }
            else
            {
                selectedBook = foundBooks[0];
            }

            Console.Write("Enter the user's name: ");
            string userName = Console.ReadLine();

            User user = _library.SearchUserByName(userName);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            bool bookReturned = _library.ReturnBook(selectedBook, user);

            if (bookReturned)
            {
                Console.WriteLine("Book returned successfully!");
            }
                else
            {
                Console.WriteLine("Book cannot be returned. It is not borrowed by the given user.");
            }
    }

    private void PayLateFees()
    {
        Console.Write("Enter the user's name: ");
        string userName = Console.ReadLine();

        User user = _library.SearchUserByName(userName);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.MakePayment();
    }

    public void ShowUsers()
    {
        var users = _library.GetUsers();

        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
        }
        else
        {
            Console.WriteLine("==== Users ====");
            foreach (var user in users)
            {
                Console.WriteLine($"User Name: {user.GetName()}");

                var borrowedBooks = user.GetBorrowedBooks();
                if (borrowedBooks.Count == 0)
                {
                    Console.WriteLine("  - No books borrowed.");
                }
                else
                {
                    Console.WriteLine("  - Borrowed Books:");
                    foreach (var book in borrowedBooks)
                    {
                        Console.WriteLine($"    - {book.GetTitle()}, Status: {book.GetStatus()}");
                    }
                }
            }
        }
    }

    public void CreateUser()
    {
        Console.Write("Enter the name of the user: ");
        string userName = Console.ReadLine();

        User existingUser = _library.SearchUserByName(userName);
        if (existingUser != null)
        {
            Console.WriteLine("User already exists.");
            return;
        }

        User newUser = new User(userName);
        _library.AddUser(newUser);
        Console.WriteLine("User created successfully!");
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

        BookStatus status;
        do
        {
            Console.WriteLine("Available status options:");
            foreach (BookStatus value in Enum.GetValues(typeof(BookStatus)))
            {
                Console.WriteLine($"{(int)value}. {value}");
            }

            Console.Write("Enter the status of the book (1. Available, 2. OnLoan, 3. Reserved, 4. Lost, 5. Damaged): ");
        }
        while (!Enum.TryParse(Console.ReadLine(), out status) || !Enum.IsDefined(typeof(BookStatus), status));

        int bookType;
        do
        {
            Console.Write("Enter the book type (1. Fiction, 2. Non-Fiction, 3. Reference): ");
        }
        while (!int.TryParse(Console.ReadLine(), out bookType) || bookType < 1 || bookType > 3);

        Book book;

        switch (bookType)
        {
            case 1:
                Console.Write("Enter the publisher of the book (for FictionBook): ");
                string publisher = Console.ReadLine();
                book = new FictionBook(title, author, genre, status, publisher);
                break;
            case 2:
                Console.Write("Enter the topic of the book (for NonFictionBook): ");
                string topic = Console.ReadLine();
                book = new NonFictionBook(title, author, genre, status, topic);
                break;
            case 3:
                int edition;
                do
                {
                    Console.Write("Enter the edition of the book (for ReferenceBook): ");
                }
                while (!int.TryParse(Console.ReadLine(), out edition) || edition < 1);

                book = new ReferenceBook(title, author, genre, status, edition);
                break;
            default:
                Console.WriteLine("Invalid book type.");
                return;
        }

        _library.AddBook(book);
        Console.WriteLine("Book added successfully!");

        // Display additional properties of the book type
        if (book is FictionBook fictionBook)
        {
            Console.WriteLine($"Publisher: {fictionBook.GetPublisher()}");
        }
        else if (book is NonFictionBook nonFictionBook)
        {
            Console.WriteLine($"Topic: {nonFictionBook.GetTopic()}");
        }
        else if (book is ReferenceBook referenceBook)
        {
            Console.WriteLine($"Edition: {referenceBook.GetEdition()}");
        }
    }

    public void SearchBook()
    {
        Console.WriteLine("==== Search Book ====");
        Console.WriteLine("1. Search by Title");
        Console.WriteLine("2. Search by Author");
        Console.WriteLine("3. Search by Genre");
        Console.WriteLine("4. Back");

        int option = ReadOption();

        switch (option)
        {
            case 1:
                Console.Write("Enter the title to search: ");
                string title = Console.ReadLine();
                var booksByTitle = _library.SearchBookByTitle(title);
                DisplayBooks(booksByTitle);
                break;
            case 2:
                Console.Write("Enter the author to search: ");
                string author = Console.ReadLine();
                var booksByAuthor = _library.SearchBookByAuthor(author);
                DisplayBooks(booksByAuthor);
                break;
            case 3:
                Console.Write("Enter the genre to search: ");
                string genre = Console.ReadLine();
                var booksByGenre = _library.SearchBookByGenre(genre);
                DisplayBooks(booksByGenre);
                break;
            case 4:
                // Go back to the main menu
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    public void LoanBook()
    {
        Console.WriteLine("==== Loan Book ====");
        Console.Write("Enter the title of the book to loan: ");
        string title = Console.ReadLine();

        var books = _library.SearchBookByTitle(title);

        if (books.Count == 0)
        {
            Console.WriteLine("No book with the given title found.");
        }
        else if (books.Count == 1)
        {
            Book book = books[0];

            if(book.GetStatus() == BookStatus.Available)
            {
                Console.Write("Enter the user's name: ");
                string userName = Console.ReadLine();

                //User user = new User(userName);
                User user = _library.SearchUserByName(userName);

                bool loanSuccess = _library.LoanBook(book, user);

                if (loanSuccess)
                {
                    Console.WriteLine("Book loaned successfully!");
                }
                else
                {
                    Console.WriteLine("Book is already on loan.");
                }
            }
            else
            {
                Console.WriteLine("Book is not available for loan.");
            }
        }
        else
        {
            Console.WriteLine("Multiple books found with the given title. Please refine your search.");
        }
    }

    public bool ReturnBook(Book book, User user)
    {
        if (book.GetStatus() != BookStatus.OnLoan || !user.HasBorrowedBook(book))
        {
            Console.WriteLine("Book cannot be returned. It is not borrowed by the given user.");
            return false;
        }

        book.SetStatus(BookStatus.Available);
        user.ReturnBook(book);
        Console.WriteLine("Book returned successfully!");
        return true;
    }
    private void DisplayBooks(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books found.");
        }
        else
        {
            Console.WriteLine("==== Books Found ====");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.GetTitle()}");
                Console.WriteLine($"Author: {book.GetAuthor()}");
                Console.WriteLine($"Genre: {book.GetGenre()}");
                Console.WriteLine($"Status: {book.GetStatus()}");
                Console.WriteLine();
            }
        }
    }

    public void DisplayBorrowedBooksByUser()
{
    Console.WriteLine("==== Display Borrowed Books By User ====");
    Console.Write("Enter the user's name: ");
    string userName = Console.ReadLine();

    User user = _library.SearchUserByName(userName);

    if (user == null)
    {
        Console.WriteLine("User not found.");
        return;
    }

    Console.WriteLine($"Books borrowed by '{user.GetName()}':");
    List<Book> borrowedBooks = user.GetBorrowedBooks();

    if (borrowedBooks.Count == 0)
    {
        Console.WriteLine("No books borrowed by this user.");
    }
    else
    {
        foreach (Book book in borrowedBooks)
        {
            Console.WriteLine($"Title: {book.GetTitle()}, Status: {book.GetStatus()}");
        }
    }
}

    public void CalculateLateFee()
    {
        Console.WriteLine("==== Calculate Late Fee ====");
        Console.Write("Enter the number of days late: ");
        int daysLate = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the book title: ");
        string bookTitle = Console.ReadLine();

        List<Book> foundBooks = _library.SearchBookByTitle(bookTitle);

        if (foundBooks.Count == 0)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        
        Book book = foundBooks[0];

        double lateFee = book.CalculateLateFee(daysLate);
        Console.WriteLine($"Late fee for {daysLate} days late for book '{book.GetTitle()}': {lateFee:C}");
    }

     public void SaveBooksToFile()
    {
        _libraryFile.SaveBooks(_library.GetBooks());
        Console.WriteLine("Books saved to file successfully!");
    }

    public void LoadBooksFromFile()
    {
        _library.SetBooks(_libraryFile.LoadBooks());
        Console.WriteLine("Books loaded from file successfully!");
    }
}
