using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class MinimumSwap
{
    string inputLocation = @"D:\Projects\HackerRank\Arrays\DataInput\inputMinimumSwap.txt";

    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }

        int t = Convert.ToInt32(lines[0]);
        int[] arr = Array.ConvertAll(lines[1].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        int res = MinimumSwaps(arr);
        Console.WriteLine(res);
    }

    static int MinimumSwaps(int[] q)
    {
        int swapCount = 0;
        for (int i = 0; i < q.Length; i++)
        {
            int expectedNum = i + 1;            
            while (q[i] != expectedNum)
            {
                int tmp = q[q[i] - 1];
                //Console.WriteLine(tmp);
                q[q[i] - 1] = q[i];
                //Console.WriteLine(q[q[i] - 1]);
                q[i] = tmp;
                //Console.WriteLine(q[i]);
                swapCount++;
                

                if (swapCount > 10)
                {
                    break;
                }
            }

            // int expectedNum = i + 1;
            // if (q[i] != expectedNum)
            // {
            //     int swapIndex = Array.IndexOf(q, expectedNum);
            //     q[swapIndex] = q[i];
            //     q[i] = expectedNum;
            //     swapCount++;
            // }
        }
        return swapCount;
    }    

}