using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StrongPassword
{
    class Solution
    {
        private const string numbers = "0123456789";
        private const string lower_case = "abcdefghijklmnopqrstuvwxyz";
        private const string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string special_characters = "!@#$%^&*()-+";
        private const int minStrongLength = 6;
        private const int criteria = 4;
        struct strongVariable
        {
            public bool num;
            public bool l_case;
            public bool up_case;
            public bool special_c;
            public strongVariable(bool num, bool l_case, bool up_case, bool special_c)
            {
                this.num = num;
                this.l_case = l_case;
                this.up_case = up_case;
                this.special_c = special_c;
            }
            public int Missing(int n)
            {
                int count = 0;
                if (num == false)
                    count++;
                if (l_case == false)
                    count++;
                if (up_case == false)
                    count++;
                if (special_c == false)
                    count++;
                if ((n + count) >= minStrongLength)
                {
                    return count;
                }
                if((minStrongLength - n) > count)
                {
                    return minStrongLength - n;
                }                
                count += minStrongLength - n;
                return count;
            }
        }
        // Complete the minimumNumber function below.

        static bool CheckString(string required, string password)
        {
            foreach (var check in required)
            {
                if (password.Contains(check))
                {
                    return true;
                }
            }
            return false;
        }
        static int minimumNumber(int n, string password)
        {
            // Return the minimum number of characters to make the password strong
            strongVariable checklist = new strongVariable(false, false, false, false);

            checklist.num = CheckString(numbers, password);
            checklist.l_case = CheckString(lower_case, password);
            checklist.up_case = CheckString(upper_case, password);
            checklist.special_c = CheckString(special_characters, password);
            return checklist.Missing(n);

        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            string password = Console.ReadLine();

            int answer = minimumNumber(n, password);

            Console.WriteLine(answer);

        }
    }

}
