public class Solution {
    public int[] SortArray(int[] nums) {
        if(nums == null || nums.Length <= 1) {
            return nums;
        }

        Divide(nums, 0, nums.Length - 1);

        return nums;
    }

    private void Divide(int[] nums, int left, int right) {
        if(left == right) {
            return;
        }

        int mid = left + (right - left)/2;

        Divide(nums, left, mid);
        Divide(nums, mid + 1, right);
        Merge(nums, left, mid, right);
    }

    private void Merge(int[] nums, int left, int mid, int right) {
        int[] tmp = new int[right - left + 1];
        int i = left;
        int j = mid + 1;
        int k = 0;

        while(i <= mid && j <= right) {
            if(nums[i] < nums[j]) {
                tmp[k++] = nums[i++];
            } else {
                tmp[k++] = nums[j++];
            }
        }

        while(i <= mid) {
            tmp[k++] = nums[i++];
        }

        while(j <= right) {
            tmp[k++] = nums[j++];
        }

        for(i = 0; i < tmp.Length; i++) {
            nums[left + i] = tmp[i];
        }
    }
}