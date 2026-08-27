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
    private int maxDia = 0;
    public int DiameterOfBinaryTree(TreeNode root) {
        if(root == null) {
            return 0;
        }

        TravarseTree(root);

        return maxDia;
    }

    private int TravarseTree(TreeNode root) {
        if(root == null) {
            return 0;
        }

        int leftHeight = TravarseTree(root.left);
        int rightHeight = TravarseTree(root.right);

        maxDia = Math.Max(maxDia, leftHeight + rightHeight);

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
