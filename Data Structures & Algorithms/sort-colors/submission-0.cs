public class Solution {
    public void SortColors(int[] nums) {
        int[] count = new int[3];

        foreach(int num in nums) {
            count[num]++;
        }

        int i = 0;
        for(int color = 0; color < 3; color++) {
            while(count[color]-- > 0) {
                nums[i++] = color;
            }
        }
    }
}