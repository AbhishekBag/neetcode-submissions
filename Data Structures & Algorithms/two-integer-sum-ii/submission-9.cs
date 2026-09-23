public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int n = numbers.Length;
        int l = 0, r = n - 1;
        int[] res = new int[2];

        while(l < r) {
            int sum = numbers[l] + numbers[r];
            if(sum == target) {
                res[0] = l + 1;
                res[1] = r + 1;
                
                break;
            }

            if(sum > target) {
                r--;
            } else {
                l++;
            }
        }

        return res;
    }
}
