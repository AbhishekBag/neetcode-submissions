public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) {
            return false;
        }

        int[] map = new int[26];
        for(int i = 0; i < s.Length; i++) {
            char si = s[i];
            char ti = t[i];
            map[si - 'a']++;
            map[ti - 'a']--;
        }

        for(int i = 0; i < 26; i++) {
            if(map[i] != 0) {
                return false;
            }
        }

        return true;
    }
}
