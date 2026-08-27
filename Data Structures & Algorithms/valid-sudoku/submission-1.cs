public class Solution {
    public bool IsValidSudoku(char[][] board) {
        return ValidateRows(board, 0, 9)
                && ValidateCols(board, 0, 9)
                && ValidateBlocks(board, 0, 9, 3);
    }

    private bool ValidateRows(char[][] board, int start, int end) {
        for(int i = start; i < end; i++) {
            int[] arr = new int[10];
            for(int j = start; j < end; j++) {
                int num = 0;
                // Console.Write($"ValidateRow i: {i}, j: {j}, board[i][j]: {board[i][j]}, num: {num}, before update: num: {num}, arr[num]: {arr[num]}");
                if (Int32.TryParse(board[i][j].ToString(), out num)) {
                    if (arr[num] != 0) {
                        // Console.WriteLine($"ValidateRow:Returning false for i: {i}, j: {j}, num: {num}; arr[num]: {arr[num]}");
                        return false;
                    }

                    arr[num] = num;
                }
                // Console.Write($"; after update: num: {num}, arr[num]: {arr[num]}");
                // Console.WriteLine();
            }
        }

        return true;
    }

    private bool ValidateCols(char[][] board, int start, int end) {
        for(int i = start; i < end; i++) {
            int[] arr = new int[10];
            for(int j = start; j < end; j++) {
                int num = 0;
                // Console.Write($"ValidateCols i: {i}, j: {j}, board[j][i]: {board[j][i]}, num: {num}, before update: num: {num}, arr[num]: {arr[num]}");
                if (Int32.TryParse(board[j][i].ToString(), out num)) {
                    if (arr[num] != 0) {
                        // Console.WriteLine($"ValidateCols:Returning false for i: {i}, j: {j}, num: {num}; arr[num]: {arr[num]}");
                        return false;
                    }

                    arr[num] = num;
                }
                // Console.Write($"; after update: num: {num}, arr[num]: {arr[num]}");
                // Console.WriteLine();
            }
        }

        return true;
    }

    private bool ValidateBlock(char[][] board, int r, int c, int w) {
        // Console.WriteLine($"ValidateBlock: r: {r}, c: {c}");
        int[] arr = new int[10];
        for (int i = r; i < r + w; i++) {
            for (int j = c; j < c + w; j++) {
                int num = 0;
                // bool success = ;
                // Console.Write($"ValidateBlock i: {i}, j: {j}, board[i][j]: {board[i][j]}, num: {num}, before update: num: {num}, arr[num]: {arr[num]}");
                if (Int32.TryParse(board[i][j].ToString(), out num)) {
                    if (arr[num] != 0) {
                        // Console.WriteLine($"ValidateBlock:Returning false for i: {i}, j: {j}, num: {num}; arr[num]: {arr[num]}");
                        return false;
                    }

                    arr[num] = num;
                }
                // Console.Write($"; after update: num: {num}, arr[num]: {arr[num]}");
                // Console.WriteLine();
            }
        }
        return true;
    }

    private bool ValidateBlocks(char[][] board, int start, int end, int w) {
        for(int i = start; i < end; i = i + w) {
            for(int j = start; j < end; j = j + w) {
                if(!ValidateBlock(board, i, j, w)) {
                    return false;
                }
            }
        }

        return true;
    }
}
