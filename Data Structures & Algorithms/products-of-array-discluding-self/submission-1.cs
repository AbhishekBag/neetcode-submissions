public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] leftArr = new int[n];
        int[] rightArr = new int[n];
        int[] res = new int[n];

        leftArr[0] = 1;
        rightArr[n - 1] = 1;
        for(int i = 1; i < n; i++) {
            leftArr[i] = leftArr[i - 1] * nums[i - 1];
        }

        for(int j = n - 2; j >= 0; j--) {
            rightArr[j] = rightArr[j + 1] * nums[j + 1];
        }

        for(int i = 0; i < n; i++) {
            res[i] = leftArr[i] * rightArr[i];
        }

        return res;
    }
}
