using System;

namespace EmployeeWage
{
    class EmployeeWage
    {
        // Constants
        const int IS_ABSENT = 0;
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 2;

        // Method to compute wage for one company
        public void ComputeWageForCompany(string company, int wagePerHour, int maxWorkingDays, int maxWorkingHours)
        {
            int totalWage = 0;
            int totalWorkingDays = 0;
            int totalWorkingHours = 0;

            Random random = new Random();

            Console.WriteLine($"\n ===={company} Wage Computation Started ====");

            while (totalWorkingDays < maxWorkingDays && totalWorkingHours < maxWorkingHours)
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

                if (totalWorkingHours + empHours > maxWorkingHours)
                {
                    empHours = maxWorkingHours - totalWorkingHours;
                }

                totalWorkingHours += empHours;
                int dailyWage = empHours * wagePerHour;
                totalWage += dailyWage;

                Console.WriteLine($"Day {totalWorkingDays}: Hours = {empHours}, Wage = Rs.{dailyWage}, Total Hours = {totalWorkingHours}");
            }

            Console.WriteLine($"Total Wage for {company}: Rs.{totalWage}");
            Console.WriteLine($"===={company} Wage Computation Completed ====\n");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem");

            EmployeeWage empWageCalculator = new EmployeeWage();

            // for Company A
            empWageCalculator.ComputeWageForCompany("Tata", 20, 20, 100);

            // for Company B
            empWageCalculator.ComputeWageForCompany("Reliance", 25, 22, 110);

            // for Company C
            empWageCalculator.ComputeWageForCompany("Infosys", 18, 26, 95);
        }
    }
}
