using System;

namespace EmployeeWage
{
    class EmpolyeeWage
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee wage problem");

            const int IS_PRESENT = 1;

            Random random = new Random();
            int empCheck = random.Next(0, 2); // 0 or 1

            if (empCheck == IS_PRESENT)
            {
                Console.WriteLine("Employee is Present");
            }
            else
            {
                Console.WriteLine("Employee is Absent");
            }

        }
    }
}