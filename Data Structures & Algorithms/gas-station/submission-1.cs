public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int availableGas = 0;
        int totalGas = 0, totalCost = 0;
        int start = 0;

        for(int i = 0; i < gas.Length; i++) {
            availableGas += gas[i] - cost[i];
            totalGas += gas[i];
            totalCost += cost[i];

            if(availableGas < 0) {
                availableGas = 0;
                start = i + 1;
            }
        }

        return totalGas >= totalCost ? start : -1;
    }
}
