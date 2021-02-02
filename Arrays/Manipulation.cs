using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Manipulation
{
    string inputLocation = @"D:\Projects\HackerRank\Arrays\DataInput\inputArraysManipulation.txt";

    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }

        string[] nm = lines[0].Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[][] queries = new int[m][];

        //Console.WriteLine(m);
        for (int i = 0; i < m; i++)
        {
            
            queries[i] = Array.ConvertAll(lines[i+1].Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
        }

        long result = ArrayManipulation(n, queries);
        //Console.WriteLine(result);
    }

    static long ArrayManipulation(int n, int[][] queries)
    {
        //Dictionary<int, long> arr = new Dictionary<int, long>();
        long[] arr = new long[n];
        long[] drr = new long[n + 1];
        initializeDiffArray(arr, drr);
        PrintSingleArray(drr);
        Console.WriteLine("----------");
        for (int i = 0; i < queries.Length; i++)
        {
            int a = queries[i][0];
            int b = queries[i][1];
            int k = queries[i][2];
            update(drr, a - 1, b - 1, k);
            PrintSingleArray(drr);
            //int j = i-1;
            // while (j > 0)
            // {
            //     if (a > queries[j][0] && a < queries[j][1]
            //         || b > queries[j][0] && b < queries[j][1])
            //     {
            //         max += k;
            //         break;
            //     }
            //     j--;
            // }
            // /////
            // for (int j = a - 1; j <= b - 1; j++)
            // {
            //     arr[j] += k;
            //     if (arr[j] > max || max == 0)
            //     {
            //         max = arr[j];
            //     }
            // }

        }
        return PrintMax(arr, drr);
    }

    static void initializeDiffArray(long[] A, long[] D)
    {

        int n = A.Length;

        D[0] = A[0];
        D[n] = 0;
        for (int i = 1; i < n; i++)
            D[i] = A[i] - A[i - 1];
    }

    static void update(long[] D, int l, int r, int x)
    {
        D[l] += x;
        D[r + 1] -= x;

        
    }

    static int printArray(int[] A, int[] D)
    {
        for (int i = 0; i < A.Length; i++)
        {

            if (i == 0)
                A[i] = D[i];

            // Note that A[0] or D[0] decides 
            // values of rest of the elements. 
            else
                A[i] = D[i] + A[i - 1];

            Console.Write(A[i] + " ");
        }

        Console.WriteLine();

        return 0;
    }

    static long PrintMax(long[] A, long[] D)
    {
        long max = 0;
        for (int i = 0; i < A.Length; i++)
        {
            
            if (i == 0){
                A[i] = D[i];
            }
            else{
                A[i] = D[i] + A[i - 1];
            }

            if (max == 0 || max < A[i])
            {
                max = A[i];
            }
        }

        return max;
    }

    static void PrintSingleArray(long[] D)
    {
        for (int i = 0; i < D.Length; i++)
        {
            Console.Write(D[i] + " ");
        }
        Console.WriteLine("");
        Console.WriteLine("===");
    }

}