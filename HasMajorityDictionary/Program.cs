using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace HasMajorityDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var program = new Program();
            int[] arr2 = program.FillArray();
            int[] arr = { 5, 4, 2, 4, 4 };
            program.HasMajority(arr2);
            watch.Stop();
            Console.WriteLine($"Execute time was {watch.ElapsedMilliseconds} miliseconds that is {watch.ElapsedMilliseconds / 1000} seconds");
        }

        public int[] FillArray()
        {
            var rand = new Random();
            int[] arr = new int[100000000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 100);
            }
            return arr;
        }

        public bool HasMajority(int[] arr) 
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();

            foreach (var value in arr)
            {
                if (counter.ContainsKey(value))
                {
                    counter[value]++;
                }
                else
                {
                    counter.Add(value, 1);
                }
            }

            foreach (var value in counter.Keys)
            {
                Console.WriteLine($"Found {value}, {counter[value]} times");

                if (counter[value] > arr.Length/2)
                {
                    Console.WriteLine($"Found majority {value} appeared {counter[value]}");
                    return true;
                }
            }
            Console.WriteLine("No majority found");
            return false;
        }
    }
}
