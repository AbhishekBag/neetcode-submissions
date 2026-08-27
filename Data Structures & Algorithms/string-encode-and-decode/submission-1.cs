public class Solution {

    public string Encode(IList<string> strs) {
        StringBuilder sb = new StringBuilder();
        foreach(string str in strs) {
            sb.Append(str.Length)
            .Append(':')
            .Append(str);
        }

        return sb.ToString();
    }

    public List<string> Decode(string s) {
        List<string> res = new List<string>();
        int i = 0;

        while(i < s.Length) {
            int j = i;

            while(s[j] != ':') {
                j++;
            }

            int length = int.Parse(s.Substring(i, j - i));

            string str = s.Substring(j + 1, length);
            res.Add(str);
            i = j + length + 1;
        }

        return res;
   }
}
