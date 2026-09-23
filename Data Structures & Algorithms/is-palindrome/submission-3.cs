public class Solution {
    public bool IsPalindrome(string s) {
        if(s.Length <= 1) {
            return true;
        }

        string str = GetCleanString(s);
        for(int i = 0, j = str.Length - 1; i < str.Length/2; i++, j--) {
            if(str[i] != str[j]) {
                return false;
            }
        }

        return true;
    }

    private string GetCleanString(string str) {
        StringBuilder sb = new StringBuilder();
        foreach(char c in str) {
            if(c >= 'A' && c <= 'Z') {
                sb.Append(c);
            }

            if(c >= 'a' && c <= 'z') {
                sb.Append(c);
            }

            if(c >= '0' && c <= '9') {
                sb.Append(c);
            }
        }

        return sb.ToString().ToLower();
    }
}
