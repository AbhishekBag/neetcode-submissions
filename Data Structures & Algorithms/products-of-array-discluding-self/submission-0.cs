public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        int[] leftArr = new int[n];
        int[] rightArr = new int[n];

        leftArr[0] = 1;
        rightArr[n - 1] = 1;

        for(int i = 1; i < n; i++) {
            leftArr[i] = leftArr[i - 1] * nums[i - 1];
        }

        for(int i = n - 2; i >= 0; i--) {
            rightArr[i] = rightArr[i + 1] * nums[i + 1];
        }

        for(int i = 0; i < n; i++) {
            res[i] = leftArr[i] * rightArr[i];
        }

        return res;
    }
}
