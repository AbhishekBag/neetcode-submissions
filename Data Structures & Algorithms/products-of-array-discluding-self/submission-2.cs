public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        res[0] = 1;

        Console.Write($"res[{0}]: {res[0]}, ");
        for(int i = 1; i < n; i++) {
            res[i] = res[i - 1] *nums[i - 1];

            // Console.Write($"res[{i}]: {res[i]}, ");
        }

        // Console.WriteLine();
        // Console.Write($"res[{n - 1}]: {res[n - 1]}, ");

        int suffix = 1;
        for(int i = n - 2; i >= 0; i--) {
            suffix *= nums[i + 1];
            res[i] = res[i] * suffix;

            // Console.Write($"res[{i}]: {res[i]}, ");
        }

        return res;
    }
}

/*
[1,2,4,6]
[1,1,2,8]
[48,24,6,1]
*/