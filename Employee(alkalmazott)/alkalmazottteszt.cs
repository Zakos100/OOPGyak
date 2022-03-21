using System;

namespace _1_Employee
{
    class alkalmazottteszt
    {
        static void Main(string[] args)
        {
            alkalmazott employee = new alkalmazott();

            employee.name = "Baumgartner Zsolt";
            employee.salary = 150000;

            Console.WriteLine(employee.DisplayInfo());
            employee.IncreaseSalary(1000);
            Console.WriteLine(employee.DisplayInfo());
        }
    }
}