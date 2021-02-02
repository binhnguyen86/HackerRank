using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
public class RepeatedString
{
    string inputLocation = @"D:\Projects\HackerRank\WarmUpChanllenge\DataInput\inputRepeatedString.txt";
    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string s = lines[0];
        //Console.WriteLine(lines[1]);
        long n = Convert.ToInt32(lines[1]);
        long result = RepeatedStringCount(s, n);
        Console.WriteLine(result);
    }

    static long RepeatedStringCount(string s, long n)
    {
        const char searchChar = 'a';
        long repeatedCount = n / s.Length;
        long charLeftCount = n - (repeatedCount * s.Length);
        string afterCut = s.Substring(0, (int)charLeftCount);

        int searchCount = s.Split(searchChar).Length - 1;
        int searchCharLeftCount = afterCut.Split(searchChar).Length - 1;
        //Console.WriteLine(searchCount - 1);
        return (repeatedCount*searchCount) + searchCharLeftCount;

    }

}