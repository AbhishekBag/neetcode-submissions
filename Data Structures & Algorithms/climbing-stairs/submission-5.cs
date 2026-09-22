public class Solution {
    public int ClimbStairs(int n) {     
        int prev = 0, curr = 1;
        int next = 0;

        for(int i = 1; i <=n; i++) {
            next = prev + curr;
            prev = curr;
            curr = next;
        }

        return next;
    }
}
