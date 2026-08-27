public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> res = new List<List<int>>();

        Array.Sort(nums);
        for(int i = 0; i < nums.Length - 2; i++) {
            if(i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }

            int left = i + 1;
            int right = nums.Length - 1;

            while(left < right) {
                int sum = nums[i] + nums[left] + nums[right];

                if(sum == 0) {
                    res.Add(new List<int>() { nums[i], nums[left], nums[right] });

                    while(left < right && nums[left] == nums[++left]);
                    while(left < right && nums[right] == nums[--right]);
                } else if(sum < 0) {
                    left++;
                } else {
                    right--;
                }
            }
        }

        return res;

        /*
        for(int i = 0; i < nums.Length; i++) {
            var tmp = GetTwoSum(nums, i);
            // if(tmp.Count > 0) {
            //     res.AddRange(tmp);
            // }

            foreach(var item in tmp) {
                res.Add(item);
            }
        }
        */
    }

    private HashSet<List<int>> GetTwoSum(int[] nums, int index) {
        HashSet<List<int>> res = new HashSet<List<int>>();
        Dictionary<int, int> map = new Dictionary<int, int>();
        int target = -nums[index];

        for(int i = index + 1; i < nums.Length; i++) {
            int complement = target - nums[i];

            if(map.ContainsKey(complement)) {
                var lst = new List<int>() { nums[index], nums[i], complement };
                lst.Sort();
                res.Add(lst);
            }

            map[nums[i]] = i;

            /*
            if(!map.ContainsKey(complement)) {
                map[nums[i]] = i;
            } else {
                res.Add(new List<int>() { index, i, map[complement] });
            }
            */
        }

        return res;
    }
}

// Console.WriteLine($"index: {index}, target: {target}, i: {i}, nums[i]: {nums[i]}, complement: {complement}, map[{complement}]: {map[complement]}");
// Console.WriteLine($"Found triplet: {index}, {i}, {map[complement]}");
