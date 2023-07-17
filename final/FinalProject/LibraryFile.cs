using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class LibraryFile
{
    private string _filePath;

    public LibraryFile(string filePath)
    {
        this._filePath = filePath;
    }

public void SaveBooks(List<Book> books)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                foreach (Book book in books)
                {
                    string line = $"{book.GetType().Name},{book.GetTitle()},{book.GetAuthor()},{book.GetGenre()},{book.GetStatus()}";
                    if (book is FictionBook fictionBook)
                    {
                        line += $",{fictionBook.GetPublisher()}";
                    }
                    else if (book is NonFictionBook nonFictionBook)
                    {
                        line += $",{nonFictionBook.GetTopic()}";
                    }
                    else if (book is ReferenceBook referenceBook)
                    {
                        line += $",{referenceBook.GetEdition()}";
                    }

                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Books saved to file successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving books to file: {ex.Message}");
        }
    }

    public List<Book> LoadBooks()
    {
        List<Book> books = new List<Book>();

        try
        {
            if (!File.Exists(_filePath))
            {
                return books;
            }

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string bookType = parts[0];
                    string title = parts[1];
                    string author = parts[2];
                    string genre = parts[3];

                    if (!Enum.TryParse(parts[4], out BookStatus status))
                    {
                        Console.WriteLine($"Invalid book status: {parts[4]}");
                        continue;
                    }

                    Book book;
                    switch (bookType)
                    {
                        case nameof(FictionBook):
                            string publisher = parts[5];
                            book = new FictionBook(title, author, genre, status, publisher);
                            break;
                        case nameof(NonFictionBook):
                            string topic = parts[5];
                            book = new NonFictionBook(title, author, genre, status, topic);
                            break;
                        case nameof(ReferenceBook):
                            if (!int.TryParse(parts[5], out int edition))
                            {
                                Console.WriteLine($"Invalid edition for the reference book: {parts[5]}");
                                continue;
                            }
                            book = new ReferenceBook(title, author, genre, status, edition);
                            break;
                        default:
                            Console.WriteLine($"Invalid book type: {bookType}");
                            continue;
                    }

                    books.Add(book);
                }
            }

            Console.WriteLine("Books loaded from file successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading books from file: {ex.Message}");
        }

        return books;
    }

}
