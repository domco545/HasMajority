using System;
using System.Collections.Generic;
using System.Linq;

namespace HasMajorityFaster
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
            Lookup<int, int> lookup = (Lookup<int, int>)arr.ToLookup(x => x, x=> x);

            foreach (var x in lookup)
            {
                var count = x.Count();
                Console.WriteLine($"Found {x.Key}, {count} times");
                if (count > arr.Length/2)
                {
                    Console.WriteLine($"Found majority {x.Key} presented {count} times");
                    return true;
                }
            }

            Console.WriteLine("no majority");
            return false;
        }
    }
}
