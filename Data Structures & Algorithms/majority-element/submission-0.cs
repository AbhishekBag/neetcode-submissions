public class Solution {
    public int MajorityElement(int[] nums) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int item = 0, max = 0;
        foreach(int n in nums) {
            if(!map.ContainsKey(n)) {
                map[n] = 0;
            }

            map[n]++;

            if(map[n] > max) {
                max = map[n];
                item = n;
            }
        }

        return item;
    }
}