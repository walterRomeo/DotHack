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

class Solution {

    // Complete the caesarCipher function below.
    static string caesarCipher(string s, int k) {
        const string alpha = "abcdefghijklmnopqrstuvwxyz";
        k %= 26;
        string cypher = string.Concat(alpha.Substring(k), alpha.Substring(0,k));


        List<char> codedMessage = new List<char>();
        foreach (var c in s)
        {
            int i;
            if (char.IsLetter(c))
            {
                if (Char.IsUpper(c))
                {
                    char code;
                    code = Char.ToLower(c);
                    i = alpha.IndexOf(code);
                     codedMessage.Add(Char.ToUpper(cypher[i]));
                }
                else
                {
                    i = alpha.IndexOf(c);
                    codedMessage.Add(cypher[i]);
                }
            }
            else
            {
                codedMessage.Add(c);
            }
        }
        return string.Join("",codedMessage.ToArray());
        
    }

    

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine());

        string result = caesarCipher(s, k);

        Console.WriteLine(result);

        
    }
}
