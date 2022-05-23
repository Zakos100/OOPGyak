using myinterface;
using myproducts;
using shop;
using System;
using System.Collections.Generic;

namespace myprogram
{
    /*

     */
    class StoreTest
    {
        static void Main(string[] args)
        {
            //9. HÉT

            List<Book> raktar = new List<Book>();
            raktar.Add(new Book("Szabó Magda", "Abigél", 1800, 240, "other"));
            raktar.Add(new Book("Fekete István", "Vuk", 2000, 120, "children"));
            raktar.Add(new Book("Stahl Judit", "Gyors szárnyas ételek", 4000, 190, "guide"));

            List<Employee> szemelyzet = new List<Employee>();
            szemelyzet.Add(new Employee("Ivancsó Marcell", 200000));
            szemelyzet.Add(new Employee("Győri Zsófia", 250000));
            szemelyzet.Add(new Employee("Pozsgai Péter", 300000));
            BookStore konyvesbolt = new BookStore();
            konyvesbolt.SetStock(raktar);
            konyvesbolt.SetStaff(szemelyzet);

            int konyvekszama = konyvesbolt.ListStock();
            Console.WriteLine();
            konyvesbolt.SortByTitle();
            konyvekszama = konyvesbolt.ListStock();
            Console.WriteLine();
            konyvesbolt.ReverseSortByPrice();
            konyvekszama = konyvesbolt.ListStock();
            Console.WriteLine();
            Console.WriteLine("Összesitett ÁFA: {0}, Öszessitett SZJA: {1}",
                konyvesbolt.SumVAT(), konyvesbolt.SumIncomTax());

            /*Product proba = new Product("kenyér", 150);
            Console.WriteLine(proba.ToString());
            proba.Price = 6;
            Console.WriteLine(proba.ToString());
            Console.ReadKey();
            */
            /*
            int beolvasott = ReadInteger();
            EBook[] konyvek = new EBook[beolvasott];
            Console.WriteLine("Formátum: szerzo; cim; oldalszam; ar; stilus; url");
            for (int i = 0; i < beolvasott; i++)
            {
                Console.WriteLine("Add meg a(z) " + (i + 1) + ". könyvet!");
                string line = Console.ReadLine();
                string[] peldany = line.Split("; ");
                while (peldany.Length != 6)
                {
                    Console.WriteLine("Hibás formátum, próbáld újra!");
                    line = Console.ReadLine();
                    peldany = line.Split("; ");
                }
                konyvek[i] =
                new EBook(peldany[0], peldany[1], Convert.ToInt32(peldany[2]), Convert.ToInt32(peldany[3]),
                (BookStyle)Enum.Parse(typeof(BookStyle), peldany[4], true), peldany[5]);
            }

            Book.ListBookArray(konyvek);

            double unitPrice = 20;

            string[] selected = Book.SelectAuthors(konyvek, unitPrice);

            Console.WriteLine("Sum of sales: " + Book.SumGrossPrice(konyvek));

            Book.ChangeCurrency(konyvek);

            Console.WriteLine("List of books after changecurrency:");

            Book.ListBookArray(konyvek);
            */

            /*
            Console.WriteLine("Number of stlyes: " + Book.CountStyles(konyvek));

            string searchStyle = "guide";
            int percentage = 10;

            Book.DiscountBooks(konyvek, searchStyle, percentage);
            Book.ListBookArray(konyvek);
            Console.ReadKey();

            Console.WriteLine(searchStyle[0].ToString().ToUpper() +
                searchStyle.Substring(1).ToLower() + " style books");

            Book.ListBooksWithStyle(konyvek, searchStyle);

            Console.WriteLine("Average price of " + searchStyle
                + " style books: " + Book.AveragePrice(konyvek, searchStyle));
            */

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
            Console.WriteLine("Number of books: ");
            do
            {
                n = Convert.ToInt32(Console.ReadLine());
                if (n > 10 || n < 1) { Console.WriteLine("1 és 10 közötti szám legyen! Próbáld újra!"); }
            } while (n > 10 || n < 1);
            return n;
        }

    }
}
