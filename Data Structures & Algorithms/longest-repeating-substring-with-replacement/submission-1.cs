public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] map = new int[26];
        int l = 0, r = 0, res = 0;
        int n = s.Length;

        if(n <= k) {
            return n;
        }

        while(r < n) {
            int cIn = s[r] - 'A';
            map[cIn]++;

            while(r - l + 1 - map.Max() > k) {
                int cOut = s[l++] - 'A';
                map[cOut]--;
            }

            res = Math.Max(res, r - l + 1);
            r++;
        }

        return res;
    }
}
