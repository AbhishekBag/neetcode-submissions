public class Solution {
    public bool IsHappy(int n) {
        HashSet<int> map = new HashSet<int>();

        // Console.WriteLine("Enter with n: " + n);

        while(n != 1 && !map.Contains(n)) {
            map.Add(n);
            int sum = 0;
            // Console.Write($"start n: {n}. ");
            while(n > 0) {
                int r = n % 10;
                sum += r * r;
                n = n / 10;
            }

            n = sum;

            // Console.WriteLine($"end n: {n}");
        }

        return n == 1;
    }
}
