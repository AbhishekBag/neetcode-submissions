public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach(string str in strs) {
            char[] arr = new char[26];
            foreach(char c in str) {
                arr[c - 'a']++;
            }

            string key = string.Join(",", arr);
            if(!map.ContainsKey(key)) {
                map[key] = new List<string>();
            }

            map[key].Add(str);
        }

        return map.Values.ToList();
    }
}
