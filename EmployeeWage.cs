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
        const int NUM_OF_WORKING_DAYS = 20;

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem");

            int totalWage = 0;

            Random random = new Random();

            for (int day = 1; day <= NUM_OF_WORKING_DAYS; day++)
            {
                int empCheck = random.Next(0, 3);
                int empHours = 0;

                switch (empCheck)
                {
                    case IS_FULL_TIME:
                        empHours = 8;
                        Console.WriteLine("Day " + day + ": Full-Time (8 hrs)");
                        break;

                    case IS_PART_TIME:
                        empHours = 4;
                        Console.WriteLine("Day " + day + ": Part-Time (4 hrs)");
                        break;

                    case IS_ABSENT:
                    default:
                        empHours = 0;
                        Console.WriteLine("Day " + day + ": Absent (0 hrs)");
                        break;
                }

                int dailyWage = empHours * WAGE_PER_HOUR;
                totalWage += dailyWage;
                Console.WriteLine("Day " + day + " Wage: Rs." + dailyWage + "\n");
            }

            Console.WriteLine("Total Monthly Wage for 20 Days: Rs." + totalWage);
        }
    }
}
