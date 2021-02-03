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
        string c = "20 20 10 5 25 35";
        string v = "120 2 50 100 1 5";
        Dictionary<int, int> input = new Dictionary<int, int>(){
            {120, 20},
            {2, 20},
            {50, 10},
            {100, 5},
            {1, 25},
            {5, 35}
        };
        int w = 57;
        // 120 100 50 5  2  1
        // 20  5   10 35 20 25
    }

    static string Output(int weight, Dictionary<int, int> data)
    {


    }

    static string sortValue(Dictionary<int, int> data, Dictionary<int, int> sortedDic)
    {
        var myKeys = new List<int>(data.Keys); ;
        //myKeys.
        myKeys.Sort((a, b) => a.Value.CompareTo(b.Value))
        
    }


}