using System;
using System.Collections.Generic;

namespace Organizer
{
    public class ShiftHighestSort
    {
        private List<int> array = new List<int>();

        public List<int> Sort(List<int> input)
        {
            array = new List<int>(input);
            SortFunction(0, array.Count - 1);
            return array;
        }

        private void SortFunction(int low, int high)
        {
            for (int i = 0; i < high; i++)
            {
                for (int j = 0; j < high - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
