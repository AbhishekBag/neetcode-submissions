public class Solution {
    public bool IsAnagram(string s, string t) {
        int n = s.Length;
        if(n != t.Length) {
            return false;
        }

        int[] sMap = new int[26];
        int[] tMap = new int[26];

        for(int i = 0; i < n; i++) {
            sMap[s[i] - 'a']++;
            tMap[t[i] - 'a']++;
        }

        return CompareMap(sMap, tMap);
    }

    private bool CompareMap(int[] sMap, int[] tMap) {
        for(int i = 0; i < 26; i++) {
            if(sMap[i] != tMap[i]) {
                return false;
            }
        }

        return true;
    }
}
