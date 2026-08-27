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
    public int MaxDepth(TreeNode root) {
        if(root == null) {
            return 0;
        }

        int maxDepth = 0;
        Queue<(TreeNode, int)> q = new Queue<(TreeNode, int)>();
        q.Enqueue((root, 1));

        while(q.Count > 0) {
            var dq = q.Dequeue();
            var node = dq.Item1;
            var depth = dq.Item2;
            maxDepth = Math.Max(maxDepth, depth);
            if(node.left != null) {
                q.Enqueue((node.left, depth + 1));
            }

            if(node.right != null) {
                q.Enqueue((node.right, depth + 1));
            }
        }

        return maxDepth;
    }
}
