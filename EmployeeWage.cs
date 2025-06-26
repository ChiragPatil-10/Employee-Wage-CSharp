using System;

namespace EmployeeWage
{
    class EmployeeWage
    {
        // Constants
        const int IS_ABSENT = 0;
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 2;
        const int WAGE_PER_HOUR = 20;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem");

            Random random = new Random();
            int empCheck = random.Next(0, 3);

            int empHours = 0;

            switch (empCheck)
            {
                case IS_FULL_TIME:
                    Console.WriteLine("Employee is Present (Full-Time)");
                    empHours = 8;
                    break;

                case IS_PART_TIME:
                    Console.WriteLine("Employee is Present (Part-Time)");
                    empHours = 4;
                    break;

                case IS_ABSENT:
                default:
                    Console.WriteLine("Employee is Absent");
                    empHours = 0;
                    break;
            }

            int dailyWage = empHours * WAGE_PER_HOUR;
            Console.WriteLine("Employee Daily Wage: Rs." + dailyWage);
        }
    }
}
