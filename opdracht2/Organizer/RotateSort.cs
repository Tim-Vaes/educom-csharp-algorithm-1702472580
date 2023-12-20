using System;
using System.Collections.Generic;

namespace Organizer
{
    public class RotateSort
    {
        private List<int> array = new List<int>();

        public List<int> Sort(List<int> input)
        {
            if (input.Count <= 1)
            {
                return input;
            }
            array = new List<int>(input);
            SortFunction(0, array.Count - 1);
            return array;
        }

        private void SortFunction(int low, int high)
        {
            if (low < high)
            {
                int splitPoint = Partitioning(low, high);
                SortFunction(low, splitPoint - 1);
                SortFunction(splitPoint + 1, high);
            }
        }

        private int Partitioning(int low, int high)
        {
            int pivot = array[low];
            int left = low + 1;
            int right = high;
            while (true)
            {
                while (left <= right && array[left] <= pivot)
                {
                    left++;
                }
                while (right >= left && array[right] >= pivot)
                {
                    right--;
                }
                if (left > right)
                {
                    break;
                }
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
            }
            int tempPivot = array[low];
            array[low] = array[right];
            array[right] = tempPivot;
            return right;
        }
    }
}

