using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
public class JumpingTheCloud
{
    string inputLocation = @"D:\Projects\HackerRank\WarmUpChanllenge\DataInput\inputJumpingTheCloud.txt";
    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        int n = Convert.ToInt32(lines[0]);
        int[] c = Array.ConvertAll(lines[1].Split(' '), arTemp => Convert.ToInt32(arTemp));
        int result = JumpingOnClouds(c);
        Console.WriteLine(result);
    }

    static int JumpingOnClouds(int[] c)
    {
        int jumpCount = 0;
        for (int i = 0; i < c.Length; i ++)
        {
            //Console.Write(i);
            int nextStep = i + 2;
            if (nextStep < c.Length && c[nextStep] == 0)
            {
                ++i;
            }
            jumpCount++;
            
        }
        return jumpCount-1;
    }

}