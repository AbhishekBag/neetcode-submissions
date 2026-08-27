public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stk = new Stack<int>();
        foreach(string s in tokens) {
            if(s ==  "+" || s == "-" || s == "*" || s == "/") {
                int op2 = stk.Pop();
                int op1 = stk.Pop();
                switch (s) {
                    case ("+"):
                        stk.Push(op1 + op2);
                        break;
                    case ("-"):
                        stk.Push(op1 - op2);
                        break;
                    case ("*"):
                        stk.Push(op1 * op2);
                        break;
                    case ("/"):
                        stk.Push(op1/op2);
                        break;
                }

                // Console.WriteLine($"op1: {op1}, op2: {op2}, operator: {s}, result: {stk.Peek()}");
            } else {
                stk.Push(Convert.ToInt32(s));
            }
        }

        return stk.Pop();
    }
}
