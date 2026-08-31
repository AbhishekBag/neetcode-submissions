public class Solution {
    public int[][] Merge(int[][] intervals) {
        List<int[]> res = new List<int[]>();
        Array.Sort(intervals, (a, b) => {
            return a[0].CompareTo(b[0]);
        });
        var prev = intervals[0];

        for(int i = 1; i < intervals.Length; i++) {
            var cur = intervals[i];
            if(IsOverlapping(prev, cur)) {
                prev[0] = Math.Min(prev[0], cur[0]);
                prev[1] = Math.Max(prev[1], cur[1]);
            } else {
                res.Add(prev);
                prev = cur;
            }
        }

        res.Add(prev);

        return res.ToArray();
    }

    private bool IsOverlapping(int[] a, int[] b) {
        return Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);
    }
}
