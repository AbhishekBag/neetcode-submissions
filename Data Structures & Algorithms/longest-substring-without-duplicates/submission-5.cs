public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int maxLength = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        int l = 0, r = 0;
         while(r < s.Length) {
            while(map.ContainsKey(s[r]) && l < r) {
                map.Remove(s[l++]);
            }
            
            map[s[r++]] = 1;

            maxLength = Math.Max(maxLength, map.Count());
         }

         return maxLength;
    }
}
