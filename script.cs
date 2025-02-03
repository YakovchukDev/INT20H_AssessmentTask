using System;

namespace AgeCalculator
{
    public class AgeCalculator
    {
        static void Main(string[] args)
        {
            Console.Write("Input date (yyyy-mm-dd): ");
            string input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime birthDate) &&
                (DateTime.Today >= birthDate))
            {
                int age = GetAge(birthDate);
                Console.WriteLine($"Your age - {age} years");
            }
            else
            {
                Console.WriteLine("Invalid date");
            }
        }
        public static int GetAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;
            if (currentDate.Month < birthDate.Month ||
               (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
    }
}
