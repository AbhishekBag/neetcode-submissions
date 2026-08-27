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
    // private bool isBalanced = true;
    public bool IsBalanced(TreeNode root) {
        if(root == null) {
            return true;
        }

        return TravarseTree(root) != -1;

        // return isBalanced;
    }

    private int TravarseTree(TreeNode root) {
        if(root == null) {
            return 0;
        }

        int leftHeight = TravarseTree(root.left);
        if(leftHeight == -1) {
            return -1;
        }

        int rightHeight = TravarseTree(root.right);
        if(rightHeight == -1) {
            return -1;
        }

        if(Math.Abs(leftHeight - rightHeight) > 1) {
            return -1;
        }

        // isBalanced = isBalanced && Math.Abs(leftHeight - rightHeight) < 2 ? true : false;

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
