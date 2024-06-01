using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace InterprocessCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array100k = GenerateRandomArray(100_000);
            int[] array1m = GenerateRandomArray(1_000_000);
            int[] array10m = GenerateRandomArray(10_000_000);

            TestArraySumCalculators(array100k, "100,000 elements");
            TestArraySumCalculators(array1m, "1,000,000 elements");
            TestArraySumCalculators(array10m, "10,000,000 elements");
        }

        private static void TestArraySumCalculators(int[] array, string description)
        {
            Console.WriteLine($"Testing with {description}");

            var simpleCalculator = new SimpleArraySumCalculator();
            var parallelThreadsCalculator = new ParallelArraySumCalculatorUsingThreads();
            var parallelLinqCalculator = new ParallelArraySumCalculatorUsingLinq();

            Console.WriteLine("Simple calculation:");
            Console.WriteLine($"Time: {simpleCalculator.CalculateTime(array).TotalMilliseconds} ms");
            Console.WriteLine($"Result: {simpleCalculator.Calculate(array)}");

            Console.WriteLine("Parallel calculation (using Threads):");
            Console.WriteLine($"Time: {parallelThreadsCalculator.CalculateTime(array).TotalMilliseconds} ms");
            Console.WriteLine($"Result: {parallelThreadsCalculator.Calculate(array)}");

            Console.WriteLine("Parallel calculation (using LINQ):");
            Console.WriteLine($"Time: {parallelLinqCalculator.CalculateTime(array).TotalMilliseconds} ms");
            Console.WriteLine($"Result: {parallelLinqCalculator.Calculate(array)}");

            Console.WriteLine();
        }

        private static int[] GenerateRandomArray(int size)
        {
            var random = new Random();
            return Enumerable.Range(0, size).Select(_ => random.Next(0, 100)).ToArray();
        }
    }
}
