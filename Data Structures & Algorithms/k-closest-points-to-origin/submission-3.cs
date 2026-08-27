public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        int[][] res = new int[k][];
        PriorityQueue<int[], double> q = new PriorityQueue<int[], double>(Comparer<double>.Create((a, b) => b.CompareTo(a)));

        foreach(var point in points) {
            double distance = GetDistance(point);
            q.Enqueue(point, distance);

            if(k > 0) {
                k--;
            } else {
                q.Dequeue();
            }
        }

        int i = 0;
        while(q.Count > 0) {
            res[i++] = q.Dequeue();
        }

        return res;
    }

    private double GetDistance(int[] point) {
        return Math.Sqrt(
            Math.Pow(point[0], 2) + Math.Pow(point[1], 2)
        );
    }
}
