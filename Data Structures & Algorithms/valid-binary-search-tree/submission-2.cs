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
    public bool IsValidBST(TreeNode root) {
        return IsBST(root, Int32.MinValue, Int32.MaxValue);
    }

    private bool IsBST(TreeNode root, int left, int right) {
        if(root == null) {
            return true;
        }

        if(root.val <= left || root.val >= right) {
            return false;
        }

        return IsBST(root.left, left, root.val) &&
                IsBST(root.right, root.val, right);
    }
}
