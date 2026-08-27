public class Solution {
    public int FindMin(int[] nums) {
        int left = 0, right = nums.Length - 1, mid = 0;

        while(left <= right) {
            mid = left + (right - left)/2;

            if(nums[mid] < nums[right]) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }

        return nums[left - 1];
    }
}
