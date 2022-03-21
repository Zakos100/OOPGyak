using System;

namespace _4_Book
{
    class BookProgram
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            //book.SetAuthor("Stephen Hawking");
            //book.SetTitle("Black Holes");
            //book.SetYearOfPublication(1971);
            //book.SetPrice(3290);

            book.Author = "Stephen Hawking";
            book.Title = "Black Holes";
            book.YearOfPublication = 1971;
            book.Price = 3290;

            Console.WriteLine(book.DisplayInformation());
            book.IncreasePrice(10);
            Console.WriteLine(book.DisplayInformation());
        }
    }
}