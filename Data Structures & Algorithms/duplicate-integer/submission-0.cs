public class Solution {
    public bool hasDuplicate(int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>();

        foreach(var item in nums) {
            if(map.ContainsKey(item)) {
                return true;
            }

            map[item] = 1;
        }

        return false;
    }
}
