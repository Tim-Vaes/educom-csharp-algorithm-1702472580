using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Organizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of elements in the list: ");
            int n = int.Parse(Console.ReadLine());
            List<int> unsortedList = GenerateRandomList(n);
            ShowList("Unsorted List", unsortedList);
            ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
            List<int> shiftSorted = shiftHighestSort.Sort(new List<int>(unsortedList));
            ShowList("ShiftHighestSort Sorted List", shiftSorted);
            ValidateSortedOrder(shiftSorted);
            RotateSort rotateSort = new RotateSort();
            List<int> rotateSorted = rotateSort.Sort(new List<int>(unsortedList));
            ShowList("RotateSort Sorted List", rotateSorted);
            ValidateSortedOrder(rotateSorted);
            CompareSortingAlgorithms(unsortedList, shiftSorted, rotateSorted);
        }

        public static List<int> GenerateRandomList(int n)
        {
            Random random = new Random();
            List<int> randomList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                randomList.Add(random.Next(-99, 100));
            }
            return randomList;
        }

        public static void ShowList(string label, List<int> theList)
        {
            int count = Math.Min(200, theList.Count);
            Console.WriteLine();
            Console.Write(label);
            Console.Write(':');
            for (int index = 0; index < count; index++)
            {
                if (index % 20 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(string.Format("{0,3}, ", theList[index]));
            }
            Console.WriteLine();
        }

        public static void ValidateSortedOrder(List<int> sortedList)
        {
            for (int i = 1; i < sortedList.Count; i++)
            {
                if (sortedList[i] < sortedList[i - 1])
                {
                    Console.WriteLine("Validation Failed: The list is not sorted correctly.");
                    return;
                }
            }
            Console.WriteLine("Validation Passed: The list is sorted correctly.");
        }

        public static void CompareSortingAlgorithms(List<int> unsortedList, List<int> shiftSorted, List<int> rotateSorted)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            ShiftHighestSort shiftHighestSort = new ShiftHighestSort();
            List<int> shiftSortedTiming = shiftHighestSort.Sort(new List<int>(unsortedList));
            stopwatch.Stop();
            Console.WriteLine($"ShiftHighestSort Timing: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();

            stopwatch.Start();
            RotateSort rotateSort = new RotateSort();
            List<int> rotateSortedTiming = rotateSort.Sort(new List<int>(unsortedList));
            stopwatch.Stop();
            Console.WriteLine($"RotateSort Timing: {stopwatch.ElapsedMilliseconds} ms");
            stopwatch.Reset();
        }
    }
}
