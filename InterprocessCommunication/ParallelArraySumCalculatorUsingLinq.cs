using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterprocessCommunication
{
    public class ParallelArraySumCalculatorUsingLinq : ArraySumCalculator
    {
        public override long Calculate(int[] array)
        {
            return array.AsParallel().Sum();
        }
    }
}
