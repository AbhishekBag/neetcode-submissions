public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        if(matrix[0][0] > target || matrix[matrix.Length - 1][matrix[0].Length - 1] < target) {
            return false;
        }

        int row = GetRow(matrix, target);

        // Console.WriteLine($"row = {row}");

        // if(row == -1) {
        //     return false;
        // }

        if(matrix[row][0] == target) {
            return true;
        }

        return SearchItem(matrix, target, row);
    }

    private int GetRow(int[][] matrix, int target) {
        int i = 0, j = matrix.Length - 1;

        while(i <= j) {
            int mid = i + (j - i)/2;
            if(matrix[mid][0] == target) {
                return mid;
            }

            if(matrix[mid][0] > target) {
                j = mid - 1;
            } else {
                i = mid + 1;
            }
        }

        return i - 1;
    }

    private bool SearchItem(int[][] matrix, int target, int row) {
        int i = 0, j = matrix[0].Length - 1;

        while(i <= j) {
            int mid = i + (j - i)/2;
            if(matrix[row][mid] == target) {
                return true;
            }

            if(matrix[row][mid] > target) {
                j = mid - 1;
            } else {
                i = mid + 1;
            }
        }

        return false;
    }
}
