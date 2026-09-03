public class Solution {
    private int[] memo;
    private Dictionary<string, char> map;
    public int NumDecodings(string s) {
        if(s.Length == 0) {
            return 0;
        }

        memo = Enumerable.Repeat(-1, s.Length).ToArray();
        map = new Dictionary<string, char>();

        for(int i = 1; i <= 26; i++) {
            map[i.ToString()] = Convert.ToChar('A' + i - 1);

            // Console.WriteLine($"map[{i.ToString()}] = {map[i.ToString()]}");
        }

        return ParseString(s, 0);
    }

    private int ParseString(string s, int i) {
        int n = s.Length;
        if(i >= n) {
            return 1;
        }

        if(s[i] == '0') {
            return 0;
        }

        if(memo[i] != -1) {
            return memo[i];
        }

        int parse1Char = ParseString(s, i + 1);

        int parse2Char = 0;
        if(i < n - 1) {
            string k2Char = s.Substring(i, 2);         
            if(map.ContainsKey(k2Char)) {
                parse2Char = ParseString(s, i + 2);
            }
        }

        memo[i] = parse1Char + parse2Char;

        return memo[i];
    }
}
