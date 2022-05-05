using System;

namespace book
{
    class Program
    {
        static void Main(string[] args)
        {
            int beolvasott = ReadInteger();
            Book[] konyvek = new Book[beolvasott];
            Console.WriteLine("Formátum: szerzo; cim; ar; oldalszam");
            for (int i = 0; i < beolvasott; i++)
            {
                Console.WriteLine("Add meg a(z) " + (i + 1) + ". könyvet!");
                string line = Console.ReadLine();
                string[] peldany = line.Split("; ");
                while (peldany.Length != 4)
                {
                    Console.WriteLine("Hibás formátum, próbáld újra!");
                    line = Console.ReadLine();
                    peldany = line.Split("; ");
                }
                konyvek[i] = new Book(peldany[0], peldany[1], Convert.ToInt32(peldany[2]), Convert.ToInt32(peldany[3]));
            }

            Book.ListBookArray(konyvek);

            Console.WriteLine("Leghosszabb könyv: " + Book.GetLongestBook(konyvek).ToString());

            Console.WriteLine("Leghosszabb páros oldalsz. könyv: " + Book.GetLongestEvenPagesBook(konyvek).ToString());

            Book.AuthorStatistics(konyvek);

            /*
            Book book = new Book("Robert C. Martin", "Clean Code", 2008, 8500);

            //book.SetAuthor("Robert C. Martin");
            //book.SetTitle("Clean Code: A Handbook of Agile Software Craftsmanship");
            //book.SetYearOfPublication(2008);
            //book.SetPrice(8500);

            //book.Author = "Robert C. Martin";
            //book.Title = "Clean Code: A Handbook of Agile Software Craftsmanship";
            //book.YearOfPublication = 2008;
            //book.Price = 8500;

            Console.WriteLine(book.ToString());
            book.IncreasePrice(10);
            Console.WriteLine(book.ToString());
            Console.WriteLine(book);
            Console.WriteLine();

            // Test 1: book2 is newer
            Book book1 = new Book("J.K. Rowling", "Harry Potter", 2008, 3500);
            Book book2 = new Book("Bán Mór", "Hunyadi");

            Console.WriteLine("Feladat: osszehasonlitani book1-et es book2-t!!!");
            int eredmeny1 = Book.ComparePublicationDate(book1, book2);
            if (eredmeny1 == 1)
            {
                Console.WriteLine(book1.GetTitle() + " ujabb konyv.");
            }
            else if (eredmeny1 == 2)
            {
                Console.WriteLine(book2.GetTitle() + " ujabb konyv.");
            }
            else
            {
                Console.WriteLine("A konyvek egyidosek.");
            }


            // Test 2: book1 is newer
            book2 = new Book("J.K. Rowling", "Harry Potter");
            book1 = new Book("Bán Mór", "Hunyadi", 2008, 3500);

            Console.WriteLine("Feladat: osszehasonlitani book1-et es book2-t!!!");
            eredmeny1 = Book.ComparePublicationDate(book1, book2);
            if (eredmeny1 == 1)
            {
                Console.WriteLine(book1.GetTitle() + " ujabb konyv.");
            }
            else if (eredmeny1 == 2)
            {
                Console.WriteLine(book2.GetTitle() + " ujabb konyv.");
            }
            else
            {
                Console.WriteLine("A konyvek egyidosek.");
            }

            // Test 3: book1 and book2 are published in the same year
            book2 = new Book("J.K. Rowling", "Harry Potter");
            book1 = new Book("Bán Mór", "Hunyadi");

            Console.WriteLine("Feladat: osszehasonlitani book1-et es book2-t!!!");
            eredmeny1 = Book.ComparePublicationDate(book1, book2);
            if (eredmeny1 == 1)
            {
                Console.WriteLine(book1.GetTitle() + " ujabb konyv.");
            }
            else if (eredmeny1 == 2)
            {
                Console.WriteLine(book2.GetTitle() + " ujabb konyv.");
            }
            else
            {
                Console.WriteLine("A konyvek egyidosek.");
            }
            */

        }

        private static int ReadInteger()
        {
            int n = -1;
            Console.WriteLine("Adj meg egy számot 1 és 10 között!");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 10 || n < 1) { Console.WriteLine("Nem felel meg az intervallumnak. Próbáld újra!"); }
            } while (n > 10 || n < 1);
            return n;
        }

    }
}
