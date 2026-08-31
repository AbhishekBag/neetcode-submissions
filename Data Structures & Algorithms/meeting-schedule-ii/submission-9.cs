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
        if(intervals.Count <= 1) {
            return intervals.Count;
        }

        int res = 0;
        List<Node> collection = new List<Node>();
        foreach(var interval in intervals) {
            collection.Add(new Node(interval.start, true));
            collection.Add(new Node(interval.end, false));
        }

        collection.Sort((a, b) => {
            int cmp = a.val.CompareTo(b.val);
            if(cmp != 0) {
                return cmp;
            }

            if(a.isStart == b.isStart) {
                return 0;
            }

            return a.isStart ? 1 : -1;
        });

        int count = 0;
        for(int i = 0; i < collection.Count; i++) {
            var cur = collection[i];
            if(cur.isStart) {
                count += 1;
            } else {
                count -= 1;
            }

            res = Math.Max(res, count);
        }

        return res;
    }
}

public class Node {
    public int val;
    public bool isStart;

    public Node(int v, bool s) {
        val = v;
        isStart = s;
    }
}
