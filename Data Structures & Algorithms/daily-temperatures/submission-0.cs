public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        Stack<(int, int)> stk = new Stack<(int val, int index)>();
        int n = temperatures.Length;
        int[] res = new int[n];

        for(int i = 0; i < n; i++) {
            int val = temperatures[i];
            if(stk.Count == 0) {
                stk.Push((val, i));
            } else {
                while(stk.Count > 0 && stk.Peek().Item1 < val) {
                    var poped = stk.Pop();
                    res[poped.Item2] = i - poped.Item2;
                }

                stk.Push((val, i));
            }
        }

        while(stk.Count > 0) {
            res[stk.Pop().Item2] = 0;
        }

        return res;
    }
}
