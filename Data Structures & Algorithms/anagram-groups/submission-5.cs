public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> res = new List<List<string>>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach(string str in strs) {
            int[] count = new int[26];
            foreach(char c in str) {
                count[c - 'a']++;
            }

            string key = string.Join(",", count);

            if(!map.ContainsKey(key)) {
                map[key] = new List<string>();
            }

            map[key].Add(str);
        }

        // PrintMap(map);

        return map.Values.ToList();
    }

    private void PrintMap(Dictionary<string, List<string>> map) {
        foreach(var strList in map.Values) {
            Console.WriteLine(string.Join(", ", strList));
        }
    }
}
