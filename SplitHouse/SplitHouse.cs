using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class SplitHouse
{
    string inputLocation = @"D:\Projects\HackerEarth\SplitHouse\brick_input0.txt";
    public void Start()
    {
        //FibonacciTest();
        //ColorTheBrickTest();
        HappinessLiftTest();
    }

    private void SplitHouseTest(int rowLength, int[,] rubikData)
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        int N = Convert.ToInt32(lines[0]);
        string villageGrid = lines[1];
        bool cannotSplit = villageGrid.Contains("HH");
        Console.WriteLine(cannotSplit ? "NO" : "YES");
        if (!cannotSplit)
        {
            Console.WriteLine(villageGrid.Replace('.', 'B'));
        }
    }

    private void FibonacciTest()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string[] line = lines[0].Split(' ');
        long f1 = Convert.ToInt64(line[0]);
        long f2 = Convert.ToInt64(line[1]);

        long q = Convert.ToInt32(lines[1]);
        lines.RemoveRange(0, 2);
        long x = 0;
        for (int i = 0; i < 25; i++)
        {
            x = Convert.ToInt64(lines[i]);
            if (IsFibonacci(x, f2, f1))
            {
                Console.WriteLine("YES {0}", x);
            }
            else
            {
                Console.WriteLine("NO {0}", x);
            }
        }
    }

    private bool IsFibonacci(long fn, long fn_1, long fn_2)
    {

        if ((fn_1 != 0 && fn == fn_1)
            || (fn_2 != 0 && fn == fn_2))
        {
            return true;
        }

        if (fn == 0 || (fn_1 == 0 && fn_2 == 0))
        {
            return false;
        }

        long f = fn_1 + fn_2;
        if (f < fn)
        {
            return IsFibonacci(fn, f, fn_1);
        }
        else if (f == fn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CountMatrixNumberTest()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string[] line = lines[0].Split(' ');
        int n = Convert.ToInt32(line[0]);
        int m = Convert.ToInt32(line[1]);
        int q = Convert.ToInt32(line[2]);
        List<long> cache = new List<long>(q);
        //Dictionary<string, int> cache = new Dictionary<string, int>();
        //int[][] maxtrix = new int[n][];
        lines.RemoveAt(0);
        int toggleCount = 0;
        int sum = 0;
        for (int i = 0; i < q; i++)
        {
            string key = lines[i];
            line = lines[i].Split(' ');
            if (Convert.ToInt32(line[0]) == 1)
            {
                int x = Convert.ToInt32(line[1]) - 1;
                int y = Convert.ToInt32(line[2]) - 1;
                cache.Add((long)x * (m - 1) + (long)y);
            }
            else
            {
                toggleCount++;
            }
        }

        foreach (var point in cache.GroupBy(value => value)
                        .Select(group => new
                        {
                            Value = group.Key,
                            Count = group.Count()
                        }))
        {
            if (point.Count % 2 != 0)
            {
                sum++;
            }
        }

        ToggleMatrix(n, m, toggleCount, sum);
    }

    private void ToggleMatrix(int n, int m, int toggleCount, int sum)
    {
        int loop = toggleCount % 2 == 0 ? 0 : 1;
        long result = 0;
        Console.WriteLine("toggleCount: {0}", toggleCount);
        if (loop == 0)
        {
            result = sum;
        }
        else
        {
            result = ((long)n * m) - (long)sum;
        }
        Console.WriteLine("{0}", result);
    }

    private void ColorTheBrickTest()
    {
        inputLocation = @"D:\Projects\HackerEarth\SplitHouse\brick_input2.txt";
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string[] line = lines[0].Split(' ');
        int n = Convert.ToInt32(line[0]);
        int k = Convert.ToInt32(line[1]);

        line = lines[1].Split(' ');
        int coloredBrick = 0;
        int previousBrick = 1;
        int nSpace = 0;
        // neu co 1 khoang cach n = 4 minh se co 4! hoan vi
        // nhung o day minh chi chon nhung hoan vi bat dau bang so lon nhat va nho nhat
        // mot so thi se co n-1 hoan vi => tong se co 2(n-1) hoan vi co the co
        int numberOfBrickSwapOfBlock = 0;
        int numberSoloBrick = 0;
        int numberSoloSpace = 0;
        //int numberOfBlockBrick = 1;
        for (int i = 0; i < k; i++)
        {
            coloredBrick = Convert.ToInt32(line[i]);
            nSpace = (coloredBrick - previousBrick) - 1;
            if (nSpace > 0)
            {
                if (nSpace > 1)
                {
                    numberOfBrickSwapOfBlock = 2 * (nSpace - 1);
                    numberSoloSpace++;
                }

                if (nSpace == 1)
                {
                    numberSoloBrick++;
                }
            }
            previousBrick = coloredBrick;
            if (i == k - 1 && n > coloredBrick)
            {
                nSpace = (n - coloredBrick);
                if (nSpace >= 0)
                {
                    if (nSpace > 1)
                    {
                        numberOfBrickSwapOfBlock++;
                        numberSoloSpace++;
                    }

                    if (nSpace == 1)
                    {
                        numberSoloBrick++;
                    }
                }
            }
        }

        double result = Math.Pow(numberOfBrickSwapOfBlock, numberSoloSpace + numberSoloBrick);
        if (numberSoloSpace + numberSoloBrick > 1)
        {
            result += Factorial(numberSoloBrick + numberSoloSpace);
        }
        Console.WriteLine("{0}", result);
    }
    private long Factorial(int n)
    {
        long res = 1;
        while (n != 1)
        {
            res = res * n;
            n = n - 1;
        }
        return res;
    }

    private void HappinessLiftTest(){
        inputLocation = @"D:\Projects\HackerEarth\SplitHouse\lift_input0.txt";
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string[] line = lines[0].Split(' ');
        int n = Convert.ToInt32(line[0]);
        int k = Convert.ToInt32(line[1]);

        long s = k + ((k - 1) * (k) / 2) * Factorial(k - 1) + k * Factorial(n - k);
        Console.WriteLine("{0}", s);
    }

}