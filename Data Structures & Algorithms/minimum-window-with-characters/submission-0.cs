public class Solution {
    public string MinWindow(string s, string t) {
        if(t.Length <= 0) {
            return "";
        }

        Dictionary<char, int> sMap = new Dictionary<char, int>();
        Dictionary<char, int> tMap = new Dictionary<char, int>();

        foreach(char c in t) {
            if(!tMap.ContainsKey(c)) {
                tMap[c] = 0;
            }

            tMap[c]++;
        }

        int have = 0, need = tMap.Count, l = 0;
        int minLength = Int32.MaxValue;
        int[] res = new int[] { -1, -1 };

        for(int r = 0; r < s.Length; r++) {
            char c = s[r];
            if(!sMap.ContainsKey(c)) {
                sMap[c] = 0;
            }

            sMap[c]++;

            if(tMap.ContainsKey(c) && tMap[c] == sMap[c]) {
                have++;
            }

            while(have == need) {
                if(r - l + 1 < minLength) {
                    minLength = r - l + 1;
                    res[0] = l;
                    res[1] = r;
                }

                sMap[s[l]]--;
                if(tMap.ContainsKey(s[l]) && sMap[s[l]] < tMap[s[l]]) {
                    have--;
                }

                l++;
            }
        }

        return minLength == Int32.MaxValue ? "" : s.Substring(res[0], minLength);
    }
}
