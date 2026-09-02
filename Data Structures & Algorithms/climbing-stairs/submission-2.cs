public class Solution {
    private int[] memo;
    public int ClimbStairs(int n) {
        if(n <= 2) {
            return n;
        }

        memo = Enumerable.Repeat(-1, n + 1).ToArray();
        Climb(n);

        return memo[n];
    }

    private int Climb(int n) {
        if(n <= 2) {
            return n;
        }
        
        if(memo[n] != -1) {
            return memo[n];
        }

        int num = Climb(n - 1) + Climb(n - 2);
        memo[n] = num;

        return memo[n];
    }
}
