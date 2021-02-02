using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

public class WorldQuant
{
    string inputLocation = @"D:\Projects\HackerRank\WorldQuant\input.txt";

    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }

        int q = Convert.ToInt32(lines[0]);
        lines.RemoveAt(0);

        for (int qItr = 0; qItr < lines.Count - 1; qItr += 2)
        {
            string s1 = lines[qItr];

            string s2 = lines[qItr + 1];

            string result = TwoStrings(s1, s2);

            Console.WriteLine(result);
        }

    }

    static string TwoStrings(string s1, string s2)
    {
        HashSet<char> data = new HashSet<char>();
        foreach (char c in s1)
        {
            data.Add(c);
        }

        foreach (char c in s2)
        {
            if (data.Contains(c))
            {
                return "YES";
            }
        }
        return "NO";

    }


}