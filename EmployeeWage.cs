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
        const int MAX_WORKING_DAYS = 20;
        const int MAX_WORKING_HOURS = 100;

        public void ComputeWage()
        {
            int totalWage = 0;
            int totalWorkingDays = 0;
            int totalWorkingHours = 0;

            Random random = new Random();

            while (totalWorkingDays < MAX_WORKING_DAYS && totalWorkingHours < MAX_WORKING_HOURS)
            {
                totalWorkingDays++;

                int empCheck = random.Next(0, 3);
                int empHours = 0;

                switch (empCheck)
                {
                    case IS_FULL_TIME:
                        empHours = 8;
                        break;

                    case IS_PART_TIME:
                        empHours = 4;
                        break;

                    case IS_ABSENT:
                    default:
                        empHours = 0;
                        break;
                }

                // Preventing total hours from exceeding 100
                if (totalWorkingHours + empHours > MAX_WORKING_HOURS)
                {
                    empHours = MAX_WORKING_HOURS - totalWorkingHours;
                }

                totalWorkingHours += empHours;
                int dailyWage = empHours * WAGE_PER_HOUR;
                totalWage += dailyWage;

                Console.WriteLine($"Day {totalWorkingDays}: Hours = {empHours}, Daily Wage = Rs.{dailyWage}, Total Hours = {totalWorkingHours}");
            }

            Console.WriteLine("\nFinal Summary:");
            Console.WriteLine($"Total Working Days: {totalWorkingDays}");
            Console.WriteLine($"Total Working Hours: {totalWorkingHours}");
            Console.WriteLine($"Total Monthly Wage: Rs.{totalWage}");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem");

            EmployeeWage emp = new EmployeeWage();
            emp.ComputeWage(); 
        }
    }
}
