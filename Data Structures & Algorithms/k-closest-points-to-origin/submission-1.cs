public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        int[][] res = new int[k][];
        PriorityQueue<int[], double> collection = new PriorityQueue<int[], double>(
            Comparer<double>.Create(
                (a, b) => { return b.CompareTo(a); }
            )
        );

        foreach(var point in points) {
            var distance = GetDistance(new int[] { 0, 0 }, point);
            collection.Enqueue(point, distance);

            if(k > 0) {
                k--;
            } else {
                collection.Dequeue();
            }
        }

        int i = 0;
        while(collection.Count > 0) {
            res[i++] = collection.Dequeue();
        }

        return res;
    }

    private double GetDistance(int[] a, int[] b) {
        return Math.Sqrt((Math.Pow(a[0] - b[0], 2) + Math.Pow(a[1] - b[1], 2)));
    }
}
