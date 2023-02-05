using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            var sum = numbers.Sum();
            Console.WriteLine($"Sum: {sum}");

            //TODO: Print the Average of numbers
            var avg = numbers.Average();
            Console.WriteLine($"Average: {avg}");

            //TODO: Order numbers in ascending order and print to the console
            var asc = numbers.OrderBy(num => num);
            Console.WriteLine("......................");
            Console.WriteLine("Ascending order:");

            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            
            //TODO: Order numbers in decsending order and print to the console
            var desc = numbers.OrderByDescending(x => x);
            Console.WriteLine("......................");
            Console.WriteLine("Descending order:");

            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }

            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(num => num > 6);

            Console.WriteLine(".........................");
            Console.WriteLine("Numbers greater than six:");

            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var firstFour = asc.Take(4);

            Console.WriteLine("........................");
            Console.WriteLine("First 4 numbers in ascending order:");

            foreach (var num in firstFour)
            {
                Console.WriteLine(num);
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 20;
            Console.WriteLine("......................");
            Console.WriteLine("With my age being included:");

            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            var filtered = 
                employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S'))
                .OrderBy(name => name.FirstName);

            Console.WriteLine(".......................");
            Console.WriteLine("C or S employees:");
            foreach (var employee in filtered)
            {
                Console.WriteLine(employee.FirstName);
            }
            
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            var overTwentySix = employees.Where(emp => emp.Age > 26)
                .OrderBy(emp => emp.Age)
                .ThenBy(emp => emp.FirstName)
                .ThenBy(emp => emp.YearsOfExperience);

            Console.WriteLine("...........................");
            Console.WriteLine("Employees over 26:");
            foreach (var name in overTwentySix)
            {
                Console.WriteLine($"Age: {name.Age} First name: {name.FirstName} YOE: {name.YearsOfExperience}");
            }
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var sumOfYOE = yOE.Sum(emp => emp.YearsOfExperience);
            var avgOfYOE = yOE.Average(emp => emp.YearsOfExperience);

            Console.WriteLine("............................");
            Console.WriteLine($"Sum of employee YOE: {sumOfYOE}");
            Console.WriteLine($"Average of employee YOE: {avgOfYOE}");


            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Katelyn", "Collier", 20, 3)).ToList();

            Console.WriteLine("........................");
            Console.WriteLine("List of employees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Age} {employee.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
