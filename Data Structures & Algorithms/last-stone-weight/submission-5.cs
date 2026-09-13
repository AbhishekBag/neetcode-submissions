public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> q = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        foreach(int stone in stones) {
            q.Enqueue(stone, stone);
        }

        while(q.Count > 1) {
            int h1 = q.Dequeue();
            int h2 = q.Dequeue();

            int res = h1 - h2;

            q.Enqueue(res, res);
        }

        return q.Peek();
    }
}
