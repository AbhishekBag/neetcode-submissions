public class Solution {
    private int[] memo;
    public int CoinChange(int[] coins, int amount) {
        memo = Enumerable.Repeat(-2, amount + 1).ToArray();
        return CountCoin(coins, amount);
    }

    private int CountCoin(int[] coins, int amount) {
        if(amount <= 0) {
            return 0;
        }

        if(memo[amount] != -2) {
            return memo[amount];
        }

        int count = Int32.MaxValue;
        foreach(int coin in coins) {
            if(coin <= amount) {
                int change = CountCoin(coins, amount - coin);
                if(change != -1) {
                    count = Math.Min(count, 1 + change);
                }
            }
        }

        memo[amount] = count == Int32.MaxValue ? -1 : count;

        return memo[amount];
    }
}
