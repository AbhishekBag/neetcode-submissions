public class MinStack {
    private Stack<(int, int)> stk;

    public MinStack() {
        stk = new Stack<(int val, int min)>();
    }
    
    public void Push(int val) {
        if(stk.Count == 0) {
            stk.Push((val, val));

            return;
        }

        var peeked = stk.Peek();
        int min = Math.Min(val, peeked.Item2);
        stk.Push((val, min));
    }
    
    public void Pop() {
        stk.Pop();
    }
    
    public int Top() {
        var peeked = stk.Peek();
        return peeked.Item1;
    }
    
    public int GetMin() {
        var peeked = stk.Peek();
        return peeked.Item2;
    }
}
