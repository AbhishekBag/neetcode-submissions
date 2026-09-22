public class Solution {
    private int[] memo;
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        memo = Enumerable.Repeat(-1, n + 1).ToArray();
        memo[n] = Math.Min(GetCost(cost, 0), GetCost(cost, 1));

        return memo[n];
    }

    private int GetCost(int[] cost, int i) {
        if(i >= cost.Length) {
            return 0;
        }

        if(memo[i] != -1) {
            return memo[i];
        }

        memo[i] = cost[i] + Math.Min(GetCost(cost, i + 1), GetCost(cost, i + 2));

        return memo[i];
    }
}
