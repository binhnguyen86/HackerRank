using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ArrayLeftRotate
{
    string inputLocation = @"D:\Projects\HackerRank\Arrays\DataInput\inputArraysLeftRotate.txt";

    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string[] nd = lines[0].Split(' ');
        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(lines[1].Split(' '), aTemp => Convert.ToInt32(aTemp));
        int[] result = rotLeft(a, d);
        Console.WriteLine(string.Join(" ", result));
    }

    static int[] rotLeft(int[] a, int d)
    {
        while (d > a.Length)
        {
            d -= a.Length;
        }
        int newIndexOfFirstItem = a.Length - d;
        int[] result = new int[a.Length];
        int j = 0;
        for (int i = 0; i < a.Length; i++)
        {
            j = newIndexOfFirstItem + i;
            if (j >= result.Length)
            {
                j = j - result.Length;
            }
            result[j] = a[i];
        }
        return result;
    }

}