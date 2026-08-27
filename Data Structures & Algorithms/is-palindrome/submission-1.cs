public class Solution {
    public bool IsPalindrome(string s) {
        string str = CleanString(s.ToLower());
        int n = str.Length;

        for(int i = 0; i < n/2; i++) {
            if(str[i] != str[n - i - 1]) {
                return false;
            }
        }

        return true;
    }

    private string CleanString(string s) {
        StringBuilder sb = new StringBuilder();
        foreach(char c in s) {
            if(char.IsLetterOrDigit(c)) {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
