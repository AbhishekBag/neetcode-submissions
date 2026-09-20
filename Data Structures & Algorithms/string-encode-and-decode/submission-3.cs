public class Solution {

    public string Encode(IList<string> strs) {
        StringBuilder sb = new StringBuilder();
        foreach(var str in strs) {
            sb.Append(str.Length)
                .Append(":")
                .Append(str);
        }

        return sb.ToString();
    }

    /*
    "Hello","World"
    => "5:Hello5:World"
    =>  0123456789
    */

    public List<string> Decode(string s) {
        List<string> res = new List<string>();
        int i = 0;
        while(i < s.Length) {
            int j = i;
            while(s[j] != ':') {
                j++;
            }

            int len = int.Parse(s.Substring(i, j - i));
            string str = s.Substring(j + 1, len);
            res.Add(str);
            i = j + len + 1;
        }

        return res;
   }
}
