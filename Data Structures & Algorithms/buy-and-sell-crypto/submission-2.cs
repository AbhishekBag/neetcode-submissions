public class Solution {
    public int MaxProfit(int[] prices) {
        int maxP = 0;
        int minB = prices[0];

        foreach(int price in prices) {
            maxP = Math.Max(maxP, price - minB);
            minB = Math.Min(minB, price);
        }

        return maxP;
    }
}
