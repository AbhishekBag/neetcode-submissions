public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if(newInterval.Length == 0) {
            return intervals;
        }

        List<int[]> res = new List<int[]>();
        int i = 0;
        bool added = false;
        int[] cur = new int[2];
        for(; i < intervals.Length; i++) {
            cur = intervals[i];
            if(IsOverlapping(cur, newInterval)) {
                newInterval[0] = Math.Min(cur[0], newInterval[0]);
                newInterval[1] = Math.Max(cur[1], newInterval[1]);
            } else if(newInterval[0] < cur[0]) {
                res.Add(newInterval);
                added = true;
                break;
            } else {
                res.Add(cur);
            }
        }

        if(!added) {
            res.Add(newInterval);
        }

        while(i < intervals.Length) {
            res.Add(intervals[i++]);
        }

        return res.ToArray();
    }

    private bool IsOverlapping(int[] a, int[] b) {
        return Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);
    }
}
