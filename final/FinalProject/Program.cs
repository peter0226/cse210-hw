using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        LibraryFile libraryFile = new LibraryFile("librarydata.csv");

        Menu menu = new Menu(library, libraryFile);
        menu.ShowMenu();
    }
}