using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterprocessCommunication
{
    public abstract class ArraySumCalculator
    {
        public abstract long Calculate(int[] array);
        public TimeSpan CalculateTime(int[] array)
        {
            var stopwatch = Stopwatch.StartNew();
            _ = Calculate(array);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
