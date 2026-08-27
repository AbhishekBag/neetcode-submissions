public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        Dictionary<int, HashSet<int>> inDeg = new Dictionary<int, HashSet<int>>();
        Dictionary<int, HashSet<int>> outDeg = new Dictionary<int, HashSet<int>>();
        Queue<int> q = new Queue<int>();
        HashSet<int> visited = new HashSet<int>();

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
            var current = q.Dequeue();
            visited.Add(current);

            if(outDeg.ContainsKey(current)){
                foreach(int next in outDeg[current]) {
                    if(inDeg.ContainsKey(next)) {
                        // inDeg[next].Remove(current);
                        if(inDeg[next].Count == 1) {
                            inDeg.Remove(next);
                            q.Enqueue(next);
                        } else {
                            inDeg[next].Remove(current);
                        }
                    }
                }
            }            
        }

        return visited.Count == numCourses;
    }
}
