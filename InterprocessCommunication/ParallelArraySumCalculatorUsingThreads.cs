using System.Diagnostics;

namespace InterprocessCommunication
{
    public class ParallelArraySumCalculatorUsingThreads : ArraySumCalculator
    {
        public override long Calculate(int[] array)
        {
            long sum = 0;
            int chunkSize = Math.Max(1, array.Length / Environment.ProcessorCount);

            Thread[] threads = new Thread[Environment.ProcessorCount];

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int startIndex = i * chunkSize;
                int endIndex = Math.Min((i + 1) * chunkSize, array.Length);

                threads[i] = new Thread(() =>
                {
                    long threadSum = 0;
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        threadSum += array[j];
                    }
                    Interlocked.Add(ref sum, threadSum);
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            return sum;
        }

        public TimeSpan CalculateTime(int[] array)
        {
            var stopwatch = Stopwatch.StartNew();
            Calculate(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}