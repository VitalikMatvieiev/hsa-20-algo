
public class Node
{
    public int key;
	public int data;
	public Node left, right;

	public Node(int data)
	{
		this.data = data;
		left = right = null;
	}
}

public class BinaryTree
{
	public Node root;
    public BinaryTree() { root = null; }
    public BinaryTree(int value) { root = new Node(value); }
    
    public void Insert(int key) => root = InsertRec(root, key); 
    
    public Node InsertRec(Node root, int key)
    {
        if (root == null) {
            root = new Node(key);
            return root;
        }

        if (key < root.key)
            root.left = InsertRec(root.left, key);
        else if (key > root.key)
            root.right = InsertRec(root.right, key);
        
        return root;
    }

    public Node Search(Node root, int key)
    {
        if (root == null || root.key == key)
            return root;
        
        if (root.key < key)
            return Search(root.right, key);

        return Search(root.left, key);
    }

    public Node DeleteNode(Node root, int key) {
        if (root == null)
            return root;
        
        if (key < root.key)
            root.left = DeleteNode(root.left, key);
        else if (key > root.key)
            root.right = DeleteNode(root.right, key);
        else {
            if (root.left == null)
                return root.right;
            else if (root.right == null)
                return root.left;
            
            root.key = MinValue(root.right);
            
            root.right = DeleteNode(root.right, root.key);
        }
        return root;
    }
    
    public int MinValue(Node root) {
        int minv = root.key;
        while (root.left != null) {
            minv = root.left.key;
            root = root.left;
        }
        return minv;
    }

    #region Noramlization
    public virtual void storeBSTNodes(Node root, List<Node> nodes)
    	{
    		if (root == null)
    		{
    			return;
    		}
    
    		storeBSTNodes(root.left, nodes);
    		nodes.Add(root);
    		storeBSTNodes(root.right, nodes);
    	}
    
        //Normalization
    	public virtual Node buildTreeUtil(List<Node> nodes, int start, int end)
    	{
    		if (start > end)
    		{
    			return null;
    		}
            
    		int mid = (start + end) / 2;
    		Node node = nodes[mid];
            
    		node.left = buildTreeUtil(nodes, start, mid - 1);
    		node.right = buildTreeUtil(nodes, mid + 1, end);
    
    		return node;
    	}
        
    	public virtual Node buildTree(Node root)
    	{
    		List<Node> nodes = new List<Node>();
    		storeBSTNodes(root, nodes);
            
    		int n = nodes.Count;
    		return buildTreeUtil(nodes, 0, n - 1);
    	}
    #endregion
}
