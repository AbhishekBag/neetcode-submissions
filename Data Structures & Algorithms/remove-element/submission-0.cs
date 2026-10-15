public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int k = 0, i = 0;

        while(k < nums.Length) {
            i = k;
            if(nums[k] == val) {
                i = GetNext(nums, val, i);

                if(i == nums.Length) {
                    break;
                }

                int t = nums[i];
                nums[i] = nums[k];
                nums[k] = t;
            }

            k++;
        }

        // foreach(int n in nums) {
        //     Console.Write($"{n}, ");
        // }

        return k;
    }

    private int GetNext(int[] nums, int val, int i) {
        while(i < nums.Length) {
            if(nums[i] != val) {
                return i;
            }

            i++;
        }

        return nums.Length;
    }
}