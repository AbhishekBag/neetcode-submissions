public class Solution {
    private List<List<string>> res;
    public List<List<string>> Partition(string s) {
        res = new List<List<string>>();
        Backtracking(s, new List<string>(), 0);

        return res;
    }

    public void Backtracking(string s, List<string> cur, int i) {
        if(i >= s.Length) {
            res.Add(cur.ToList());
            return;
        }

        for(int j = i; j < s.Length; j++) {
            if(IsPalindrome(s, i, j)) {
                cur.Add(s.Substring(i, j - i + 1));
                Backtracking(s, cur, j + 1);
                cur.RemoveAt(cur.Count() - 1);
            }
        }
    }

    public bool IsPalindrome(string s, int i, int j) {
        while(i < j) {
            if(s[i] != s[j]) {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }
}
