using System;

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        Menu menu = new Menu(library);
        menu.ShowMenu();
    }
}