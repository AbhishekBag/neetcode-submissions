public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length <= 1) {
            return s.Length;
        }

        int i = 0, j = 0, maxLen = 1;
        int[] arr = new int[256];
        while(j < s.Length) {
            int cIn = s[j];
            arr[cIn]++;
            while(arr[cIn] > 1) {
                int cOut = s[i++];
                arr[cOut]--;
            }

            maxLen = Math.Max(maxLen, j - i + 1);
            j++;
        }

        return maxLen;
    }
}
