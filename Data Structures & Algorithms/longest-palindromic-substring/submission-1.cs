public class Solution {
    public string LongestPalindrome(string s) {
        string res = s[0].ToString();

        for(int i = 0; i < s.Length; i++) {
            string oddP = GetPalindromicStringAtI(s, i, true);
            string evenP = GetPalindromicStringAtI(s, i, false);

            string tmp = oddP.Length > evenP.Length ? oddP : evenP;
            res = res.Length > tmp.Length ? res : tmp;
        }

        return res;
    }

    private string GetPalindromicStringAtI(string s, int i, bool oddCheck) {
        int n = s.Length;
        int left = oddCheck ? i - 1 : i;
        int right = i + 1;

        while(left >= 0 && right < n && s[left] == s[right]) {
            left--;
            right++;
        }

        left++;
        right--;

        return s.Substring(left, right - left + 1);
    }
}
