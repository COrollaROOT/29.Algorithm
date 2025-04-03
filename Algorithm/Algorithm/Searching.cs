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

        // <너비 우선 탐색 (Breadth-First Search)>
        // 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
        // 다음 깊이의 분기들을 탐색
        // 큐를 통해 탐색

        public static void BFS(bool[,] graph, int staar, out bool[] visited, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(staar);
            visited[staar] = true;

            while (queue.Count > 0)
            {
                // 큐에서 다음으로 탐색할 정점을 확인한다
                int next = queue.Dequeue();
                // 다음으로 탐색할 정점을 기준으로 탐색할 수 있는 정점들을 큐에 담는다
                for (int vertex = 0; vertex < size; vertex++) // 정점들을 반복하면서
                {
                    if (graph[next, vertex] == true && // 연결이 되어 있는 정점 // 방문한 적 없는 정점
                        visited[vertex] == false) // 탐색할 수 있는 점점인 경우 // 연결되어 있으면서 && 이미 찾은 정점이 아닐때
                    {
                        queue.Enqueue(vertex); // 큐에 탐색할 수 있는 정점을 추가한다
                        visited[vertex] = true; // 탐색할 수 있는 정점을 방문 표시
                        parents[vertex] = next; // 탐색할 수 있는 정점을 이전 정점을 표시한다
                    }
                }
            }
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
