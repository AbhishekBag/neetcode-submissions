public class Solution {
    public string LongestPalindrome(string s) {
        int n = s.Length;
        if(n <= 1) {
            return s;
        }

        string res = s[0].ToString();

        for(int i = 0; i < n; i++) {
            string odd = GetMaxPalindromeStringStartingAtCenter(s, i, true);
            string even = GetMaxPalindromeStringStartingAtCenter(s, i, false);

            string tmp = odd.Length > even.Length ? odd :even;

            if(res.Length < tmp.Length) {
                res = tmp;
            }
        }

        return res;
    }

    private string GetMaxPalindromeStringStartingAtCenter(string s, int i, bool checkOddLength) {
        int n = s.Length;
        int left = checkOddLength ? i - 1 : i;
        int right = i + 1;

        while(left >= 0 && right < n && s[left] == s[right]) {
            left--;
            right++;
        }

        left += 1;
        right -= 1;

        return s.Substring(left, right - left + 1);
    }
}
