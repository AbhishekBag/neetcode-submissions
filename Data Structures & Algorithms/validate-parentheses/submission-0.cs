public class Solution {
    public bool IsValid(string s) {
        Stack<char> stk = new Stack<char>();
        foreach(char c in s) {
            if(c == ')' || c == '}' || c == ']') {
                if(stk.Count == 0) {
                    return false;
                }

                char poped = stk.Pop();
                if(c == ')' && poped != '(' ||
                c == '}' && poped != '{' ||
                c == ']' && poped != '[') {
                    return false;
                }
            } else {
                stk.Push(c);
            }
        }

        return stk.Count == 0 ? true : false;
    }
}
