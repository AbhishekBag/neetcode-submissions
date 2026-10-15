public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        int i = 0;
        if(strs == null || strs.Length == 0) {
            return "";
        }
        
        for(; i < strs[0].Length; i++) {
            char c = strs[0][i];
            for(int j = 1; j < strs.Length; j++) {
                // Console.WriteLine($"i: {i}, c : {c}, j: {j}");
                if(i >= strs[j].Length || strs[j][i] != c) {
                    return strs[j].Substring(0, i);
                }
            }
        }

        // Console.WriteLine($"i: {i}");

        return strs[0];
    }
}