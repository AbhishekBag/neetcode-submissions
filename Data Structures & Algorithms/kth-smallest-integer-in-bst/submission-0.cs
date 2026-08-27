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
    private int kThSmall = 0;
    public int KthSmallest(TreeNode root, int k) {
        DFS(root, ref k);

        return kThSmall;
    }

    private void DFS(TreeNode root, ref int k) {
        if(root == null) {
            return;
        }

        DFS(root.left, ref k);
        k--;

        if(k == 0) {
            kThSmall = root.val;
            return;
        }
        
        DFS(root.right, ref k);
    }
}
