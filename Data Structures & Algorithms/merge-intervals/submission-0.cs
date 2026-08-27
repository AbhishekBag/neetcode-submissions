public class Solution {
    public int[][] Merge(int[][] intervals) {
        if(intervals.Length <= 1) {
            return intervals;
        }

        Array.Sort(intervals, (a, b) => {
            return a[0].CompareTo(b[0]);
        });
/*
[[1,2],[3,4],[4,5],[6,7]]

i = 1,2,3,4
prev = [6,7]
cur = [,]

res = [1,2],[3,5],
*/

        List<int[]> res = new List<int[]>();
        var prev = intervals[0];
        int i = 1;
        while(i < intervals.Length) {
            var cur = intervals[i++];
            if(IsOverlaping(prev, cur)) {
                prev[0] = Math.Min(prev[0], cur[0]);
                prev[1] = Math.Max(prev[1], cur[1]);
            } else if(prev[1] < cur[0]) {
                res.Add(prev);
                prev = cur;
            }
        }

        res.Add(prev);
        return res.ToArray();
    }

    private bool IsOverlaping(int[] a, int[] b) {
        return Math.Max(a[0], b[0]) <= Math.Min(a[1], b[1]);
    }
}
