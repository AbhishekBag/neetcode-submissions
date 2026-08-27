/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals) {
        if(intervals.Count <= 1) {
            return true;
        }

        intervals.Sort((a, b) => {
            return a.start.CompareTo(b.start);
        });

        var prevEnd = intervals[0].end;
        int i = 1;
        while(i < intervals.Count) {
            if(prevEnd > intervals[i].start) {
                return false;
            }

            prevEnd = intervals[i++].end;
        }

        return true;
    }
}
