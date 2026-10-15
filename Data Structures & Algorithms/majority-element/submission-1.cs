public class Solution {
    public int MajorityElement(int[] nums) {
        int res = 0, count = 0;

        foreach(int num in nums) {
            if(count == 0) {
                res = num;
            }

            if(num == res) {
                count++;
            } else {
                count--;
            }
        }

        return res;
    }
}