public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<(int dest, int time)>> outDeg = new Dictionary<int, List<(int dest, int time)>>();
        HashSet<int> visited = new HashSet<int>();
        int minTime = 0;

        foreach(var time in times) {
            int source = time[0];
            int dest = time[1];
            int t = time[2];
            if(!outDeg.ContainsKey(source)) {
                outDeg[source] = new List<(int dest, int time)>();
            }

            outDeg[source].Add((dest, t));
        }

        int[] cost = Enumerable.Repeat(Int32.MaxValue, n + 1).ToArray();
        Queue<int> q = new Queue<int>();
        q.Enqueue(k);
        cost[k] = 0;
        visited.Add(k);

        while(q.Count > 0) {
            var dq = q.Dequeue();
            if(outDeg.ContainsKey(dq)) {
                foreach((int dest, int time) in outDeg[dq]) {
                    int newCost = cost[dq] + time;
                    if(newCost < cost[dest]) {
                        cost[dest] = newCost;
                        q.Enqueue(dest);
                    }                    
                }
            }
        }

        int min = 0;
        cost[0] = -1;
        foreach(int time in cost) {
            if(time == Int32.MaxValue) {
                return -1;
            }

            min = Math.Max(min, time);
        }

        // int maxTime = 0;
        // for(int i = 1; i <= n; i++) {
        //     if(cost[i] == Int32.MaxValue) {
        //         return -1;
        //     }

        //     maxTime = Math.Max(maxTime, cost[i]);
        // }

        return min;
    }
}
