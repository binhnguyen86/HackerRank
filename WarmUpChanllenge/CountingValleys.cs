using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
public class CountingValleys
{
    string inputLocation = @"D:\Projects\HackerRank\WarmUpChanllenge\inputCountingValley.txt";
    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        int n = Convert.ToInt32(lines[0]);
        string path = lines[1];
        int result = Count(n, path);
        Console.WriteLine(result);
    }

    static int Count(int steps, string path)
    {
        const char up = 'U';
        int heightLevel = 0;
        int nextHeighLevel = 0;
        int countValley = 0;
        for (int i = 0; i < path.Length-1; i++)
        {
            heightLevel = path[i] == up ? heightLevel + 1 : heightLevel - 1;
            nextHeighLevel = path[i + 1] == up ? heightLevel + 1 : heightLevel - 1;
            if ((heightLevel == 0 && nextHeighLevel == -1)
                || (heightLevel == -1 && i == 0))
            {
                countValley++;
            }
        }
        return countValley;
    }

}