public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        int res = 0;
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
        int prevEnd = intervals[0][1];
        for(int i = 1; i < intervals.Length; i++) {
            int curStart = intervals[i][0];
            int curEnd = intervals[i][1];
            if(prevEnd <= curStart) {
                prevEnd = curEnd;
            } else {
                prevEnd = Math.Min(prevEnd, curEnd);
                res++;
            }
        }

        return res;
    }
}
