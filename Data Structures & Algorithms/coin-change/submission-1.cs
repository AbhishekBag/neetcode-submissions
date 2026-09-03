public class Solution {
    private Dictionary<int, int> memo;
    public int CoinChange(int[] coins, int amount) {
        memo = new Dictionary<int, int>();
        int minCoins = Change(coins, amount);

        return minCoins == Int32.MaxValue ? -1 : minCoins;
    }

    private int Change(int[] coins, int amount) {
        if(amount == 0) {
            return 0;
        }

        if(memo.ContainsKey(amount)) {
            return memo[amount];
        }

        int res = Int32.MaxValue;
        foreach(var coin in coins) {
            if(amount - coin >= 0) {
                int change = Change(coins, amount - coin);
                if(change != Int32.MaxValue)
                    res = Math.Min(res, 1 + change);
            }
        }

        memo[amount] = res;
        return res;
    }
}
