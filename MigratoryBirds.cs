using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MigratoryBirds
{
    class Program
    {
        //My solution to the problem
        static int migratoryBirds(List<int> arr)
        {
            int count = 0;
            Dictionary<int,int> birdId = new Dictionary<int, int>();
            foreach(int value in arr)
            {
                if(birdId.ContainsKey(value) == false)
                {
                    birdId.Add(value,0);
                }
                else{
                    birdId[value]++;
                }
            }
            count = birdId.OrderBy(x =>x.Key).FirstOrDefault( bird => bird.Value == birdId.Values.Max()).Key;
            //Console.WriteLine(String.Join(" ",birdId.Select( val => Convert.ToString(val.Value)) ));
         return count;   
        }
        static void Main(string[] args)
        {
            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = migratoryBirds(arr);
            Console.WriteLine(result);
        }
    }
}
