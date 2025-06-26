using System;
using System.Collections.Generic;

namespace EmployeeWage
{
    // Interface
    public interface IEmployeeWage
    {
        void AddCompanyEmpWage(string company, int wagePerHour, int maxWorkingDays, int maxWorkingHours);
        void ComputeWage();
    }

    public class CompanyEmpWage
    {
        public string Company { get; }
        public int WagePerHour { get; }
        public int MaxWorkingDays { get; }
        public int MaxWorkingHours { get; }
        public int TotalWage { get; set; }

        public CompanyEmpWage(string company, int wagePerHour, int maxWorkingDays, int maxWorkingHours)
        {
            Company = company;
            WagePerHour = wagePerHour;
            MaxWorkingDays = maxWorkingDays;
            MaxWorkingHours = maxWorkingHours;
            TotalWage = 0;
        }

        public void PrintWage()
        {
            Console.WriteLine($"Total Wage for Company {Company}: Rs.{TotalWage}");
        }
    }

    // Implementing class
    public class EmployeeWageBuilder : IEmployeeWage
    {
        private List<CompanyEmpWage> companyList = new List<CompanyEmpWage>();

        // Add company to list
        public void AddCompanyEmpWage(string company, int wagePerHour, int maxWorkingDays, int maxWorkingHours)
        {
            companyList.Add(new CompanyEmpWage(company, wagePerHour, maxWorkingDays, maxWorkingHours));
        }

        // Compute wage for all companies
        public void ComputeWage()
        {
            foreach (CompanyEmpWage company in companyList)
            {
                company.TotalWage = ComputeWageForCompany(company);
                company.PrintWage();
            }
        }
        private int ComputeWageForCompany(CompanyEmpWage company)
        {
            const int IS_ABSENT = 0, IS_FULL_TIME = 1, IS_PART_TIME = 2;
            int totalHours = 0, totalDays = 0, totalWage = 0;

            Random random = new Random();

            while (totalDays < company.MaxWorkingDays && totalHours < company.MaxWorkingHours)
            {
                totalDays++;

                int empType = random.Next(0, 3);
                int empHours = empType switch
                {
                    IS_FULL_TIME => 8,
                    IS_PART_TIME => 4,
                    _ => 0,
                };

                if (totalHours + empHours > company.MaxWorkingHours)
                {
                    empHours = company.MaxWorkingHours - totalHours;
                }

                totalHours += empHours;
                int dailyWage = empHours * company.WagePerHour;
                totalWage += dailyWage;

                Console.WriteLine($"[{company.Company}] Day {totalDays}: Hours = {empHours}, Daily Wage = Rs.{dailyWage}");
            }

            return totalWage;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the employee wage problem");

            IEmployeeWage wageBuilder = new EmployeeWageBuilder();

            wageBuilder.AddCompanyEmpWage("Tata", 20, 20, 100);
            wageBuilder.AddCompanyEmpWage("Reliance", 25, 22, 110);
            wageBuilder.AddCompanyEmpWage("Infosys", 18, 24, 95);

            wageBuilder.ComputeWage();
        }
    }
}
