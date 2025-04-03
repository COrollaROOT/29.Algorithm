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

        // <이진 탐색>
        // 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
        // 단, 이진 탐색은 정렬이 되어 있는 자료에만 적용 가능
        // 시간복잡도 - O(logn)

        public static int BinarySearch(int[] array, int target)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high) // 찾을때까지 || 없을때까지
            {
                // 중간위치를 mid로 잡는다
                int mid = (low + high) / 2;

                if (array[mid] > target) // 중간값이 찾고자 하는 값보다 더 큰 경우
                {
                    // 오른쪽 값들은 무시 -> high를 mid 한칸 앞으로 옮긴다
                    high = mid - 1;
                }

                else if (array[mid] < target) // 중간값이 찾고자 하는 값보다 더 작은 경우
                {
                    // 왼쪽 값들은 무시 -> low를 mid 한칸 뒤로 옮긴다
                    low = mid + 1;
                }

                else // if (중간 값이 찾고자 하는 값이랑 같은 경우)
                {
                    // 값을 찾았다
                    return mid;
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
