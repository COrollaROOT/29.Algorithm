using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Searching
    {
        // <순차 탐색>
        // 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
        // 시간복잡도 - O(n)
        public static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        
        static void Main(string[] args)
        {
            int[] array = { 0, 2, 4, 6, 8, 9, 7, 5, 3, 1 };
            int findIndex = LinearSearch(array, -1);
            Console.WriteLine("탐색 결과 : {0}", findIndex);

            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int binIndex = BinarySearch(ints, 3);
            Console.WriteLine("탐색 결과 : {0}", binIndex);
        }
    }
}
