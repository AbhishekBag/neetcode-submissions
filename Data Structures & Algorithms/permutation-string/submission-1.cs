public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length > s2.Length) {
            return false;
        }
        
        int[] s1Map = new int[26];
        int[] s2Map = new int[26];

        for(int i = 0; i < s1.Length; i++) {
            s1Map[s1[i] - 'a']++;
            s2Map[s2[i] - 'a']++;
        }

        int matches = 0;
        for(int i = 0; i < 26; i++) {
            if(s1Map[i] == s2Map[i]) {
                matches++;
            }
        }

        int l = 0;
        for(int r = s1.Length; r < s2.Length; r++) {
            if(matches == 26) {
                return true;
            }

            int i = s2[r] - 'a';
            s2Map[i]++;
            if(s1Map[i] == s2Map[i]) {
                matches++;
            } else if(s1Map[i] + 1 == s2Map[i]) {
                matches--;
            }

            i = s2[l] - 'a';
            s2Map[i]--;
            if(s1Map[i] == s2Map[i]) {
                matches++;
            } else if(s1Map[i] - 1 == s2Map[i]) {
                matches--;
            }

            l++;
        }

        return matches == 26;
    }
}
