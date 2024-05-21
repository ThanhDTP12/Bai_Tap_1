using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_Tap_1
{   
    public class PartTimeEmployee : Employee
    {
        private double workingHours;

        public PartTimeEmployee(string name, double paymentPerHour, double workingHours) : base(name, paymentPerHour)
        {
            this.workingHours = workingHours;
        }
        public override double CalculateSalary()
        {
            return workingHours * paymentPerHour;
        }
    }
}
