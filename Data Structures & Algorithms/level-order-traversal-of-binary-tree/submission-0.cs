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
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<(int, int)>> res = new List<List<(int val, int l)>>();
        if(root == null) {
            return new List<List<int>>();
        }

        Queue<(TreeNode, int)> q = new Queue<(TreeNode node, int level)>();
        q.Enqueue((root, 0));
        while(q.Count > 0) {
            var (node, level) = q.Dequeue();

            if(res.Count == 0) {
                res.Add(new List<(int, int)>() { (node.val, level) });
            } else if(res[^1][0].Item2 == level) {
                res[^1].Add((node.val, level));
            } else {
                res.Add(new List<(int, int)>() { (node.val, level) });
            }

            if(node.left != null) {
                q.Enqueue((node.left, level + 1));
            }

            if(node.right != null) {
                q.Enqueue((node.right, level + 1));
            }
        }

        // return res.Select(x => 
        //     x.Select(y => new List<int> { y.Item1 }).ToList()
        // ).ToList();

        var final = new List<List<int>>();
        foreach(var r in res) {
            final.Add(
                r.Select(x => x.Item1).ToList()
            );
        }

        return final;
    }
}
