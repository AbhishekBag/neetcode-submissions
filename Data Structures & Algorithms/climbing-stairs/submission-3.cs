public class Solution {
    public int ClimbStairs(int n) {     
        int prev = 0, cur = 1;

        for(int i = 1; i <= n; i++) {
            int tmp = cur + prev;
            prev = cur;
            cur = tmp;
        }

        return cur;
    }
}
