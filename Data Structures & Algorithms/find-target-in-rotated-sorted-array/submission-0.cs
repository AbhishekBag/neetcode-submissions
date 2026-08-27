public class Solution {
    public int Search(int[] nums, int target) {
        int minIndex = GetMinIndex(nums);

        // Console.WriteLine($"minIndex = {minIndex}");

        int leftSearch = BinarySearch(nums, target, 0, minIndex - 1);
        // Console.WriteLine($"leftSearch = {leftSearch}");

        int rightSearch = BinarySearch(nums, target, minIndex, nums.Length - 1);
        // Console.WriteLine($"rightSearch = {rightSearch}");

        return leftSearch != -1 ? leftSearch : rightSearch;
        // return -1;
    }

    private int BinarySearch(int[] nums, int target, int l, int r) {
        int i = l, j = r;

        // Console.WriteLine($"l = {l}, i = {i}, r = {r}, j = {j}, target = {target}, mid = {i + (j - i)/2}");

        while(i <= j) {
            int mid = i + (j - i)/2;
            if(nums[mid] == target) {
                return mid;
            }

            if(nums[mid] < target) {
                i = mid + 1;
            } else {
                j = mid - 1;
            }
        }

        return -1;
    }

    private int GetMinIndex(int[] nums) {
        int l = 0, r = nums.Length - 1;
        while(l < r) {
            int mid = l + (r - l)/2;
            if(nums[mid] < nums[r]) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }

        return l;
    }
}
