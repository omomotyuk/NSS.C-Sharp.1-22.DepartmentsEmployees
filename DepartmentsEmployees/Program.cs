using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;
using System;

namespace DepartmentsEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDepartment();
            //TestEmployee();
            TestEmployeeDepartment();
        }

        static void TestDepartment()
        {
            var departmentRepo = new DepartmentRepository();

            var allDepartments = departmentRepo.GetAllDepartments();

            Console.WriteLine("All Departments:\n");
            foreach (var dept in allDepartments)
            {
                Console.WriteLine(dept.DepartmentName);
            }

            var hardCodedId = 3;

            var departmentWithId3 = departmentRepo.GetDepartmentById(hardCodedId);

            Console.WriteLine($"Department with id {hardCodedId} is {departmentWithId3.DepartmentName}");

            /*
            Department legal = new Department
            {
                DepartmentName = "Legal"
            };
            //Console.WriteLine("What department would you like to add?");
            //legal.DepartmentName = Console.ReadLine();

            departmentRepo.AddDepartment(legal);

            Console.WriteLine("What department (ID) would you like to update?");
            var departmentToUpdate = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What new department should be called?");
            var departmentToUpdateName = Console.ReadLine();

            departmentRepo.UpdateDepartment(departmentToUpdate, new Department { DepartmentName = departmentToUpdateName });

            //departmentRepo.DeleteDepartment(7);
            */
        }

        static void TestEmployee()
        {
            var employeeRepo = new EmployeeRepository();

            var allEmployees = employeeRepo.GetAllEmployees();

            Console.WriteLine("\nAll Employees:\n");
            foreach (var empl in allEmployees)
            {
                Console.WriteLine($"{empl.FirstName} {empl.LastName}, {empl.DepartmentId}");
            }

            var hardCodedId = 3;

            var employeeWithId3 = employeeRepo.GetEmployeeById(hardCodedId);

            Console.WriteLine($"Employee with id {hardCodedId} is {employeeWithId3.FirstName} {employeeWithId3.LastName}");
        }

        static void TestEmployeeDepartment()
        {
            var employeeRepo = new EmployeeRepository();

            var allEmployees = employeeRepo.GetAllEmployeesWithDepartment();

            Console.WriteLine("\nAll Employees with Department:\n");
            foreach (var empl in allEmployees)
            {
                Console.WriteLine($"{empl.FirstName} {empl.LastName}, {empl.DepartmentId} {empl.DepartmentName}");
            }
        }

    }
}
