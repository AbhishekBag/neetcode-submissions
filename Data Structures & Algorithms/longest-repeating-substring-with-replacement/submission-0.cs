public class Solution {
    private int[] map;
    public int CharacterReplacement(string s, int k) {
        int n = s.Length;
        if(n <= k) {
            return n;
        }

        int l = 0, r = 0, res = 0;
        map = new int[26];

        while(r < n) {
            int cIn = s[r] - 'A';
            map[cIn]++;

            while(r - l + 1 - GetMaxCount() > k) {
                int cOut = s[l++] - 'A';
                map[cOut]--;
            }

            res = Math.Max(res, r - l + 1);
            r++;
        }

        return res;
    }

    private int GetMaxCount() {
        int max = 0;
        for(int i = 0; i < 26; i++) {
            max = Math.Max(max, map[i]);
        }

        return max;
    }
}
