public class Solution {
    public List<int> PartitionLabels(string s) {
        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        List<(int start, int end)> lst = new List<(int, int)>();

        for(int i = 0; i < s.Length; i++) {
            char c = s[i];
            if(!indexMap.ContainsKey(c)) {
                indexMap[c] = lst.Count;
                lst.Add((i, i));
            } else {
                var spanC = lst[indexMap[c]];
                spanC.end = i;
                lst[indexMap[c]] = spanC;
            }
        }

        List<(int start, int end)> res = new List<(int, int)>();
        res.Add(lst.FirstOrDefault());
        for(int i = 1; i < lst.Count; i++) {
            var current = lst[i];
            var last = res[res.Count - 1];
            if(current.start < last.end) {
                last.end = Math.Max(last.end, current.end);
                res[res.Count - 1] = last;
            } else {
                res.Add(current);
            }
        }

        return res.Select(span => span.end - span.start + 1).ToList();
    }
}

/*
 0 1 2 3 4 5 6 7 8 9 10 11 12
"x y x x y z b z b b i  s  l"

x=> 0, 3
y=> 1, 4
z=> 5, 7
b=> 6, 9
i=> 10, 10
s=> 11, 11
l=> 12, 12
*/