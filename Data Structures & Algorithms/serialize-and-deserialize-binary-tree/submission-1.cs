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

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();
        Queue<TreeNode> q = new Queue<TreeNode>();

        q.Enqueue(root);
        while(q.Count > 0) {
            var dq = q.Dequeue();

            if(dq == null) {
                sb.Append("*,");
                continue;
            } else {
                sb.Append(dq.val);
                sb.Append(',');
            }
            
            q.Enqueue(dq.left);
            q.Enqueue(dq.right);            
        }

        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    // "1,2,3,*,*,4,5,*,*,*,*,"
    public TreeNode Deserialize(string data) {
        if(data == "*,") {
            return null;
        }

        // TreeNode rootPointer = new TreeNode();
        Queue<TreeNode> q = new Queue<TreeNode>();
        int i = 0;

        (string item, i) = GetNext(data, i);
        TreeNode root = new TreeNode(Int32.Parse(item));
        q.Enqueue(root);

        while(q.Count > 0 && i < data.Length) {
            var dq = q.Dequeue();

            if(i < data.Length) {
                (item, i) = GetNext(data, i);
                if(item == "*") {
                    dq.left = null;
                } else {
                    int val = Int32.Parse(item);
                    dq.left = new TreeNode(val);
                    q.Enqueue(dq.left);
                }
            } else {
                break;
            }
            
            if(i < data.Length) {
                (item, i) = GetNext(data, i);
                if(item == "*") {
                    dq.right = null;
                } else {
                    int val = Int32.Parse(item);
                    dq.right = new TreeNode(val);
                    q.Enqueue(dq.right);
                }
            } else {
                break;
            }            
        }

        return root;
    }

    private (string, int) GetNext(string s, int i) {
        for(int j = i; j < s.Length; j++) {
            if(s[j] == '*') {
                return ("*", j + 2);
            }

            if(s[j] == ',') {
                return (s.Substring(i, j - i), j + 1);
            }
        }

        return ("*", i);
    }
}
