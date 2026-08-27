public class Solution {
    public string MinWindow(string s, string t) {
        int sn = s.Length;
        int tn = t.Length;
        Dictionary<char, int> sMap = new Dictionary<char, int>();
        Dictionary<char, int> tMap = GetCharMap(t, 0, tn);
        int[] res = new int[2] { -1, -1 };
        int l = 0, r = 0;

        while(r < sn) {
            char cIn = s[r];
            InsertChar(sMap, cIn);

            // Console.WriteLine($"Insert into sMap: key: {cIn}, current value: {sMap[cIn]}");

            while(IsMatched(sMap, tMap)) {
                RecordMinWindow(res, l, r);
                RemoveChar(sMap, s[l++]);
            }

            r++;
        }

        return res[0] == -1 ? "" : s.Substring(res[0], res[1] - res[0] + 1);
    }

    public bool IsMatched(Dictionary<char, int> m1, Dictionary<char, int> m2) {

        // Console.WriteLine($"m1 keys: {string.Join(", ", m1.Keys.ToList())}");
        
        if(m1.Count >= m2.Count) {
            foreach(char c in m2.Keys) {
                // if(m1.ContainsKey(c)) {
                //     Console.Write($"m2[{c}] -> {m2[c]}, m1[{c}] -> {m1[c]}; ");
                // }

                if(!m1.ContainsKey(c) || m1[c] < m2[c]) {
                    // Console.WriteLine("Returning false");
                    return false;
                }
            }

            // Console.WriteLine("returning true");
            return true;
        }

        return false;
    }

    public void RemoveChar(Dictionary<char, int> m, char c) {
        if(m.ContainsKey(c)) {
            if(m[c] == 1) {
                m.Remove(c);
            } else {
                m[c]--;
            }
        }
    }

    public void InsertChar(Dictionary<char, int> m, char c) {
        if(!m.ContainsKey(c)) {
            m[c] = 0;
        }

        m[c]++;
    }

    // O U Z O D Y X A Z V
    // 0 1 2 3 4 5 6 7 8 9

    public void RecordMinWindow(int[] res, int l, int r) {

        // Console.WriteLine($"recording min window: l: {l}, r: {r}, res[0]: {res[0]}, res[1]: {res[1]}");

        int minWindow = res[1] - res[0] + 1;
        int curWindow = r - l + 1;
        if(res[0] == -1 || curWindow < minWindow) {
            res[0] = l;
            res[1] = r;
        }
    }

    public Dictionary<char, int> GetCharMap(string str, int l, int r) {
        Dictionary<char, int> map = new Dictionary<char, int>();
        for(int i = l; i < r; i++) {
            char c = str[i];
            if(!map.ContainsKey(c)) {
                map[c] = 0;
            }

            map[c]++;
        }

        return map;
    }
}
