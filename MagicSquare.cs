using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MagicSquare
{
    class Program
    {


        static int formingMagicSquare(int[][] s)
        {
            // Valid sequence placement where [0][0] = 2 and [0][2] = 4 
            int [,] magicSquareBase = new int[,] { {2, 9, 4}, {7, 5, 3}, {6, 1, 8}};
            int calculateMCost = calcCost(s, magicSquareBase);
            int minCost = calculateMCost;
            // Valid sequence placement where [0][0] = 2 and [0][2] = 6
            magicSquareBase = new int[,] { {2, 7, 6}, {9, 5, 1} ,{4, 3, 8}};
            calculateMCost = calcCost(s, magicSquareBase);
            minCost = calculateMCost < minCost? calculateMCost: minCost;
            return minCost;
        }

        static int calcCost(int[][] s, int[,] magicSquareBase)
        {
            int minCost = int.MaxValue;
            int rotate = 0;
                           
            while (rotate < 360)
            {
                int cost = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (s[i][j] != magicSquareBase[i, j])
                        {  
                            cost += Math.Abs(magicSquareBase[i, j] - s[i][j]);
                        }
                    }
                }
              minCost = cost < minCost ? cost : minCost;
                magicSquareBase = rotateMatrix90(magicSquareBase);
                rotate += 90;
            }
            return minCost;
        }

        static int[,] rotateMatrix90(int[,] magicSquare)
        {  
            int [,] rotatedMagicSquareBase = new int[3,3];
            int row = 0;
            int collumn = 0;
            for(int j = 0; j <3; j++ )
            {
                collumn = 0;
                for( int i = 2 ; i >= 0; i--)
                {
                    rotatedMagicSquareBase[row, collumn] = magicSquare[i,j];
                    collumn++;
                }
                row++;
            }
             return rotatedMagicSquareBase;
        }


        static void Main(string[] args)
        {
            int [][] s = new int [3][];
            for (int i = 0; i< 3; i++)
            {
                s[i]= Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
            }
            int result =  formingMagicSquare(s);
            Console.WriteLine(result);
        }
    }
}
