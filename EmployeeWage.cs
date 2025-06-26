using System;

namespace EmployeeWage
{
    class CompanyEmpWage
    {
        public string company;
        public int wagePerHour;
        public int maxWorkingDays;
        public int maxWorkingHours;
        public int totalWage;

        public CompanyEmpWage(string company, int wagePerHour, int maxWorkingDays, int maxWorkingHours)
        {
            this.company = company;
            this.wagePerHour = wagePerHour;
            this.maxWorkingDays = maxWorkingDays;
            this.maxWorkingHours = maxWorkingHours;
            this.totalWage = 0;
        }

        // to print result
        public void PrintWage()
        {
            Console.WriteLine($"Total Wage for Company {company}: Rs.{totalWage}");
        }
    }

    class EmployeeWage
    {
        // Constants
        const int IS_ABSENT = 0;
        const int IS_FULL_TIME = 1;
        const int IS_PART_TIME = 2;

        // Method to compute wage and store in company object
        public void ComputeWage(CompanyEmpWage companyEmpWage)
        {
            int totalWorkingDays = 0;
            int totalWorkingHours = 0;
            int totalWage = 0;

            Random random = new Random();

            Console.WriteLine($"\n--- Wage Calculation for {companyEmpWage.company} ---");

            while (totalWorkingDays < companyEmpWage.maxWorkingDays && totalWorkingHours < companyEmpWage.maxWorkingHours)
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
                        empHours = 0;
                        break;
                }

                if (totalWorkingHours + empHours > companyEmpWage.maxWorkingHours)
                {
                    empHours = companyEmpWage.maxWorkingHours - totalWorkingHours;
                }

                totalWorkingHours += empHours;
                int dailyWage = empHours * companyEmpWage.wagePerHour;
                totalWage += dailyWage;

                Console.WriteLine($"Day {totalWorkingDays}: Hours = {empHours}, Daily Wage = Rs.{dailyWage}, Total Hours = {totalWorkingHours}");
            }

            // Save total wage inside the company object
            companyEmpWage.totalWage = totalWage;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem ");

            EmployeeWage wageCalculator = new EmployeeWage();

            // Create companies
            CompanyEmpWage tata = new CompanyEmpWage("Tata", 20, 20, 100);
            CompanyEmpWage reliance = new CompanyEmpWage("Reliance", 25, 22, 110);
            CompanyEmpWage infosys = new CompanyEmpWage("Infosys", 18, 26, 95);

            wageCalculator.ComputeWage(tata);
            wageCalculator.ComputeWage(reliance);
            wageCalculator.ComputeWage(infosys);

            tata.PrintWage();
            reliance.PrintWage();
            infosys.PrintWage();
        }
    }
}
