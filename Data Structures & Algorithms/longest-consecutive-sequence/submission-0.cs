public class Solution {
    public int LongestConsecutive(int[] nums) {
        int longest = 0;
        HashSet<int> set = nums.Select(x => x).ToHashSet<int>();

        foreach(int num in nums) {
            if(!set.Contains(num - 1)) {
                int length = 0;
                while(set.Contains(num + length)) {
                    length += 1;
                }

                longest = Math.Max(longest, length);
            }
        }

        return longest;
    }
}
