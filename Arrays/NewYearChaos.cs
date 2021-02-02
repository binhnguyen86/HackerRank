using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class NewYearChaos
{
    string inputLocation = @"D:\Projects\HackerRank\Arrays\DataInput\inputNewYearChaos.txt";

    public void Start()
    {

        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }

        int t = Convert.ToInt32(lines[0]);

        for (int tItr = 1; tItr < lines.Count-1; tItr++)
        {
            //Console.WriteLine(lines[tItr]);
            int n = Convert.ToInt32(lines[tItr]);
            int[] q = Array.ConvertAll(lines[tItr + 1].Split(' '), qTemp => Convert.ToInt32(qTemp));
            tItr++;
            MinimumBribes(q);
        }

    }

    static void MinimumBribes(int[] q)
    {
        int[] originalQ = new int[q.Length];
        //Console.WriteLine(q.Length);
        for (int i = 0; i < originalQ.Length; i++)
        {
            originalQ[i] = i + 1;

        }
        int result = 0;
        for (int i = 0; i < q.Length; i++)
        {
            if (q[i] != originalQ[i])
            {
                int fromIndex = FindIndex(originalQ, q[i], i);
                if (fromIndex == -1)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                // get index cuar original
                Bride(fromIndex, i, ref originalQ);
                int d = fromIndex - i;
                result += d;              
            }
        }

        Console.WriteLine(result);
    }

    private static void Bride(int from, int to,ref int [] arr)
    {
        int n = from - to;
        for (int i = 0; i < n; i++)
        {
            int swapValue = arr[from - i];
            arr[from - i] = arr[from - i - 1];
            arr[from - i - 1] = swapValue;
        }
    }

    private static int FindIndex(int[] arr, int v, int currentIndex)
    {
        for (int i = currentIndex+1; i < currentIndex + 3; i++)
        {
            if (v == arr[i])
            {
                return i;
            }
        }
        return -1;
    }
    

}