public class Solution {
    public int CountSubstrings(string s) {
        int count = 0;
        for(int i = 0; i < s.Length; i++) {
            int oddCount = GetPalindromeCountAtI(s, i, true);
            int evenCount = GetPalindromeCountAtI(s, i, false);

            count += oddCount + evenCount;
        }

        return count;
    }

    private int GetPalindromeCountAtI(string s, int i, bool oddFlag) {
        int n = s.Length;
        int left = oddFlag ? i - 1 : i;
        int right = i + 1;
        int count = oddFlag ? 1 : 0;

        while(left >= 0 && right < n && s[left] == s[right]) {
            left--;
            right++;
            count++;
        }

        // count--;

        return count;
    }
}
