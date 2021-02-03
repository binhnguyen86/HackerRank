using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class RubikSquareV1
{
    string inputLocation = @"D:\Projects\HackerEarth\RubikSquare\input8.txt";
    public void Start()
    {
        var lines = new List<string>();
        foreach (string row in File.ReadLines(inputLocation, Encoding.UTF8))
        {
            lines.Add(row);
        }
        string[] line = lines[0].Split(' ');
        int N = Convert.ToInt32(line[0]);
        int R = Convert.ToInt32(line[1]);
        int C = Convert.ToInt32(line[2]);
        int[][] rubikData = new int[N][];
        Dictionary<int, int> rowRoll = new Dictionary<int, int>(N);
        Dictionary<int, int> colRoll = new Dictionary<int, int>(N); 
        ConvertToRollData(rowRoll, R, lines[lines.Count - 2]);
        ConvertToRollData(colRoll, C, lines[lines.Count - 1]);
        lines.RemoveAt(0);
        rubikData = ConvertMultiLinesToInt(N, N, lines.ToArray());
        //GridPrint(N, rubikData);
        Console.WriteLine("TO:{0}, {1}", rowRoll.Count, colRoll.Count);
        /* 
        for (int i = 0; i < rowRoll.Length; i++)
        {
            int rowIndex = rowRoll[i] - 1;
            int lastCell = rubikData[rowIndex][N - 1];
            for (int j = N - 1; j > 0; j--)
            {
                rubikData[rowIndex][j] = rubikData[rowIndex][j - 1];
            }
            rubikData[rowIndex][0] = lastCell;
        } 
        */

        foreach (var rollData in rowRoll)
        {
            int rowIndex = rollData.Key - 1;
            RowRoll(N, N, rowIndex, rollData.Value, rubikData);
        }

        // for (int i = 0; i < rowRoll.Length; i++)
        // {
        //     int rowIndex = rowRoll[i] - 1;
        //     RowRoll(N, N, rowIndex, 1, rubikData);
        // }

        //GridPrint(N, rubikData);

        foreach (var rollData in colRoll)
        {
            int colIndex = rollData.Key - 1;
            ColRoll(N, N, colIndex, rollData.Value, rubikData);
        }

        // for (int i = 0; i < colRoll.Length; i++)
        // {
        //     int colIndex = colRoll[i] - 1;
        //     int lastCell = rubikData[N - 1][colIndex];
        //     for (int j = N - 1; j > 0; j--)
        //     {
        //         rubikData[j][colIndex] = rubikData[j - 1][colIndex];
        //     }
        //     rubikData[0][colIndex] = lastCell;
        // }
        Console.WriteLine("Result:");
        //GridPrint(N, rubikData);
    }

    private int[][] ConvertMultiLinesToInt(int rowNumber, int colNumber, string[] lines)
    {
        int[][] result = new int[rowNumber][];
        int rowIndex;
        string[] line;
        for (int i = 0; i < rowNumber; i++)
        {
            line = lines[i].Split(' ');
            rowIndex = i;
            result[rowIndex] = new int[colNumber];
            for (int colIndex = 0; colIndex < line.Length; colIndex++)
            {
                int convertedNum;
                if (int.TryParse(line[colIndex], out convertedNum))
                {
                    result[rowIndex][colIndex] = convertedNum;
                }
            }
        }
        return result;
    }

    private void GridPrint(int rowLength, int[][] rubikData)
    {
        StringBuilder outputStr = new StringBuilder();
        for (int i = 0; i < rubikData.Length; i++)
        {
            for (int j = 0; j < rubikData[i].Length; j++)
            {
                outputStr.Append(rubikData[i][j] + " ");
            }
            outputStr.Append("\n");
        }
        Console.WriteLine("{0}", outputStr);
    }

    private void RowRoll(int rowLength, int colLength, int rowIndex, int rollNum, int[][] rubikData)
    {
        int realRollNum = rollNum;
        while (realRollNum >= rowLength)
        {
            realRollNum -= rowLength;
        }

        int[] rowTmp = new int[realRollNum];
        for (int i = 0; i < realRollNum; i++)
        {
            rowTmp[i] = rubikData[rowIndex][(rowLength - 1) - i];
        }


        for (int i = rowLength - 1; i >= 0; i--)
        {
            if (i - realRollNum < 0)
            {
                rubikData[rowIndex][i] = rowTmp[realRollNum - i - 1];
            }
            else
            {
                rubikData[rowIndex][i] = rubikData[rowIndex][i - realRollNum];
            }
        }
    }

    private void ColRoll(int rowLength, int colLength, int colIndex, int rollNum, int[][] rubikData)
    {
        int realRollNum = rollNum;
        while (realRollNum >= colLength)
        {
            realRollNum -= colLength;
        }

        int[] colTmp = new int[realRollNum];
        for (int i = 0; i < realRollNum; i++)
        {
            
            colTmp[i] = rubikData[(colLength - 1) - i][colIndex];
        }

        for (int i = colLength - 1; i >= 0; i--)
        {
            if (i - realRollNum < 0)
            {
                rubikData[i][colIndex] = colTmp[realRollNum - i - 1];
            }
            else
            {
                rubikData[i][colIndex] = rubikData[i - realRollNum][colIndex];
            }
        }
    }

    private void ConvertToRollData(Dictionary<int, int> data, int length, string line)
    {
        //Dictionary<int, int> resultData = new Dictionary<int, int>();
        string[] chars = line.Split(' ');
        //int[] result = new int[length];
        for (int j = 0; j < chars.Length; j++)
        {
            int convertedNum;
            if (int.TryParse(chars[j], out convertedNum))
            {
                if (data.Keys.Contains(convertedNum))
                {
                    data[convertedNum]++;
                }
                else
                {
                    data.Add(convertedNum, 1);
                }
                //result[j] = convertedNum;
            }
        }
    }
}