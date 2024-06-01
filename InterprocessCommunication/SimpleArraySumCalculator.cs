using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterprocessCommunication
{
    public class SimpleArraySumCalculator : ArraySumCalculator
{
    public override long Calculate(int[] array)
    {
        long sum = 0;
        foreach (var num in array)
        {
            sum += num;
        }
        return sum;
    }
}
}
