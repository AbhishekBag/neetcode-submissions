public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        List<List<string>> res = new List<List<string>>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        foreach(string str in strs) {
            var arr = str.ToArray();
            Array.Sort(arr);

            string arrStr = new String(arr);
            if(!map.ContainsKey(arrStr)) {
                map[arrStr] = new List<string>();
            }

            map[arrStr].Add(str);
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
