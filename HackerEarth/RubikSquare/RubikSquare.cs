using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
public class RubikSquare
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
        int[] rubikData = new int[N * N];
        int[] rowRoll = new int[R];
        int[] colRoll = new int[C];
        rowRoll = ConvertMultiLinesToInt(1, R, new string[1] { lines[lines.Count - 2] });
        colRoll = ConvertMultiLinesToInt(1, C, new string[1] { lines[lines.Count - 1] });
        lines.RemoveAt(0);
        rubikData = ConvertMultiLinesToInt(N, N, lines.ToArray());
        GridPrint(N, rubikData);
        Console.WriteLine("TO:");

        List<int> rowRollList = new List<int>(rowRoll);
        //rowRollList.GroupBy(p => p).Count;

        foreach (var rowRollInList in rowRollList.GroupBy(value => value)
                        .Select(group => new
                        {
                            Value = group.Key,
                            Count = group.Count()
                        }))
        {
            RowRoll(N, N, rowRollInList.Value - 1, rowRollInList.Count, rubikData);
        }

        // for (int i = 0; i < rowRoll.Length; i++)
        // {
        //     RowRoll(N, N, rowRoll[i] - 1, rubikData);
        // }
        GridPrint(N, rubikData);
        List<int> colRollList = new List<int>(colRoll);
        foreach (var colRollInList in colRollList.GroupBy(value => value)
                        .Select(group => new
                        {
                            Value = group.Key,
                            Count = group.Count()
                        }))
        {
            ColRoll(N, N, colRollInList.Value - 1, colRollInList.Count, rubikData);
        }

        // for (int i = 0; i < colRoll.Length; i++)
        // {
        //     ColRoll(N, N, colRoll[i] - 1, rubikData);
        // }
        /* int roll = rowRoll.Length >= colRoll.Length ? rowRoll.Length : colRoll.Length;
        for (int i = 0; i < roll; i++)
        {
            //RowRoll(N, N, rowRoll[i] - 1, rubikData);
            int rowIndex = rowRoll.Length > i ? rowRoll[i] - 1 : -1;
            int colIndex = colRoll.Length > i ? colRoll[i] - 1 : -1;
            RubikRoll(N, rowIndex, colIndex, rubikData);
        } */


        GridPrint(N, rubikData);
    }

    private int[] ConvertLineToInt(int length, string line)
    {
        string[] chars = line.Split(' ');
        int[] result = new int[length];
        for (int j = 0; j < chars.Length; j++)
        {
            result[j] = Convert.ToInt32(chars[j]);
        }
        return result;
    }

    private int[] ConvertMultiLinesToInt(int rowNumber, int colNumber, string[] lines)
    {
        int[] result = new int[rowNumber * colNumber];
        int rowIndex;
        string[] line;
        for (int i = 0; i < rowNumber; i++)
        {
            line = lines[i].Split(' ');
            rowIndex = i * rowNumber;
            for (int colIndex = 0; colIndex < line.Length; colIndex++)
            {
                int convertedNum;
                if (int.TryParse(line[colIndex], out convertedNum))
                {
                    result[rowIndex + colIndex] = convertedNum;
                }
            }
        }
        return result;
    }

    private void RubikRoll(int N, int rowIndex, int colIndex, int[] rubikData)
    {
        int[] row = new int[N];
        int[] col = new int[N];
        int[] cellsIndex = new int[N * 2];
        for (int i = 0; i < N; i++)
        {
            if (rowIndex >= 0)
            {
                int curRowIndex = i + (rowIndex * N);
                row[i] = rubikData[curRowIndex];
                cellsIndex[i] = curRowIndex;
            }

            if (colIndex >= 0)
            {
                int curColIndex = colIndex + (i * N);
                col[i] = rubikData[curColIndex];
                cellsIndex[i + N] = curColIndex;
            }

        }

        int lastRowCell = row[N - 1];
        int lastColCell = col[N - 1];
        for (int i = N - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                row[i] = lastRowCell;
                col[i] = lastColCell;
            }
            else
            {
                row[i] = row[i - 1];
                col[i] = col[i - 1];
            }
        }
        for (int i = 0; i < N; i++)
        {
            if (rowIndex >= 0)
            {
                rubikData[cellsIndex[i]] = row[i];
            }
        }

        for (int i = N; i < N * 2; i++)
        {
            if (colIndex >= 0)
            {
                rubikData[cellsIndex[i]] = col[i - N];
            }
        }
    }

    private void RowRoll(int rowLength, int colLength, int rowIndex, int rollNum, int[] rubikData)
    {
        int[] row = new int[rowLength];
        int[] cellsIndex = new int[rowLength];
        int realRollNum = rollNum;
        while (realRollNum >= rowLength)
        {
            realRollNum -= rowLength;
        }

        for (int colIndex = 0; colIndex < rowLength; colIndex++)
        {
            int cellIndex = colIndex + (rowIndex * rowLength);
            row[colIndex] = rubikData[cellIndex];
            cellsIndex[colIndex] = cellIndex;
        }

        int[] rowTmp = new int[realRollNum];
        for (int i = 0; i < realRollNum; i++)
        {
            rowTmp[i] = row[(rowLength - 1) - i];
        }

        for (int i = rowLength - 1; i >= 0; i--)
        {
            if (i - realRollNum < 0)
            {
                row[i] = rowTmp[realRollNum - i - 1];
            }
            else
            {
                row[i] = row[i - realRollNum];
            }
        }
        for (int i = 0; i < rowLength; i++)
        {
            rubikData[cellsIndex[i]] = row[i];
        }
    }

    private void ColRoll(int rowLength, int colLength, int colIndex, int rollNum, int[] rubikData)
    {
        int[] col = new int[colLength];
        int[] cellsIndex = new int[colLength];
        int realRollNum = rollNum;
        while (realRollNum >= colLength)
        {
            realRollNum -= colLength;
        }

        for (int rowIndex = 0; rowIndex < colLength; rowIndex++)
        {
            int cellIndex = colIndex + (rowIndex * rowLength);
            col[rowIndex] = rubikData[cellIndex];
            cellsIndex[rowIndex] = cellIndex;
        }
        int[] colTmp = new int[realRollNum];
        for (int i = 0; i < realRollNum; i++)
        {
            colTmp[i] = col[(colLength - 1) - i];
        }

        for (int i = colLength - 1; i >= 0; i--)
        {
            if (i - realRollNum < 0)
            {
                col[i] = colTmp[realRollNum - i - 1];
            }
            else
            {
                col[i] = col[i - realRollNum];
            }
        }
        for (int i = 0; i < colLength; i++)
        {
            rubikData[cellsIndex[i]] = col[i];
        }
    }

    private void GridPrint(int rowLength, int[] rubikData)
    {
        StringBuilder outputStr = new StringBuilder();
        int curRowIndex;
        for (int i = 0; i < rubikData.Length; i++)
        {
            curRowIndex = i / rowLength;
            outputStr.Append(rubikData[i]);
            if ((i - (curRowIndex * rowLength)) + 1 != rowLength)
            {
                outputStr.Append(" ");
            }
            else
            {
                outputStr.Append("\n");
            }
        }
        Console.WriteLine("{0}", outputStr);
    }

}