using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Sorting
    {
            // <선택정렬>
            // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
            // 시간복잡도 -  O(n²)
            // 공간복잡도 -  O(1)
            public static void SelectionSort(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    int minIndex = i;
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }

                    Swap(array, i, minIndex);
            }
        }


        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(array, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        // <버블정렬> // 두개 비교해서 터 크면 교체한다.
        // 서로 인접한 데이터를 비교하여 정렬
        // 시간복잡도 -  O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  O

        public static void BubbleSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        // <병합정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 데이터 갯수만큼의 추가적인 메모리가 필요
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(n)
        // 안정정렬   -  O

        public static void MergeSort(int[] array) => MergeSort(array, 0, array.Length - 1);
        public static void MergeSort(int[] array, int start, int end)
        {
            if (start == end)
                return;
         
            int mid = (start + end) / 2;
            MergeSort(array, start, mid);
            MergeSort(array, mid + 1, end);
            Merge(array, start, mid, end);
        }

        public static void Merge(int[] array, int start, int mid, int end)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = start;
            int rightIndex = mid + 1;

            while (leftIndex <= mid && rightIndex <= end) // 한쪽이 모두 소진 될때 까지
            {
                if (array[leftIndex] < array[rightIndex]) // 왼쪽이 작으면
                {
                    // 왼쪽값 정렬된 리스트에 집어넣기
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    // 오른쪽 값 정렬된 리스트에 집어넣기
                    sortedList.Add((int)array[rightIndex]);
                    rightIndex++;
                }
            }

            if (leftIndex <= mid) // 왼쪽이 남아 있으면
            {
                // 왼쪽 나머지를 모두 정렬된 리스트에 추가
                while (leftIndex <= mid)
                {
                    sortedList.Add(array[leftIndex]);
                    leftIndex++;
                }
            }
            else // if (rightIndex <= end)
            {
                // 오른쪽 나머지를 모두 정렬된 리스트에 추가
                while (rightIndex <= end)
                {
                    sortedList.Add(array[rightIndex]);
                    rightIndex++;

                }
            }

            for (int i = 0; i < sortedList.Count; i++)
            {
                array[start + i] = sortedList[i];
            }
        }

        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        // 최악의 경우(피벗이 최소값 또는 최대값)인 경우 시간복잡도가 O(n²)
        // 시간복잡도 -  평균 : O(nlogn)   최악 : O(n²)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X

        public static void QuickSort(int[] array) => QuickSort(array, 0, array.Length - 1);

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = start;
            int left = pivot + 1;
            int right = end;

            while (left <= right) // left와 right가 교차할때까지 반복
            {
                // left는 pivot 보다 더 큰값을 볼때까지 오른쪽으로 이동
                while (array[pivot] >= array[right] && left < right)
                {
                    right++;
                }
                // right는 pivot 보다 더 큰값을 볼때까지 왼쪽으로 이동
                while (array[pivot] < array[right] && left <= right)
                {
                    left--;
                }

                if (left < right) // left와 right가 교차 안했다면
                {
                    // left와 right 값을 교체
                    Swap(array, left, right);
                }
                else
                {
                    // pivot과 right를 교체
                    Swap(array, pivot, right);
                    break;
                }
            }

            QuickSort(array, start, right - 1);
            QuickSort(array, right + 1, end);

        }


        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소가 가장 마지막 요소와 교체된 후 제거되는 방법을 이용
        // 배열에서 연속적인 데이터를 사용하지 않기 때문에 캐시 메모리를 효율적으로 사용할 수 없어 상대적으로 느림
        // 시간복잡도 -  O(nlogn)
        // 공간복잡도 -  O(1)
        // 안정정렬   -  X



        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 20;

            int[] selectArray = new int[count];
            int[] insertArray = new int[count];
            int[] bubbleArray = new int[count];
            int[] mergeArray = new int[count];
            int[] quickArray = new int[count];

            Console.WriteLine("랜덤 데이터: ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next(0, 100);
                Console.Write($"{rand,3}");

                selectArray[i] = rand;
                insertArray[i] = rand;
                bubbleArray[i] = rand;
                mergeArray[i] = rand;
                quickArray[i] = rand;
            }
            Console.WriteLine();
            Console.WriteLine();

            SelectionSort(selectArray);
            Console.WriteLine("선택 정렬 결과 : ");
            foreach (int value in selectArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            InsertionSort(insertArray);
            Console.WriteLine("삽입 정렬 결과 : ");
            foreach (int value in insertArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            BubbleSort(bubbleArray);
            Console.WriteLine("버블 정렬 결과 : ");
            foreach (int value in bubbleArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            MergeSort(mergeArray);
            Console.WriteLine("병합 정렬 결과 : ");
            foreach (int value in mergeArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();

            QuickSort(quickArray);
            Console.WriteLine("퀵 정렬 결과 : ");
            foreach (int value in quickArray)
            {
                Console.Write($"{value,3}");
            }
            Console.WriteLine();
        }

        public static void Swap(int[] array, int left, int right)
{
    int temp = array[left];
    array[left] = array[right];
    array[right] = temp;
}
    }
}
