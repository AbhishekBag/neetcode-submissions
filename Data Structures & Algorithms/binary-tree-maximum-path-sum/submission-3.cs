/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {
    private int maxSum = Int32.MinValue;
    public int MaxPathSum(TreeNode root) {
        TraverseTree(root);

        return maxSum;
    }

    private int TraverseTree(TreeNode root) {
        if(root == null) {
            return 0;
        }

        int leftSum = TraverseTree(root.left);
        int rightSum = TraverseTree(root.right);

        int currentSum = root.val +
                        Math.Max(0, leftSum) +
                        Math.Max(0, rightSum);
        
        maxSum = Math.Max(maxSum, currentSum);

        return root.val + Math.Max(0, Math.Max(leftSum, rightSum));

        // maxSum = Math.Max(maxSum, Math.Max(root.val,
        //     Math.Max(leftSum + rightSum + root.val,
        //     Math.Max(leftSum, rightSum) + root.val)));

        // if(leftSum < 0 && rightSum < 0) {
        //     return root.val;
        // }
        // if(leftSum < 0) {
        //     return rightSum + root.val;
        // }
        
        // return leftSum + root.val;
    }
}
