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
    private List<int> res;
    public List<int> RightSideView(TreeNode root) {
        res = new List<int>();

        GetRightView(root, 0);

        return res;
    }

    public void GetRightView(TreeNode root, int level) {
        if(root == null) {
            return;
        }

        if(res.Count() <= level) {
            res.Add(root.val);
        } else {
            res[level] = root.val;
        }

        GetRightView(root.left, level + 1);
        GetRightView(root.right, level + 1);
    }
}
