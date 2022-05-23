using myinterface;
using System;

namespace shop
{
    public class Employee : ITaxable
    {
        private string name;
        private int salary;
        private int taxPercent;
        private const int defaultTaxPercent = 15;

        public Employee(string name, int salary)
        {
            this.name = name;
            this.salary = salary;
            this.taxPercent = defaultTaxPercent;
        }

        public string Name { get; set; }
        public int Salary { get; set; }
        public int TaxPercent { get; set; }

        public double GetTax()
        {
            return Math.Round((this.taxPercent / 100.00) * this.salary, MidpointRounding.AwayFromZero);
        }

        public double GetTaxedValue()
        {
            return this.salary - this.GetTax();
        }

        public override string ToString()
        {
            return string.Format("name: {0}, salary: {1}, SZJ: {2}", this.name, this.salary, this.GetTax());
        }
    }



}
