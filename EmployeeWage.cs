using System;

namespace EmployeeWage
{
    class EmployeeWage
    {
        //Constants value cannot be change
        const int IS_PRESENT = 1;
        const int WAGE_PER_HOUR = 20;
        const int FULL_DAY_HOURS = 8;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem");

            Random random = new Random();
            int empCheck = random.Next(0, 2);
            if (empCheck == IS_PRESENT)
            {
                Console.WriteLine("Employee is Present");

                int dailyWage = WAGE_PER_HOUR * FULL_DAY_HOURS;
                Console.WriteLine("Employee Daily Wage: ₹" + dailyWage);
            }
            else
            {
                Console.WriteLine("Employee is Absent");
                Console.WriteLine("Employee Daily Wage: Rs.0");
            }
        }
    }
}