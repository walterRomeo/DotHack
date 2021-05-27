using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace SubarrayDivision
{
    class Program
    {
        static int birthday(List<int> s, int d, int m){
            int valid = 0;
            if(m > s.Count)
            {
                return 0;
            }
            for(int chunk = 0; chunk < s.Count; chunk++)
            {
                int sum = 0;
                int n = 0;
                if(chunk + m > s.Count)
                {
                    return valid;
                }
                while(n< m)
                {
                    sum+=s[chunk+n];
                    n++;

                }
                if(sum ==d)
                {
                  ++valid;   
                }
            }
            return valid;
        }


        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string[] dm = Console.ReadLine().TrimEnd().Split(' ');

            int d = Convert.ToInt32(dm[0]);

            int m = Convert.ToInt32(dm[1]);

            int result = birthday(s,d, m);

            Console.WriteLine(result);
        }
    }
}
