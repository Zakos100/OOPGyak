using myinterface;
using myproducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shop
{
    public class BookStore
    {
        private List<Book> stock = new List<Book>();
        private List<Employee> staff = new List<Employee>();

        public List<Book> GetStock()
        {
            return this.stock;
        }
        public List<Employee> GetStaff()
        {
            return this.staff;
        }

        public void SetStock(List<Book> value)
        {
            this.stock = value;
        }

        public void SetStaff(List<Employee> value)
        {
            this.staff = value;
        }

        public void AddToStock(Book book)
        {
            this.stock.Add(book);
        }

        public void AddToStaff(Employee employee)
        {
            this.staff.Add(employee);
        }

        public int ListStock()
        {
            for (int i = 0; i < this.stock.Count; i++)
            {
                Console.WriteLine(this.stock[i].ToString());
            }
            return this.stock.Count;
        }

        public int ListStaff()
        {
            for (int i = 0; i < this.staff.Count; i++)
            {
                Console.WriteLine(this.staff[i].ToString());
            }
            return this.staff.Count;
        }

        public int SumVAT()
        {
            int osszeg = 0;
            for (int i = 0; i < this.stock.Count; i++)
            {
                osszeg += (int)Math.Round(this.stock[i].GetTax(), MidpointRounding.AwayFromZero);
            }
            return osszeg;
        }

        public int SumIncomTax()
        {
            int osszeg = 0;
            for (int i = 0; i < this.staff.Count; i++)
            {
                osszeg += (int)Math.Round(this.staff[i].GetTax(), MidpointRounding.AwayFromZero);
            }
            return osszeg;
        }

        public void SortByTitle()
        {
            this.stock = this.stock.OrderBy(o => o.Title).ToList();
        }

        public void ReverseSortByPrice()
        {
            this.stock = this.stock.OrderBy(o => o.Price).ToList();
            this.stock.Reverse();
        }

    }
}
