using System;
using System.Collections.Generic;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,,] array = new int[3, 3, 3];

            Console.WriteLine(array.GetLength(0));
            Console.WriteLine(array.Length);
            Console.WriteLine(array.Rank);
        }
    }
}
