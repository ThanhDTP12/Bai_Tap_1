using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_Tap_1
{
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name, double paymentPerHour) : base(name, paymentPerHour) { }
        public override double CalculateSalary()
        {
            return 8 * paymentPerHour;
        }
    }
}
