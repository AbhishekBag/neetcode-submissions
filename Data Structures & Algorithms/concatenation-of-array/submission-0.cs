public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int n = nums.Length;
        int[] res = new int[2*n];

        for(int i = 0; i < n; i++) {
            res[i] = nums[i];
            res[i + n] = nums[i];
        }

        return res;
    }
}

/*
1,4,1,2
0,1,2,3,4,5,6,7
1,4,1,2,1,4,1,2
*/