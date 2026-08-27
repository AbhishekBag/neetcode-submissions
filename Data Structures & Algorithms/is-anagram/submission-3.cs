public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) {
            return false;
        }

        int[] map = new int[26];
        for(int i = 0; i < s.Length; i++) {
            map[s[i] - 'a']++;
            map[t[i] - 'a']--;
        }

        for(int i = 0; i < 26; i++) {
            if(map[i] != 0) {
                return false;
            }
        }

        return true;
    }
}
