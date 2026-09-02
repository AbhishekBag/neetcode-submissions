public class Solution {
    private int[] memo;
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        memo = Enumerable.Repeat(-1, n + 1).ToArray();
        memo[n] = Math.Min(TakeSteps(cost, 0), TakeSteps(cost, 1));

        return memo[n];
    }

    private int TakeSteps(int[] cost, int i) {
        if(i >= cost.Length) {
            return 0;
        }

        if(memo[i] != -1) {
            return memo[i];
        }

        memo[i] = cost[i] + Math.Min(TakeSteps(cost, i + 1), TakeSteps(cost, i + 2));

        return memo[i];
    }
}
