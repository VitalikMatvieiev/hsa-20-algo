BinaryTree tree = new BinaryTree();
tree.root = new Node(10);
tree.root.left = new Node(8);
tree.root.left.left = new Node(7);
tree.root.left.left.left = new Node(6);
tree.root.left.left.left.left = new Node(5);

tree.root = tree.buildTree(tree.root);

List<int> inputArray = new List<int> { 4, 3, 12, 1, 5, 5, 3, 9 };
// Output array
List<int> outputArray = CountingSort.CountSort(inputArray);
for (int i = 0; i < inputArray.Count; i++)
    Console.Write(outputArray[i] + " ");
Console.WriteLine();

var x = 1;