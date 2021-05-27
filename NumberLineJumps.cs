using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.Text;


namespace NumberLineJumps
{
    class Program
    {
        static string kangaroo(int x1, int v1, int x2, int v2){
            // If velocity of Kangaroo2 is greater or equal to Kangaroo1,
            // Kangaroo1 will never catch up;
            if(v2 >= v1)
            {
                return "NO";
            }
            // location of kangaroo: K
            // number of jumps j
            //velocity v
            //starting position x
            // K  = (j * v) + x
            // k1 = k2=>    (j*v1)+x1 = (j*v2) +x2
            // x1-x2 = (j*v1)-(j*v2)
            // (x1-x2) = j(v1-v2)
            // (x1 - x2) / (v1 - v2) = J
            // (x1-x2)%(v2-v1) == 0 when there is a whole jump
            if((x1-x2)%(v2-v1) == 0)
            {
                return "YES";
            }
            return "NO";
        }
        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            
            string[] x1V1X2V2 = Console.ReadLine().Split(' ');
            int x1 = Convert.ToInt32(x1V1X2V2[0]);
            int v1 = Convert.ToInt32(x1V1X2V2[1]);
            int x2 = Convert.ToInt32(x1V1X2V2[2]);
            int v2 = Convert.ToInt32(x1V1X2V2[3]);
            string result = kangaroo(x1,v1,x2,v2);
            Console.WriteLine(result);
            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
