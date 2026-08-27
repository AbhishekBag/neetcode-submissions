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
    public int GoodNodes(TreeNode root) {
        int res = 0;
        if(root == null) {
            return res;
        }

        Queue<(TreeNode, int)> q = new Queue<(TreeNode node, int max)>();
        q.Enqueue((root, root.val));
        // res++;

        while(q.Count > 0) {
            (TreeNode node, int max) = q.Dequeue();
            if(node.val >= max) {
                res++;
            }

            if(node.left != null) {
                q.Enqueue((node.left, Math.Max(max, node.val)));
            }

            if(node.right != null) {
                q.Enqueue((node.right, Math.Max(max, node.val)));
            }
        }

        return res;
    }
}
