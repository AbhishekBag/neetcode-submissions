public class Solution {
    private List<string> res;
    Dictionary<char, List<char>> map;
    public List<string> LetterCombinations(string digits) {
        res = new List<string>();
        map = new Dictionary<char, List<char>>();
        map.Add('2', new List<char> {'a', 'b', 'c'});
        map.Add('3', new List<char> {'d', 'e', 'f'});
        map.Add('4', new List<char> {'g', 'h', 'i'});
        map.Add('5', new List<char> {'j', 'k', 'l'});
        map.Add('6', new List<char> {'m', 'n', 'o'});
        map.Add('7', new List<char> {'p', 'q', 'r', 's'});
        map.Add('8', new List<char> {'t', 'u', 'v'});
        map.Add('9', new List<char> {'w', 'x', 'y', 'z'});

        if(digits.Length == 0) {
            return res;
        }

        Backtracking(digits, null, 0);

        return res;
    }

    private void Backtracking(string digits, string cur, int i) {
        if(i >= digits.Length) {
            res.Add(cur);
            return;
        }

        char ch = digits[i];
        foreach(char c in map[ch]) {
            Backtracking(digits, cur + c, i + 1);
        }
    }
}
