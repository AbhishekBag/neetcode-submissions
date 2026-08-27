public class Solution {

    public string Encode(IList<string> strs) {
        StringBuilder sb = new StringBuilder();

        foreach(string str in strs) {
            sb.Append(str.Length)
            .Append(":")
            .Append(str);
        }

        return sb.ToString();
    }

    // 0123456789
    // 4:neet4:code4:love3:you

    public List<string> Decode(string s) {
        List<string> strs = new List<string>();
        int i = 0;

        while(i < s.Length) {
            int j = i;

            while(s[j] != ':') {
                j++;
            }

            int length = int.Parse(s.Substring(i, j - i));

            string str = s.Substring(j + 1, length);
            strs.Add(str);
            i = j + length + 1;
        }

        return strs;
   }
}
