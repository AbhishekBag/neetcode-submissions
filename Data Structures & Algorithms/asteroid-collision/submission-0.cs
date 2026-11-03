public class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stk = new Stack<int>();

        for (int i = 0; i < asteroids.Length; i++)
        {
            int item = asteroids[i];

            while (stk.Count > 0 && stk.Peek() > 0 && item < 0)
            {
                if (Math.Abs(item) > Math.Abs(stk.Peek()))
                {
                    stk.Pop();
                }
                else
                {
                    if (Math.Abs(item) == Math.Abs(stk.Peek()))
                    {
                        item = 0;
                        stk.Pop();
                    } else {
                        item = 0;
                    }

                    break;
                }
            }

            if (item != 0)
            {
                stk.Push(item);
            }
        }

        return stk.Reverse().ToArray();
    }
}