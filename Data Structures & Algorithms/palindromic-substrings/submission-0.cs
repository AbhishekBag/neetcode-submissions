public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length;
        if(n <= 1) {
            return n;
        }

        int res = 0;

        for(int i = 0; i < n; i++) {
            int odd = NumberOfPalindromeCenteringAt(s, i, true);
            int even = NumberOfPalindromeCenteringAt(s, i, false);

            res = res + odd + even;
        }

        return res;
    }

    private int NumberOfPalindromeCenteringAt(string s, int i, bool isOddLength) {
        int n = s.Length;
        int left = isOddLength ? i - 1 : i;
        int right = i + 1;
        int count = isOddLength ? 1 : 0;

        while(left >= 0 && right < n && s[left] == s[right]) {
            left--;
            right++;
            count++;
        }

        return count;
    }
}
