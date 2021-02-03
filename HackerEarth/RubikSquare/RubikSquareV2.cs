using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class RubikSquareV2
{
    string inputLocation = @"D:\Projects\HackerEarth\RubikSquare\input.txt";
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
        int[,] rubikData = new int[N, N];
        lines.RemoveAt(0);
        ConvertMultiLinesToInt(N, N, rubikData, lines.ToArray());
        GridPrint(N, rubikData);
        Console.WriteLine("TO:");
        ConvertToRollData(R, lines[lines.Count - 2], N, rubikData, true);
        GridPrint(N, rubikData);
        ConvertToRollData(C, lines[lines.Count - 1], N, rubikData, false);

        //Console.WriteLine("TO:{0}, {1}", rowRoll.Count, colRoll.Count);
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

        // foreach (var rollData in rowRoll)
        // {
        //     int rowIndex = rollData.Key - 1;
        //     RowRoll(N, N, rowIndex, rollData.Value, rubikData);
        // }

        // for (int i = 0; i < rowRoll.Length; i++)
        // {
        //     int rowIndex = rowRoll[i] - 1;
        //     RowRoll(N, N, rowIndex, 1, rubikData);
        // }

        //GridPrint(N, rubikData);

        // foreach (var rollData in colRoll)
        // {
        //     int colIndex = rollData.Key - 1;
        //     ColRoll(N, N, colIndex, rollData.Value, rubikData);
        // }

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
        GridPrint(N, rubikData);
    }

    private void ConvertMultiLinesToInt(int rowNumber, int colNumber, int[,] rubikData, string[] lines)
    {
        int rowIndex;
        string[] line;
        for (int i = 0; i < rowNumber; i++)
        {
            line = lines[i].Split(' ');
            rowIndex = i;
            for (int colIndex = 0; colIndex < line.Length; colIndex++)
            {
                int convertedNum;
                if (int.TryParse(line[colIndex], out convertedNum))
                {
                    rubikData[rowIndex, colIndex] = convertedNum;
                }
            }
        }
    }

    private void GridPrint(int rowLength, int[,] rubikData)
    {
        StringBuilder outputStr = new StringBuilder();
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < rowLength; j++)
            {
                outputStr.Append(rubikData[i, j] + " ");
            }
            outputStr.Append("\n");
        }
        Console.WriteLine("{0}", outputStr);
    }

    private void RowRoll(int rowLength, int colLength, int rowIndex, int rollNum, int[,] rubikData)
    {
        if (rollNum % rowLength == 0)
        {
            return;
        }

        int[] rowTmp = new int[rowLength];
        for (int i = 0; i < rowLength; i++)
        {
            rowTmp[(i + rollNum) % rowLength] = rubikData[rowIndex, i];
        }

        for (int j = 0; j < rowTmp.Length; j++)
        {
            //Copy row back in place
            rubikData[rowIndex, j] = rowTmp[j];
        }
    }

    private void ColRoll(int rowLength, int colLength, int colIndex, int rollNum, int[,] rubikData)
    {
        if (rollNum % colLength == 0)
        {
            return;
        }

        int[] colTmp = new int[colLength];
        for (int i = 0; i < colLength; i++)
        {
            colTmp[(i + rollNum) % rowLength] = rubikData[i, colIndex];
        }

        for (int j = 0; j < colTmp.Length; j++)
        {
            //Copy row back in place
            rubikData[j, colIndex] = colTmp[j];
        }
    }

    private void ConvertToRollData(int length, string line, int N, int[,] rubikData, bool isRow)
    {
        string[] chars = line.Split(' ');
        //int[] result = new int[length];
        for (int j = 0; j < chars.Length; j++)
        {
            int convertedNum;
            if (int.TryParse(chars[j], out convertedNum))
            {
                if (isRow)
                {
                    int rowIndex = convertedNum - 1;
                    int lastCell = rubikData[rowIndex, N - 1];
                    for (int k = N - 1; k > 0; k--)
                    {
                        rubikData[rowIndex, k] = rubikData[rowIndex, k - 1];
                    }
                    rubikData[rowIndex, 0] = lastCell;
                }
                else
                {
                    int colIndex = convertedNum - 1;
                    int lastCell = rubikData[N - 1, colIndex];
                    for (int k = N - 1; k > 0; k--)
                    {
                        rubikData[k, colIndex] = rubikData[k - 1, colIndex];
                    }
                    rubikData[0, colIndex] = lastCell;
                }
            }
        }
    }

    private void ConvertToRollJustData(Dictionary<int, int> data, int length, string line)
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