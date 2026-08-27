public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        PriorityQueue<int, int> processingQ = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
        Queue<(int, int)> waitQ = new Queue<(int, int)>();
        int[] arr = new int[26];

        foreach(char task in tasks) {
            int i = task - 'A';
            arr[i] += 1;
        }

        for(int i = 0; i < 26; i++) {
            if(arr[i] > 0) {
                processingQ.Enqueue(i, arr[i]);
            }            
        }

        int time = 0;
        while(processingQ.Count > 0 || waitQ.Count > 0) {
            while(waitQ.Count() > 0 && waitQ.Peek().Item2 <= time) {
                var dq = waitQ.Dequeue();
                processingQ.Enqueue(dq.Item1, arr[dq.Item1]);
            }

            if(processingQ.Count > 0) {
                var cur = processingQ.Dequeue();
                arr[cur] -= 1;
                if(arr[cur] > 0) {
                    waitQ.Enqueue((cur, time + n + 1));
                }
            }            

            time += 1;
        }

        return time;
    }
}
