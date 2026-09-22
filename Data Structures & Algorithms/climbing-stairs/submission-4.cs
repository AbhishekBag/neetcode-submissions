public class Solution {
    private int[] memo;
    public int ClimbStairs(int n) {     
        memo = Enumerable.Repeat(-1, n + 1).ToArray();
        return Climb(n);
    }

    private int Climb(int n) {
        if(n <= 2) {
            return n;
        }

        if(memo[n] != -1) {
            return memo[n];
        }

        memo[n] = Climb(n - 1) + Climb(n - 2);

        return memo[n];
    }
}
