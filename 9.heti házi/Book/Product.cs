using myinterface;
using System;

namespace myclass
{
    /*

	 */
    public abstract class Product : ITaxable
    {
        public string name;
        public int price;
        public const int defaultTaxPercent = 27;
        public int taxPercent = defaultTaxPercent;
        public string currency = "Ft";

        public Product(string name, int price, int taxPercent)
        {
            this.name = name;

            if (!(price < 0))
            {
                this.price = price;
            }
            else
            {
                this.price = 0;
            }

            if (!(taxPercent < 1))
            {
                this.taxPercent = taxPercent;
            }
            else
            {
                this.taxPercent = defaultTaxPercent;
            }
        }

        public Product(string name, int price)
        {
            this.name = name;

            if (!(price < 0))
            {
                this.price = price;
            }
            else
            {
                this.price = 0;
            }

            this.taxPercent = defaultTaxPercent;
        }



        public string Name { get; set; }
        public int Price
        {
            get { return price; }
            set
            {
                if (!(value < 0))
                {
                    price = value;
                };
            }
        }

        public int TaxPercent
        {
            get { return taxPercent; }
            set
            {
                if (!(value < 1))
                {
                    taxPercent = value;
                }
                else
                {
                    taxPercent = defaultTaxPercent;
                };
            }
        }

        public string Currency
        {
            get { return currency; }
            set
            {
                if (value == "Ft")
                {
                    //price = (int)Math.Round(price/360.0, MidpointRounding.AwayFromZero);
                    currency = value;
                }
                else if (value == "Euro")
                {
                    //price = (int)Math.Round(price * 360.0, MidpointRounding.AwayFromZero);
                    currency = value;
                }
                else
                {
                    // currency = "Ft";
                };
            }
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public int GetPrice()
        {
            return this.price;
        }

        public void SetPrice(int value)
        {
            this.price = value;
        }
        public double GetTax()
        {
            return Math.Round((this.taxPercent / 100.00) * this.price, MidpointRounding.AwayFromZero);
        }
        public double GetTaxedValue()
        {
            return this.price + this.GetTax();
        }

        //name: nev, price: ar, tax: ado%, grossPrice: nettoar devizanem
        public override string ToString()
        {
            return "name: " + this.name + " price: " + this.GetTaxedValue() + ", tax: " + this.taxPercent
                + "%, grossPrice: " + this.price + " " + this.currency;
        }

        public void IncreasePrice(int percentage)
        {
            if (percentage > 0)
            {
                int hozzaadando = Convert.ToInt32(Math.Round(this.price * (percentage / 100.0), MidpointRounding.AwayFromZero));
                this.price = this.price + hozzaadando;
            }
            return;
        }

        public virtual void DecreasePrice(int percentage)
        {
            if (percentage > 0)
            {
                int kivonando = Convert.ToInt32(Math.Round(this.price * (percentage / 100.0)));
                this.price = this.price - kivonando;
            }
            return;
        }

        public static void ChangeCurrency(Product[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i].Currency.Equals("Ft"))
                {
                    tomb[i].Currency = "Euro";
                    tomb[i].Price = (int)Math.Round(tomb[i].Price / 360.0, MidpointRounding.AwayFromZero);
                }
                else if (tomb[i].Currency.Equals("Euro"))
                {
                    tomb[i].Currency = "Ft";
                    tomb[i].Price = (int)Math.Round(tomb[i].Price * 360.0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    tomb[i].Currency = "Ft";
                }
            }
            return;
        }

        public static int ComparePrice(Product prod1, Product prod2)
        {
            int eredmeny = -1;
            if (prod1.Price > prod2.Price)
            {
                eredmeny = 1;
            }
            else if (prod1.Price < prod2.Price)
            {
                eredmeny = 2;
            }
            else if (prod1.Price == prod2.Price)
            {
                eredmeny = 0;
            }
            return eredmeny;
        }

        public abstract int GetUnitPrice();
    }
}
