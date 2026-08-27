public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        // List<int> res = new List<int>();
        int l = 0, r = numbers.Length - 1;

        while(l < r) {
            int sum = numbers[l] + numbers[r];
            if(sum == target) {
                return new int[] { l + 1, r + 1};
            } else if(sum < target) {
                l++;
            } else {
                r--;
            }
        }

        return new int[0];


        // for(int i = 0; i < numbers.Length; i++) {
        //     int t = target - numbers[i];
        //     int start = i + 1;
        //     int end = numbers.Length;

        //     while(start < end) {
        //         int mid = start + (end - start)/2;
        //         if(t == numbers[mid]) {
        //             res.Add(i + 1);
        //             res.Add(mid + 1);

        //             return res.ToArray();
        //         } else if(numbers[mid] > t) {
        //             end = mid;
        //         } else {
        //             start = mid + 1;
        //         }
        //     }
        // }
        
        // return res.ToArray();
    }
}
