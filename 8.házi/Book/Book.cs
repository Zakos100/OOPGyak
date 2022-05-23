using myclass;
using System;
using System.Collections.Generic;

namespace myproducts
{

    public class Book : Product
    {
        private string author;
        private string title;
        private readonly int yearOfPublication = DateTime.Now.Year;
        private int pages;
        private string style;


        public Book(string author, string title, int price, int pages, string style) : base("book", price, 5)
        {
            this.author = author;
            this.title = title;
            this.style = style;

            if (price < 1)
            {
                price = 0;
            }
            else
            {
                this.price = price;
            }

            if (pages < 1)
            {
                pages = 0;
            }
            else
            {
                this.pages = pages;
            }

        }

        public Book(string author, string title, string style) : base("book", 2500, 5)
        {
            this.author = author;
            this.title = title;
            this.pages = 100;
            this.style = style;
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
            set
            {
                if (value < 0)
                {

                }
                else
                {
                    pages = value;
                }
            }
        }
        public int GetPages()
        { return this.pages; }

        public void SetPages(int value)
        {
            if (value < 0)
            {

            }
            else
            {
                this.pages = value;
            }
        }

        public string Style { get; set; }

        public string GetStyle()
        {
            return this.style;
        }

        public void SetStyle(string value)
        {
            this.style = value;
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
            return " " + this.author + ": " + this.title + ", " +
                this.yearOfPublication + " pp " + this.pages + " ar: " + this.price + " "
                + this.style + " egysegar: " + this.GetUnitPrice();
        }

        public override void DecreasePrice(int percentage)
        {
            if (percentage > 0 && this.GetStyle().Equals("children", StringComparison.OrdinalIgnoreCase))
            {
                int kivonando = Convert.ToInt32(Math.Round(this.price * ((percentage + 7) / 100.0)));
                this.price = this.price - kivonando;

            }
            else if (percentage > 0 && this.GetStyle().Equals("guide", StringComparison.OrdinalIgnoreCase))
            {
                int kivonando = Convert.ToInt32(Math.Round(this.price * ((percentage + 5) / 100.0)));
                this.price = this.price - kivonando;
            }
            else if (percentage > 0)
            {
                int kivonando = Convert.ToInt32(Math.Round(this.price * (percentage / 100.0)));
                this.price = this.price - kivonando;
            }
            return;
        }

        public static void ListBookArray(Book[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.WriteLine((i + 1) + ". könyv: " + tomb[i].ToString());
            }
            return;
        }


        public static Book GetLongestBook(Book[] tomb)
        {
            Book talalat = new Book("", "", 0, 1, "");
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
            return;
        }

        public static int CountStyles(Book[] tomb)
        {
            List<string> styles = new List<string>();
            styles.Add(tomb[0].GetStyle());
            for (int i = 1; i < tomb.Length; i++)
            {
                if (!styles.Contains(tomb[i].GetStyle()))
                {
                    styles.Add(tomb[i].GetStyle());
                }
            }
            return styles.Count;
        }

        public static void DiscountBooks(Book[] tomb, string stylein, int percentage)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].GetStyle().Equals(stylein, StringComparison.OrdinalIgnoreCase))
                {
                    //100-at csökkenteni 7%-kal: 200-(200*(7/100))
                    int kivonando = Convert.ToInt32(Math.Round(tomb[i].GetPrice() * (percentage / 100.0)));
                    tomb[i].SetPrice(tomb[i].GetPrice() - kivonando);
                }
            }
            return;
        }

        public static int ListBooksWithStyle(Book[] tomb, string stylein)
        {
            int szam = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].GetStyle().Equals(stylein, StringComparison.OrdinalIgnoreCase))
                {
                    szam++;
                    Console.WriteLine(tomb[i].ToString());
                }
            }
            return szam;
        }

        public static int AveragePrice(Book[] tomb, string stylein)
        {
            bool vanstilus = false;
            int osszeg = 0;
            int szam = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[0].GetStyle().Equals(stylein, StringComparison.OrdinalIgnoreCase))
                {
                    vanstilus = true;
                    osszeg += tomb[i].GetPrice();
                    szam++;
                    Console.WriteLine(tomb[i].ToString());
                }
            }
            if (vanstilus)
            {
                return osszeg / szam;
            }
            else
            {
                return 0;
            }
        }

        public override int GetUnitPrice()
        {
            return (int)Math.Round(this.GetTaxedValue() / this.pages, MidpointRounding.AwayFromZero);
        }

        public static string[] SelectAuthors(Book[] tomb, double unitPrice)
        {
            List<string> seged = new List<string>();
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].GetUnitPrice() > unitPrice && !(seged.Contains(tomb[i].Author)))
                {
                    seged.Add(tomb[i].Author);
                }
            }
            string[] output = seged.ToArray();

            return output;
        }

        public static int SumGrossPrice(Book[] tomb)
        {
            int osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                osszeg += (int)Math.Round(tomb[i].GetTaxedValue(), MidpointRounding.AwayFromZero);
            }
            return osszeg;
        }

    }
}
