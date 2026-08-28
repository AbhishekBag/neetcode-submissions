public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        List<int> res = new List<int>();
        Dictionary<int, HashSet<int>> inDeg = new Dictionary<int, HashSet<int>>();
        Dictionary<int, HashSet<int>> outDeg = new Dictionary<int, HashSet<int>>();
        Queue<int> q = new Queue<int>();

        foreach(var item in prerequisites) {
            int course = item[0];
            int dependentOn = item[1];

            if(!inDeg.ContainsKey(course)) {
                inDeg[course] = new HashSet<int>();
            }

            inDeg[course].Add(dependentOn);

            if(!outDeg.ContainsKey(dependentOn)) {
                outDeg[dependentOn] = new HashSet<int>();
            }

            outDeg[dependentOn].Add(course);
        }

        for(int i = 0; i < numCourses; i++) {
            if(!inDeg.ContainsKey(i) || inDeg[i].Count == 0) {
                q.Enqueue(i);
            }
        }

        while(q.Count > 0) {
            int cur = q.Dequeue();
            res.Add(cur);

            if(outDeg.ContainsKey(cur)) {
                foreach(int next in outDeg[cur]) {
                    if(inDeg.ContainsKey(next)) {
                        inDeg[next].Remove(cur);
                        if(inDeg[next].Count == 0) {
                            inDeg.Remove(next);
                            q.Enqueue(next);
                        }
                    }
                }
            }
        }

        if(numCourses == res.Count) {
            return res.ToArray();
        }

        return new int[]{};
    }
}
