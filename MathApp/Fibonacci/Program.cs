using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            bool useRecursive = true;

            new Program().Run(useRecursive);
        }

        private void Run(bool useRecursive)
        {
            Console.Write("n = ");
            bool success = Int32.TryParse(Console.ReadLine(), out int number);

            if (!success)
            {
                Console.WriteLine();
                Run(useRecursive);
            }
            else
            {
                if (!useRecursive)
                    PrintFibonacci(number);
                else
                    RunFibonacciRecursively(number);
            }
        }

        // 17A - Loop
        public void PrintFibonacci(int loopCount)
        {
            int[] lastNumbers = new int[2];

            // Init the first two values in the sequence
            lastNumbers[0] = 0;
            lastNumbers[1] = 1;
            Console.Write("0, 1, ");

            for (int i = 2; i < loopCount; i++)
            {
                // Calculate new number in the sequence
                int newNumber = lastNumbers[0] + lastNumbers[1];

                Console.Write($"{newNumber}");

                // Update values for the new iteration
                lastNumbers[0] = lastNumbers[1];
                lastNumbers[1] = newNumber;

                if (i < loopCount - 1)
                    Console.Write(", ");
            }
        }

        // 17B - Recursively
        public int RunFibonacciRecursively(int loopCount)
        {
            // Init the first two values in the sequence
            int[] lastNumbers = new int[2];
            lastNumbers[0] = 0;
            lastNumbers[1] = 1;
            Console.WriteLine($"f(1) = 1");

            // Skip the first 2, as they're given
            int iterationCount = 1;

            int result = PrintFibonacciRecursively(loopCount, lastNumbers, iterationCount);
            Console.WriteLine($"resultaat: {result}");

            return result;
        }

        public int PrintFibonacciRecursively(int loopCount, int[] lastNumbers, int iterationCount)
        {
            // Calculate new number in the sequence
            int newNumber = lastNumbers[0] + lastNumbers[1];
            Console.WriteLine($"f({iterationCount + 1}) = f({iterationCount}) + f({iterationCount - 1}) = {newNumber}");

            // Update values for the new iteration
            lastNumbers[0] = lastNumbers[1];
            lastNumbers[1] = newNumber;

            iterationCount++;

            if (iterationCount < loopCount)
            {
                return PrintFibonacciRecursively(loopCount, lastNumbers, iterationCount);
            }
            else
                return newNumber;
        }
    }
}
