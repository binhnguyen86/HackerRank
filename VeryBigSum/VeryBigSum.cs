using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class VeryBigSum
{
    // string inputLocation = @"D:\Projects\HackerEarth\SplitHouse\brick_input0.txt";
    public void Start()
    {
        //for()
    }

    static long aVeryBigSum(long[] ar)
    {
        long result = 0;
        foreach (long i in ar)
        {
            result += i;
        }
        return result;
    }

}