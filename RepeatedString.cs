using System;

namespace RepeatedString
{
    class Program
    {
   // Complete the repeatedString function below.
    static long repeatedString(string s, long n) {
        long aCount = 0;
        if(n > s.Length)
        {
            foreach(var a in s)
            {
                if(a.Equals('a'))
                {
                    aCount++;
                }
            }
            aCount *= n/s.Length;
            var remainder = n%s.Length;
            var index = 0;
            while(index <= remainder -1)
                {
                if(s[index] == 'a')
                {
                    aCount++;
                }
                index++;
            }
        }
        else{
            int limit = 0;
            foreach(var a in s)
            {
                if(limit > n -1)
                {
                    break;
                }
                limit++;
                if(a == 'a')
                {
                    aCount++;
                }
            }
        }
        return aCount;

    }

    static void Main(string[] args) {
       
        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine());

        long result = repeatedString(s, n);

        Console.WriteLine(result);

    }
    }
}
