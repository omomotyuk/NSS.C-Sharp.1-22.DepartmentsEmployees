using DepartmentsEmployees.Data;
using DepartmentsEmployees.Models;
using System;
using System.Collections.Generic;

namespace DepartmentsEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDepartment();
            TestEmployee();
        }

        static void TestDepartment()
        {
            var departmentRepo = new DepartmentRepository();
            var allDepartments = departmentRepo.GetAllDepartments();

            Console.WriteLine("\nAll Departments:\n" +
                                "----------------" );
            foreach (var dept in allDepartments)
            {
                Console.WriteLine(dept.DepartmentName);
            }
            Console.Write("\n");

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

            EmployeeList( allEmployees );

            var hardCodedId = 3;
            var employeeWithId3 = employeeRepo.GetEmployeeById(hardCodedId);

            Console.WriteLine($"Employee with id {hardCodedId} is {employeeWithId3.FirstName} {employeeWithId3.LastName}");

            //
            // TestEmployeeDepartment()
            //
            var allEmployeeDepartment = employeeRepo.GetAllEmployeesWithDepartment();

            Console.WriteLine("\nAll Employees with Department:\n" +
                                "------------------------------");
            foreach (var empl in allEmployeeDepartment)
            {
                Console.WriteLine($"{empl.FirstName} {empl.LastName}, {empl.DepartmentName} ({empl.DepartmentId})");
            }
            Console.Write("\n");

            /*
             *  test of AddEmployee()
             */
            var newEmployee = new Employee { FirstName = "New", LastName = "Newson", DepartmentId = 3 };
            employeeRepo.AddEmployee( newEmployee );
            EmployeeList( employeeRepo.GetAllEmployees() );
        }

        static void EmployeeList( List<Employee> employees )
        {
            Console.WriteLine("\nAll Employees:\n" +
                                "--------------");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}, {employee.DepartmentId}");
            }
            Console.Write("\n");
        }
    }
}
