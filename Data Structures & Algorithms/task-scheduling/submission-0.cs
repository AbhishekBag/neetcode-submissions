public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        int time = 0;
        PriorityQueue<int, int> collection = new PriorityQueue<int, int>(
            Comparer<int>.Create((a, b) => b - a)
        );

        int[] arr = new int[26];
        foreach(char c in tasks) {
            arr[c - 'A']++;
        }

        foreach(int item in arr) {
            if(item > 0)
                collection.Enqueue(item, item);
        }

        Queue<int[]> q = new Queue<int[]>();
        while(collection.Count > 0 || q.Count > 0) {
            if(q.Count > 0 && time >= q.Peek()[1]) {
                int[] tmp = q.Dequeue();
                collection.Enqueue(tmp[0], tmp[0]);
            }

            if(collection.Count > 0) {
                int cnt = collection.Dequeue() - 1;
                if(cnt > 0) {
                    q.Enqueue(new int[] { cnt, time + n + 1 });
                }
            }

            time++;
        }

        return time;
    }
}