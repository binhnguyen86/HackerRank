using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

public class RansomNote
{
    string inputLocation = @"D:\Projects\HackerRank\DictionaryAndHashMap\DataInput\inputRansomNote.txt";

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

        string[] magazine = lines[1].Split(' ');

        string[] note = lines[2].Split(' ');

        CheckMagazine(magazine, note);
    }

    static void CheckMagazine(string[] magazine, string[] note)
    {
        Dictionary<string, int> data = new Dictionary<string, int>();
        foreach (string str in magazine)
        {
            if (!data.ContainsKey(str))
            {
                data.Add(str, 0);
            }
            data[str] ++;
        }
        foreach (string str in note)
        {
            if (!data.ContainsKey(str))
            {
                Console.WriteLine("No");
                return;
            }
            data[str]--;
        }

        foreach (var d in data)
        {
            if (d.Value < 0)
            {
                Console.WriteLine("No");
                return;
            }
        }
        Console.WriteLine("Yes");
    }

}