using System;

namespace HasMajority
{
    class Program
    {

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var program = new Program();
            int[] arr2 = program.FillArray();
            int[] arr = { 5, 4, 2, 4, 4};
            program.HasMajority(arr2);
            watch.Stop();
            Console.WriteLine($"Execute time was {watch.ElapsedMilliseconds} miliseconds that is {watch.ElapsedMilliseconds / 1000} seconds");
        }

        public int[] FillArray() 
        {
            var rand = new Random();
            int[] arr = new int[1000];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1,100);
            }
            return arr;
        }

        public bool HasMajority(int[] arr) 
        {
            var lenght = arr.Length;
            var currentNum = 0;
            var count = -1;
            var percentKeeper = 1;

            foreach (var value in arr)
            {
                currentNum = value;
                Console.WriteLine($"counting {currentNum}");

                count = countMember(currentNum, arr);
                Console.WriteLine($"done totoal apperances is {count}");

                Console.ForegroundColor = ConsoleColor.Red;
                var percent = (percentKeeper * 100) / lenght;
                Console.WriteLine($"finished {percent}%");

                Console.ForegroundColor = ConsoleColor.White;
                         
                if (count > lenght/2)
                {
                    Console.WriteLine($"majority number is {currentNum} and appeared {count} times");
                    return true;
                }

                percentKeeper++;
            }

            Console.WriteLine("no majority number");
            return false;
        }

        private int countMember(int num, int[] arr) 
        {
            var count = 0;
            foreach (var item in arr)
            {
                if (item == num)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
