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
    public int MinMeetingRooms(List<Interval> intervals) {
        List<int> start = new List<int>();
        List<int> end = new List<int>();
        int maxCount = 0, count = 0;
        foreach(var interval in intervals) {
            start.Add(interval.start);
            end.Add(interval.end);
        }
/*
[(1,5),(5,10),(10,15),(15,20)]
start = [1,5,10,15]
end=[5,10,15,20]

i= 0,1
j= 0

count= 1
maxCount= 1
*/

        start.Sort();
        end.Sort();
        int i = 0, j = 0;
        while(i < start.Count && j < end.Count) {
            if(start[i] < end[j]) {
                count++;
                maxCount = Math.Max(maxCount, count);
                i++;
            } else {
                count--;
                j++;
            }
        }

        return maxCount;
    }
}
