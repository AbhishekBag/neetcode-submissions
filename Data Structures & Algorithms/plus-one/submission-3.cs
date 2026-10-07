public class Solution {
    public int[] PlusOne(int[] digits) {
        int c = 0;
        int n = digits.Length;
        List<int> res = new List<int>();
        int sum = digits[n - 1] + 1;
        if(sum >= 10) {
            c = sum / 10;
            sum = sum % 10;
        }

        if(c == 0) {
            digits[n - 1] = sum;
            return digits;
        }

        res.Add(sum);
        int i = n - 2;
        
        while(c != 0 && i >= 0) {
            sum = digits[i] + c;
            if(sum >= 10) {
                c = sum / 10;
                sum = sum % 10;
            } else {
                c = 0;
            }

            res.Insert(0, sum);
            i--;
        }

        while(i >= 0) {
            res.Insert(0, digits[i--]);
        }

        if(c != 0) {
            res.Insert(0, c);
        }

        return res.ToArray();
    }
}
