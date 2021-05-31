using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace StringConstruction
{

    class Result
    {
        public static int StringConstruction(string s)
        {
            int cost = 0;
            List<char> p = new List<char>();
            int length = s.Length;
            for(int i = 0; i < length; i++)
            {
                if(string.Join("",p) == s.Substring(i,length-i))
                {
                    p.AddRange(s.Substring(i,length-i));
                    i+= length-i;
                }
                else{
                    if(p.Contains(s[i]) == false)
                    {
                        cost++;
                    }
                    p.Add(s[i]);
                    
                }
            }
            return cost;
        }
    }
    class Solution
    {
        
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine().Trim());
            for(var nItr = 0; nItr < n; nItr++)
            {
                var s = Console.ReadLine();
                int result = Result.StringConstruction(s);
                Console.WriteLine(result);
            }
            
        }
    }
}
