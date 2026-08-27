public class Solution {
    public int CarFleet(int target, int[] position, int[] speed) {
        List<(int, int)> pairs = new List<(int position, int speed)>();

        for(int i = 0; i < position.Length; i++) {
            pairs.Add((position[i], speed[i]));
        }

        pairs.Sort((a, b) => b.Item1.CompareTo(a.Item1));

        Stack<double> stk = new Stack<double>();
        foreach(var pair in pairs) {
            stk.Push((double)(target - pair.Item1)/pair.Item2);
            if(stk.Count >= 2 && stk.Peek() <= stk.ElementAt(1)) {
                stk.Pop();
            }
        }

        return stk.Count();
    }
}
