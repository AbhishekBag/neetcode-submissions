public class Solution {
    public List<int> PartitionLabels(string s) {
        Dictionary<char, int> lastIndex = new Dictionary<char, int>();

        for(int i = 0; i < s.Length; i++) {
            lastIndex[s[i]] = i;
        }

        List<int> res = new List<int>();
        int size = 0, end = 0;
        for(int i = 0; i < s.Length; i++) {
            size++;
            end = Math.Max(end, lastIndex[s[i]]);

            if(end == i) {
                res.Add(size);
                size = 0;
            }
        }

        return res;
    }
}
/*
0 1 2 3 4 5
a b c a b c

a => 3
b => 4
c => 5
*/