public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        List<int[]> res = new List<int[]>();
        bool inserted = false;
        foreach(var interval in intervals) {
            if(!inserted) {
                if(IsOverlapping(interval, newInterval)) {
                    newInterval[0] = Math.Min(interval[0], newInterval[0]);
                    newInterval[1] = Math.Max(interval[1], newInterval[1]);
                } else if(interval[1] < newInterval[0]) {
                    res.Add(interval);
                } else {
                    res.Add(newInterval);
                    res.Add(interval);
                    inserted = true;
                }
            } else {
                res.Add(interval);
            }
        }

        if(!inserted) {
            res.Add(newInterval);
        }

        return res.ToArray();
    }

    private bool IsOverlapping(int[] a, int[] b) {
        return Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);
    }
}
