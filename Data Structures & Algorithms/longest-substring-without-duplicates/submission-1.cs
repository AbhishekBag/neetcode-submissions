public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length <= 1) {
            return s.Length;
        }

        int mLen = 1;
        int i = 0, j = 0;
        int[] arr = new int[256];

        while(j < s.Length) {
            int cIn = s[j];
            arr[cIn]++;
            
            while(arr[cIn] > 1) {
                int cOut = s[i];
                arr[cOut]--;
                i++;
            }

            mLen = Math.Max(mLen, j - i + 1);
            j++;
        }

        return mLen;
    }
}
