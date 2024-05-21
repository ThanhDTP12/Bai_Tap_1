// See https://aka.ms/new-console-template for more information
using Bai_Tap_1;
using OOP1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            // Khởi tạo mảng nhân viên trống
            Employee[] employees = new Employee[0];

            while (true)
            {
                // Hiển thị menu
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Find Employee with Highest Salary");
                Console.WriteLine("3. Find Employee by Name");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                // Xử lý lựa chọn của người dùng
                switch (choice)
                {
                    case "1":
                        AddEmployee(ref employees); // Thêm nhân viên
                        break;
                    case "2":
                        FindHighestPaidEmployees(employees); // Tìm nhân viên có lương cao nhất
                        break;
                    case "3":
                        FindEmployeeByName(employees); // Tìm nhân viên theo tên
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program."); // Thoát chương trình
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again."); // Lựa chọn không hợp lệ
                        break;
                }
            }
        }

        public static void AddEmployee(ref Employee[] employees)
        {
            try
            {
                // Nhập thông tin nhân viên mới
                Console.WriteLine("Add Employee:");
                Console.Write("Enter employee name: ");
                string name = Console.ReadLine();
                Console.Write("Enter hourly wage: ");
                double paymentPerHour = Convert.ToDouble(Console.ReadLine());

                // Thêm nhân viên mới vào mảng
                Array.Resize(ref employees, employees.Length + 1);
                employees[employees.Length - 1] = new FullTimeEmployee(name, paymentPerHour);
                Console.WriteLine("Employee added successfully."); // Thông báo thêm thành công
            }
            catch (FormatException)
            {
                // Xử lý lỗi định dạng đầu vào
                Console.WriteLine("Error: Invalid input data. Please try again.");
            }
        }

        public static void FindHighestPaidEmployees(Employee[] employees)
        {
            // Khởi tạo biến để tìm nhân viên có lương cao nhất
            double maxSalaryFullTime = double.MinValue;
            double maxSalaryPartTime = double.MinValue;
            FullTimeEmployee highestPaidFullTime = null;
            PartTimeEmployee highestPaidPartTime = null;

            // Duyệt qua tất cả nhân viên để tìm nhân viên có lương cao nhất
            foreach (var employee in employees)
            {
                if (employee is FullTimeEmployee)
                {
                    double salary = employee.CalculateSalary();
                    if (salary > maxSalaryFullTime)
                    {
                        maxSalaryFullTime = salary;
                        highestPaidFullTime = (FullTimeEmployee)employee;
                    }
                }
                else if (employee is PartTimeEmployee)
                {
                    double salary = employee.CalculateSalary();
                    if (salary > maxSalaryPartTime)
                    {
                        maxSalaryPartTime = salary;
                        highestPaidPartTime = (PartTimeEmployee)employee;
                    }
                }
            }

            // Hiển thị nhân viên có lương cao nhất
            Console.WriteLine($"Employee with highest salary in FullTime: {highestPaidFullTime}, Salary: {maxSalaryFullTime}");
            Console.WriteLine($"Employee with highest salary in PartTime: {highestPaidPartTime}, Salary: {maxSalaryPartTime}");
        }

        public static void FindEmployeeByName(Employee[] employees)
        {
            // Nhập tên nhân viên cần tìm
            Console.Write("Enter the name of the employee to find: ");
            string name = Console.ReadLine();
            bool found = false;

            // Duyệt qua tất cả nhân viên để tìm nhân viên theo tên
            foreach (var employee in employees)
            {
                if (employee.ToString().Contains(name))
                {
                    Console.WriteLine($"Employee found: {employee}");
                    found = true;
                }
            }

            // Thông báo nếu không tìm thấy nhân viên
            if (!found)
            {
                Console.WriteLine("No employee found with that name.");
            }
        }
    }
}

