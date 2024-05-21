using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_Tap_1
{
    public abstract class Employee : IEmployee
    {
        protected string name;
        protected double paymentPerHour;
        public Employee(string name, double paymentPerHour)
        {
            this.name = name;
            this.paymentPerHour = paymentPerHour;
        }
        public abstract double CalculateSalary();
        public override string ToString()
        {
            return $"Name: {name}, Payment per Hour: {paymentPerHour}";
        }
    }
}
