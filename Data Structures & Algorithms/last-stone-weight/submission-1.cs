public class Solution {
    public int LastStoneWeight(int[] stones) {
        PriorityQueue<int, int> collection = new PriorityQueue<int, int>(Comparer<int>.Create(
            (a, b) => b - a
        ));

        // new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));

        foreach(int stone in stones) {
            collection.Enqueue(stone, stone);
        }

        while(collection.Count > 1) {
            int t1 = collection.Dequeue();
            int t2 = collection.Dequeue();
            if(t1 != t2) {
                int newWeight = t1 - t2;
                collection.Enqueue(newWeight, newWeight);
            }            
        }

        return collection.Count > 0 ? collection.Peek() : 0;
    }
}
