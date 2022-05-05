using System;
using myproducts;

namespace myclass
{
    public class Product
    {
        public string name;
        public int price;

        public Product(string name, int price)
        {
            this.name = name;
            if (!(price < 0))
            {
                this.price = price;
            }

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



        public override string ToString()
        {
            return "termeknev: " + this.name + " termekar: " + Price.ToString();
        }

        public void IncreasePrice(int percentage)
        {
            if (percentage > 0)
            {
                int hozzaadando = Convert.ToInt32(Math.Round(this.price * (percentage / 100.0), MidpointRounding.AwayFromZero));
                this.price = this.price + hozzaadando;
            }
        }

        public virtual void DecreasePrice(int percentage)
        {
            if (percentage > 0)
            {
                int kivonando = Convert.ToInt32(Math.Round(this.price * (percentage / 100.0)));
                this.price = this.price - kivonando;
            }
        }
    }
}
