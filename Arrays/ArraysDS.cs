using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ArraysDS
{
    string inputLocation = @"D:\Projects\HackerRank\Arrays\DataInput\input2dArrays.txt";

    public void Start()
    {
        int[][] arr = new int[6][];
        int i = 0;
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            arr[i] = Array.ConvertAll(row.Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            //Console.WriteLine(arr[i].Length);
            i++;
        }        
        int result = HourglassSum(arr);
        Console.WriteLine(result);
    }

    static int HourglassSum(int[][] arr)
    {
        int reult = -100;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                int sum = arr[row][col] + arr[row][col + 1] + arr[row][col + 2]
                            + arr[row + 1][col + 1]
                            + arr[row + 2][col] + arr[row + 2][col + 1] + arr[row + 2][col + 2];
                if (reult < sum)
                {
                    reult = sum;
                }
            }
                
        }
        return reult;
    }

}