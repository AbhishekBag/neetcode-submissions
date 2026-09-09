public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        foreach(int num in hand) {
            if(!map.ContainsKey(num)) {
                map[num] = 0;
            }

            map[num] += 1;
        }

        Array.Sort(hand);
        foreach(int num in hand) {
            if(map[num] > 0) {
                for(int i = num; i < num + groupSize; i++) {
                    if(!map.ContainsKey(i) || map[i] <= 0) {
                        return false;
                    }
                    map[i]--;
                }
            }            
        }

        return true;
    }
}
