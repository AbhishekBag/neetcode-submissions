public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int n1 = s1.Length, n2 = s2.Length;
        if(n1 > n2) {
            return false;
        }

        int[] m1 = GetCharMap(s1, 0, n1);
        int[] m2 = GetCharMap(s2, 0, n1);

        // if(n1 == n2) {
        //     return IsMatching(m1, m2);
        // }

        int l = 0, r = n1;
        while(r < n2) {
            if(IsMatching(m1, m2)) {
                return true;
            }

            m2[s2[r++] - 'a']++;
            m2[s2[l++] - 'a']--;
        }

        if(IsMatching(m1, m2)) {
            return true;
        }

        return false;
    }

    public int[] GetCharMap(string str, int l, int r) {
        int[] map = new int[26];
        for(int i = l; i < r; i++) {
            map[str[i] - 'a']++;
        }

        return map;
    }

    public bool IsMatching(int[] m1, int[] m2) {
        for(int i = 0; i < 26; i++) {
            if(m1[i] != m2[i]) {
                return false;
            }
        }

        return true;
    }
}
