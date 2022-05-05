using System;
using System.Collections.Generic;
using System.Text;

namespace book
{


    //Egészítse ki a definiált Könyv osztályt 2 konstruktorral.
    //Az egyik konstruktornak a könyv minden adatát meg kell adni, 
    //a másiknak csak a szerzőt és a címet, az ár 2500 Ft, a megjelenés éve pedig az aktuális év.
    //Definiálja felül a ToString metódust a DisplayInformation metódus tartalmával.
    //Írjon osztályszintű összehasonlító metódust(ComparePublicationDate), 
    //amely 1-et ad vissza, ha az első paraméterként megadott könyv az újabb, 
    //2-t ha a második, és 0-t, ha ugyanabban az évben jelentek meg.

    //Értékadás előtti ellenőrzések:
    //- a megjelenés éve, ha nem 1950 és 2021 között van, legyen 2021, egyébként a megadott érték
    //- az ár legyen 1000 forint 1000-nél kisebb értékekre, egyébként a megadott érték

    //Módosítsa a Könyv osztályt használó osztályt ennek megfelelően.
    //A BookTest osztályban hozzon létre 2 könyvet (a 2 konstruktort felhasználva) és
    //jelenítse meg az adataikat a ToString metódust használva.
    //Hasonlítsa össze a két könyv megjelenési évét.

    public class Book
    {
        private string author;
        private string title;
        private readonly int yearOfPublication = DateTime.Now.Year;
        private int price;
        private int pages;

        public Book(string author, string title, int price, int pages)
        {
            this.author = author;
            this.title = title;

            if (price < 0) { price = 0; }
            if (pages < 0) { pages = 0; }

            this.price = price;
            this.pages = pages;


        }

        public Book(string author, string title)
        {
            this.author = author;
            this.title = title;
            this.price = 2500;
            this.pages = 100;
        }

        public int Price
        {
            get { return price; }
            set
            {
                //Értékadás előtti ellenőrzés:
                //- az ár legyen 1000 forint 1000-nél kisebb értékekre, egyébként a megadott érték
                if (value < 1000)
                {
                    price = 1000;
                }
                else
                {
                    price = value;
                }

            }
        }

        public int YearOfPublication
        {
            get { return yearOfPublication; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public int GetPrice()
        { return Price; }

        public void SetPrice(int value)
        { Price = value; }

        public int GetYearOfPublication()
        { return YearOfPublication; }

        public string GetTitle()
        { return Title; }

        public void SetTitle(string value)
        { Title = value; }

        public string GetAuthor()
        { return Author; }

        public void SetAuthor(string value)
        { Author = value; }

        public int Pages
        {
            get { return pages; }
            set { if (value > -1) { pages = value; } }
        }
        public int GetPages()
        { return this.pages; }

        public void SetPages(int value)
        {
            if (value > -1)
            {
                this.pages = value;
            }
        }

        public void IncreasePrice(int percentage)
        {
            if (percentage > 0)
                price += (int)Math.Round(price * percentage / 100.0);
        }

        public static int ComparePublicationDate(Book elso, Book masodik)
        {
            if (elso.GetYearOfPublication() < masodik.GetYearOfPublication())
            {
                return 2;
            }
            else if (elso.GetYearOfPublication() == masodik.GetYearOfPublication())
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static Book GetLonger(Book elso, Book masodik)
        {
            if (elso.GetPages() < masodik.GetPages())
            {
                return masodik;
            }
            else
            {
                return elso;
            }
        }
        public bool HasEvenPages()
        {
            if (this.pages % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return this.author + ": " + this.title + ", " + this.yearOfPublication + ". Price: "
                + this.price + " Ft, " + "pp " + this.pages;
        }

        public static void ListBookArray(Book[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine((i + 1) + ". könyv: " + tomb[i].ToString());
            }
        }

        public static Book GetLongestBook(Book[] tomb)
        {
            Book talalat = new Book("", "", 0, 1);
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].GetPages() > talalat.GetPages())
                {
                    talalat = tomb[i];
                }
            }
            return talalat;
        }

        public static Book GetLongestEvenPagesBook(Book[] tomb)
        {
            Book maxBook = null;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].HasEvenPages())
                {
                    maxBook = tomb[i];
                }
            }
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].HasEvenPages() && tomb[i].GetPages() > maxBook.GetPages())
                {
                    maxBook = tomb[i];
                }
            }
            return maxBook;
        }

        public static void AuthorStatistics(Book[] tomb)
        {
            List<string> authors = new List<string>();
            authors.Add(tomb[0].GetAuthor());
            for (int i = 1; i < tomb.Length; i++)
            {
                if (!authors.Contains(tomb[i].GetAuthor()))
                {
                    authors.Add(tomb[i].GetAuthor());
                }
            }
            for (int i = 0; i < authors.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < tomb.Length; j++)
                {
                    if (authors[i] == tomb[j].GetAuthor())
                    {
                        counter++;
                    }
                }
                Console.WriteLine(authors[i] + " ironak " + counter + " konyve van.");
            }
        }

    }
}
