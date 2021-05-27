using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System .Globalization;
namespace ReducedString
{
    class Solution
    {
        static string superReducedString(string s)
        {
            char[] sort = s.ToCharArray();
            int index = 0;
            while (sort.Length > 1 && index != sort.Length && index + 1 < sort.Length  )
            {
                if (sort[index].Equals(sort[index + 1]))
                {
                    int duplicate = index;
                    string reduce = "";
                    for(int i = 0; i < sort.Length; i++)
                    {
                        if( i != duplicate & i != duplicate + 1)
                        {
                            reduce += sort[i];
                        }
                    }
                    sort = reduce.ToCharArray();
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            
            if (sort.Length == 0)
            {
                return "Empty String";
            }
            return String.Join("",sort);
        }

        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            string result = superReducedString(s);

            Console.WriteLine(result);

        }
    }
}
