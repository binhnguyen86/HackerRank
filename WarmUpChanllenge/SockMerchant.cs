using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class SockMerchant
{
    string inputLocation = @"D:\Projects\HackerRank\WarmUpChanllenge\input.txt";
    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        int n = Convert.ToInt32(lines[0]);
        int[] ar = Array.ConvertAll(lines[1].Split(' '), arTemp => Convert.ToInt32(arTemp));
        int result = FindPair(n, ar);
        Console.WriteLine(result);
    }

    static int FindPair(int n,  int[] ar)
    {
        //Dictionary<int, int> stockDic = new Dictionary<int, int>();
        int[] f = new int[101];
        f[0]++;
        foreach (int i in ar)
        {
            // if (!stockDic.Keys.ToList().Contains(i))
            // {
            //     stockDic.Add(i, 1);
            // }
            // else
            // {
            //     stockDic[i]++;
            // }
            f[i]++;
        }
        
        int result = 0;
        // foreach (var p in stockDic)
        // {
        //     result += p.Value / 2;
        // }
        return result;
    }

}