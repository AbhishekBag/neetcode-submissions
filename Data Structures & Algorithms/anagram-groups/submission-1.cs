public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> res = new List<List<string>>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        var sortedStrs = strs.Select(x => new string(x.OrderBy(i => i).ToArray())).ToArray();

        for(int i = 0; i < sortedStrs.Length; i++) {
            var key = sortedStrs[i];
            if(!map.ContainsKey(key)) {
                map[key] = new List<string>();
            }

            map[key].Add(strs[i]);
        }

        foreach(var value in map.Values) {
            res.Add(value);
        }

        return res;
    }

    private void PrintArr(string[] strs) {
        foreach(var str in strs) {
            Console.Write($"{str}, ");
        }

        Console.WriteLine();
    }
}
