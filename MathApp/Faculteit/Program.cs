using System;

namespace Faculteit
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Program().QueryFaculty(false);
            new Program().QueryFaculty(true);
        }

        public void QueryFaculty(bool useRecursive)
        {
            Console.Write("n = ");
            bool success = Int32.TryParse(Console.ReadLine(), out int number);

            if (!success)
            {
                Console.WriteLine();
                QueryFaculty(useRecursive);
            }
            else
            {
                if (useRecursive)
                    PrintFacultyRecursive(number, 1, 1);
                else
                    PrintFaculty(number);
            }
        }

        // 16A - Loop
        public void PrintFaculty(int facultyNumber)
        {
            Console.Write($"{facultyNumber}! =");

            int result = 1;
            for (int i = 0; i < facultyNumber + 0; i++)
            {
                if (i > 0)
                    Console.Write(" X");
                Console.Write($" {i + 1}");
                result *= (i + 1);
            }

            Console.WriteLine($" = {result}");
        }

        // 16B - Recursive
        public int PrintFacultyRecursive(int finalNumber, int currentNumber, int lastValue)
        {
            int currentValue = lastValue;

            if (currentNumber > 1)
            {
                currentValue *= currentNumber;
                Console.WriteLine($"f({currentNumber}) = {currentNumber} x f({currentNumber - 1}) = {currentValue}");
            }
            else
            {
                Console.WriteLine($"f({currentNumber}) = {currentValue}");
            }


            currentNumber++;

            if (currentNumber - 1 != finalNumber)
                return PrintFacultyRecursive(finalNumber, currentNumber, currentValue);
            else
                return currentValue;
        }
    }
}
