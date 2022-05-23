using myclass;
using System;
using System.Collections.Generic;

namespace myproducts
{
    /*
9. heti házi feladat:
Figyelem! Az eddigieknek megfelelően ez a feladat is az előző továbbfejlesztése, 
a tesztek a korábban implementált funkciókat is ugyanúgy tesztelik!

1. ----------------------------
A Book osztályban a stílus legyen enum típusú (BookStyle). Ezt a típust beágyazott osztályként valósítsa meg az alábbi 
konstansokkal: CHILDREN, GUIDE, CRIME, COOK, OTHER.
A konstruktorban és a stílust beállító tulajdonságban ellenőrizze, hogy a megadott stílus string benne van-e a listában. 
    Ha érvénytelen az input, az alapértelmezett legyen OTHER.
A getter property a stílus string-et adja vissza.

2. -------------------------
A Book osztályba kerüljön be egy számláló osztályszintű adattag (number), amivel számolja a létrehozott könyv 
példányokat (azaz a konstruktor eggyel növeli).
Ez az adattag legyen lekérdezhető (GetNumber()).
Írjon destruktort, hogy amikor egy példány megszűnik ez a szám eggyel csökkenjen.

3. -----------------------------
A shop névtérben legyen egy Employee osztály, ami implementálja a Taxable interfészt. 
Adattagjai: név (name, string), fizetés (salary, egész), és SZJA kulcs (taxPercent, egész), 
konstans: defaultTaxPercent , értéke 15.
Legyen két paraméteres konstruktora (név, fizetés). 
Generáljon getter tulajdonságokat és implementálja az interfészben előírt metódusokat/tulajdonságot.
(A GetTax() az SZJ összegét, a GetTaxedValue() az SZJ levonása utáni fizetést adja vissza.)
Generáljon ToString metódust, ami visszadja egy stringbrn a név, fizetés, SZJ összege értékeket.

4. ----------------------------------
A shop névtérben legyen egy BookStore osztály. Adattagjai:
	- Egy (egyelőre üres) List<Book> dinamikus tömb (stock), a raktáron levő könyvek tárolására
	- Egy (egyelőre üres) List<Taxable> dinamikus tömb (staff) az alkalmazottak tárolására
Az osztálynak csak default konstruktora van.
Generáltasson getting metódusokat. (Bár ez most csak a tesztelés miatt kell.)
Implementálja az alábbi metódusokat:
	- void AddToStock(Book book) - ami egy új könyvet ad hozzá a raktárhoz
	- void AddToStaff(Employee employee) - ami egy új alkalmazottat ad hozzá a megfelelő listához
	- int ListStock() - ami kilistázza a raktáron levő könyveket (visszatérési értéke a kilistázott elemek száma)
	- int ListStaff() - ami kilistázza az alkalmazottakat (visszatérési értéke a kilistázott elemek száma)
	- int SumVAT() - ami összesíti a raktáron levő könyveket terhelő adót
	- int SumIncomTax() - ami összesíti az alkalamzottak után fizetendő SZJA-t
	- void SortByTitle() - ami cím szerint ABC rendbe rendezi a raktárban levő könyveket
	- void ReverseSortByPrice() - ami ár szerint csökkenő sorrendbe rendezi a raktárban levő könyveket
Segítség:
	- A dinamikus tömb kezelésére és az IComparer implementálására példákat talál a 9.gyakorlat.pdf-ben.

5. -------------------
A myprogram névtérben legyen egy a StoreTest futtatható osztály, amely
	- példányosít egy BookStore objektumot
	- ezt feltölti néhány könyvvel és alkalmazottal
	- kilistázza a raktáron levő könyveket
	- rendezi ABC szerint a könyveket, majd ismét kilistázza
	- rendezi ár szerint a könyveket, majd ismét kilistázza
	- kiírja az összesített ÁFA-t és SZJA-t.

     */
    public enum BookStyle
    {
        CHILDREN,
        GUIDE,
        CRIME,
        COOK,
        OTHER
    }
    public class Book : Product
    {
        private string author;
        private string title;
        private readonly int yearOfPublication = DateTime.Now.Year;
        private int pages;
        private BookStyle style;
        private static int number = 0;


        public Book(string author, string title, int price, int pages, string style) : base("book", price, 5)
        {
            style = style.ToUpper();
            this.author = author;
            this.title = title;

            if (Enum.IsDefined(typeof(BookStyle), style))
            {
                this.style = (BookStyle)Enum.Parse(typeof(BookStyle), style, true);
            }
            else
            {
                this.style = BookStyle.OTHER;
            }

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
            number++;
        }

        public Book(string author, string title, string style) : base("book", 2500, 5)
        {
            style = style.ToUpper();
            this.author = author;
            this.title = title;
            this.pages = 100;
            if (Enum.IsDefined(typeof(BookStyle), style))
            {
                this.style = (BookStyle)Enum.Parse(typeof(BookStyle), style, true);
            }
            else
            {
                this.style = BookStyle.OTHER;
            }
            number++;
        }

        ~Book()
        {
            number--;
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

        public string Style
        {
            get { return Enum.GetName(typeof(BookStyle), style).ToUpper(); }
            set
            {
                if (Enum.IsDefined(typeof(BookStyle), value))
                {
                    style = (BookStyle)Enum.Parse(typeof(BookStyle), value, true);
                }
                else
                {
                    style = BookStyle.OTHER;
                }
            }
        }

        public BookStyle GetStyle()
        {
            return this.style;
        }

        public void SetStyle(BookStyle value)
        {
            if (Enum.IsDefined(typeof(BookStyle), value))
            {
                this.style = value;
            }
            else
            {
                this.style = BookStyle.OTHER;
            }
        }

        public static int GetNumber()
        {
            return number;
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
            return this.author + ": " + this.title + ", " +
                this.yearOfPublication + " pp " + this.pages + " ar: " + this.price + " "
                + this.style + " egysegar: " + this.GetUnitPrice();
        }

        public override void DecreasePrice(int percentage)
        {
            if (percentage > 0 && this.GetStyle() == BookStyle.CHILDREN)
            {
                int kivonando = Convert.ToInt32(Math.Round(this.price * ((percentage + 7) / 100.0)));
                this.price = this.price - kivonando;

            }
            else if (percentage > 0 && this.GetStyle() == BookStyle.GUIDE)
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
            Book talalat = new Book("", "", 0, 1, "guide");
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
            styles.Add(tomb[0].Style);
            for (int i = 1; i < tomb.Length; i++)
            {
                if (!styles.Contains(tomb[i].Style))
                {
                    styles.Add(tomb[i].Style);
                }
            }
            return styles.Count;
        }

        public static void DiscountBooks(Book[] tomb, string stylein, int percentage)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].GetStyle() == (BookStyle)Enum.Parse(typeof(BookStyle), stylein, true))
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
                if (tomb[i].GetStyle() == (BookStyle)Enum.Parse(typeof(BookStyle), stylein, true))
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
                if (tomb[0].GetStyle() == (BookStyle)Enum.Parse(typeof(BookStyle), stylein, true))
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
