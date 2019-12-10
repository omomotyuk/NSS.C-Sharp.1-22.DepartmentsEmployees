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
                                "----------------");
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

            EmployeeList(allEmployees);

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

            // test of AddEmployee()
            TestAddEmployee( employeeRepo );

            // test of UpdateEmployee
            TestUpdateEmployee( employeeRepo );

            // test of DeleteEmployee
            TestDeleteEmployee( employeeRepo );
        }

        static void EmployeeList(List<Employee> employees)
        {
            Console.WriteLine("\nAll Employees:\n" +
                                "--------------");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id}. {employee.FirstName} {employee.LastName}, {employee.DepartmentId}");
            }
            Console.Write("\n");
        }

        static Employee ReadEmployeeInfo( Employee employee )
        {
            Console.Write("Employee's first name (enter new): ");
            string newValue = Console.ReadLine();
            if (newValue.Length != 0)
            {
                employee.FirstName = newValue;
            }

            Console.Write("Employee's last name (enter new): ");
            newValue = Console.ReadLine();
            if (newValue.Length != 0)
            {
                employee.LastName = newValue;
            }

            Console.Write("Employee's department id (enter new): ");
            newValue = Console.ReadLine();
            if (newValue.Length != 0)
            {
                employee.DepartmentId = Int32.Parse(newValue);
            }

            return employee;
        }

        static void TestAddEmployee(EmployeeRepository employeeRepo)
        {
            Console.WriteLine("Would you like to add new employee record?");

            if( Console.ReadLine().Length != 0 )
            {
                EmployeeList( employeeRepo.GetAllEmployees() );

                var employee = new Employee();

                employeeRepo.AddEmployee( ReadEmployeeInfo( employee ) );

                EmployeeList( employeeRepo.GetAllEmployees() );
            }
        }

        static void TestUpdateEmployee(EmployeeRepository employeeRepo)
        {
            Console.WriteLine("Would you like to update employee record?");

            if (Console.ReadLine().Length != 0)
            {
                var employee = new Employee();

                EmployeeList( employeeRepo.GetAllEmployees() );

                Console.Write("What record to update (id): ");
                int id = Int32.Parse(Console.ReadLine());

                employee = ReadEmployeeInfo( employeeRepo.GetEmployeeById(id) );

                employeeRepo.UpdateEmployee(id, employee);

                EmployeeList( employeeRepo.GetAllEmployees() );
            }
        }

        static void TestDeleteEmployee(EmployeeRepository employeeRepo)
        {
            Console.WriteLine("Would you like to delete employee record?");

            if (Console.ReadLine().Length != 0)
            {
                EmployeeList(employeeRepo.GetAllEmployees());

                Console.Write("What record to delete (id): ");
                int id = Int32.Parse(Console.ReadLine());

                employeeRepo.DeleteEmployee(id);

                EmployeeList(employeeRepo.GetAllEmployees());
            }
        }
    }
}
