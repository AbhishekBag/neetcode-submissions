public class Solution {
    private int[] memo;
    public int MinCostClimbingStairs(int[] cost) {
        memo = Enumerable.Repeat(-1, cost.Length + 1).ToArray();
        return GetCost(cost, cost.Length);
    }

    private int GetCost(int[] cost, int n) {
        if(n <= 1) {
            return 0;
        }

        if(memo[n] != -1) {
            return memo[n];
        }

        memo[n] = Math.Min(cost[n - 1] + GetCost(cost, n - 1), cost[n - 2] + GetCost(cost, n - 2));

        return memo[n];
    }
}
