using System.Collections.Generic;
using System;
public class AnagramFinder
{

    public void Start()
    {
        char[] a = { 'f', 'd', 'c', 'b', 'a' };
        QuickSort(a, 0, a.Length - 1);

        int n = Convert.ToInt32(Console.ReadLine());
        var lines = new List<string>();
        for(int i = 0; i < n*2 ; i++){
            string line = Console.ReadLine();
            
            lines.Add(line);
        } 

        for(int i = 0; i< lines.Count-1; i+=2){
            if(IsAnagram(lines[i], lines[i+1])){
                Console.WriteLine("YES");
            }else{
                Console.WriteLine("NO");
            }
        }
        
    }

    public static List<int> stringAnagram(List<string> dictionary, List<string> query)
    {
        List<int> result = new List<int>();
        foreach (string q in query)
        {
            int count = 0;
            foreach (string item in dictionary)
            {
                if (q.Length != item.Length)
                {
                    continue;
                }
                if (IsAnagram(q, item))
                {
                    count++;
                }
            }
            result.Add(count);
        }
        return result;
    }

    public static bool IsAnagram(string a, string b)
    {        
        char[] charsA = a.ToCharArray();
        char[] charsB = b.ToCharArray();
        
        if (charsA.Length != charsB.Length)
        {
            return false;
        }
        QuickSort(charsB, 0, charsB.Length - 1);
        for (int aIndex = 0; aIndex < charsA.Length; ++aIndex)
        {
            if (IsContain(charsB, charsA[aIndex]))
            {
                continue;
            }
            return false;
        }

        return true;
    }

    public static void QuickSort(char[] a, int start, int end)
    {
        if (start < end)
        {
            int pivPos;
            char[] result = Partition(a, start, end, out pivPos);
            //Console.WriteLine(String.Join(",", result));
            QuickSort(a, start, pivPos - 1);
            QuickSort(a, pivPos + 1, end);
        }
    }

    public static char[] Partition(char[] a, int start, int end, out int piv)
    {
        int i = start + 1;
        char pivValue = a[start];
        //Console.WriteLine(pivValue + "|" +start+ "|" + end);
        for (int j = start + 1; j <= end; j++)
        {
            if (a[j] < pivValue)
            {
                char iValue = a[i];
                a[i] = a[j];
                a[j] = iValue;
                i += 1;
            }
        }
        char startValue = a[start];
        a[start] = a[i - 1];
        a[i - 1] = startValue;
        piv = i - 1;
        return a;
    }

    public static bool IsContain(char[]a, char key)
    {
        int low = 0;
        int high = a.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (a[mid] < key)
            {
                low = mid + 1;
            }
            else if (a[mid] > key)
            {
                high = mid - 1;
            }
            else
            {
                return true;
            }
        }
        return false;                
    }
}