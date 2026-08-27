public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if(intervals.Length <= 1) {
            return 0;
        }

        Array.Sort(intervals, (a, b) => {
            return a[0].CompareTo(b[0]);
        });
/*
[[1,2],[2,4],[1,4],[5,6]]

i= 1,2
prevE = 4
curS = 1
curE = 4

count = 0,

*/

        int count = 0;
        int prevEnd = intervals[0][1];
        int i = 1;
        while(i < intervals.Length) {
            int curStart = intervals[i][0];
            int curEnd = intervals[i++][1];
            if(prevEnd <= curStart) {
                prevEnd = curEnd;
            } else {
                count++;
                prevEnd = Math.Min(prevEnd, curEnd);
            }
        }

        return count;
    }
}
