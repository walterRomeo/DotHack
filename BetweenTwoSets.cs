using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace BetweenTwoSets
{
    class Result
    {
        public static int getTotalX(List<int> a, List<int> b)
        {
            int consider = 0;
            int multiple = a.Min();
            List<int> commonInt = new List<int>();
            List<int> betweenSets = new List<int>();
            consider = multiple;

            while (consider <= b.Max())
            {
                bool areAllFactors = true;
                foreach (var value in a)
                {
                    if (consider % value != 0)
                    {
                        areAllFactors = false;
                        
                    }             
                }
                if(areAllFactors == true)
                {
                    commonInt.Add(consider);
                }
                consider += multiple;
            }

             foreach (var value in commonInt)
            {
                bool areAllFactors = true;
                foreach(var element in b)
                {
                    if( element  % value  != 0 )
                    {
                        areAllFactors = false;
                    }
                }
                if(areAllFactors)
                {
                    betweenSets.Add(value);
                }
            }

            return betweenSets.Count();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@"C:\Users\Dark\Plural\HackerRank\betweenTwoSets\tempText", true);
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int m = Convert.ToInt32(firstMultipleInput[1]);
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();
            int total = Result.getTotalX(arr, brr);
            Console.WriteLine(total);
            // textWriter.WriteLine(total);
            // textWriter.Flush();
            // textWriter.Close();

        }
    }
}
