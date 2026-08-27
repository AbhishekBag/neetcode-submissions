public class Solution {
    public string MinWindow(string s, string t) {
        Dictionary<char, int> required = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();
        int[] res = new int[2] { -1, -1 };

        foreach(char c in t) {
            if(!required.ContainsKey(c)) {
                required[c] = 0;
            }

            required[c]++;
        }

        int l = 0, r = 0;
        int formed = 0, requiredCount = required.Count;
        while(r < s.Length) {
            char cIn = s[r];
            if(!window.ContainsKey(cIn)) {
                window[cIn] = 0;
            }

            window[cIn]++;

            if(required.ContainsKey(cIn) && required[cIn] == window[cIn]) {
                formed++;
            }

            while(formed == requiredCount) {
                if(res[0] == -1 || res[1] - res[0] + 1 > r - l + 1) {
                    res[0] = l;
                    res[1] = r;
                }

                char cOut = s[l];
                window[cOut]--;
                if(required.ContainsKey(cOut) && window[cOut] < required[cOut]) {
                    formed--;
                }

                l++;
            }

            r++;
        }

        return res[0] == -1 ? "" : s.Substring(res[0], res[1] - res[0] + 1);
    }
}
