using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

//Console.ReadLine();
/*BinaryTree tree = new BinaryTree();
tree.root = new Node(10);
tree.root.left = new Node(8);
tree.root.left.left = new Node(7);
tree.root.left.left.left = new Node(6);
tree.root.left.left.left.left = new Node(5);

tree.root = tree.buildTree(tree.root);

for (int i = 0; i < 50000; i++)
{
    tree.Insert(i);
}



List<int> inputArray = new List<int> { 4, 3, 12, 1, 5, 5, 3, 9 };*/
// Output array
//List<int> outputArray = CountingSort.CountSort(inputArray);
//for (int i = 0; i < inputArray.Count; i++)
//    Console.Write(outputArray[i] + " ");
var summary = BenchmarkRunner.Run<MyBenchmarkDemo>();

Console.WriteLine("Done");

//var x = 1;

/*[MemoryDiagnoser]*/
public class MyBenchmarkDemo
{
    protected BinaryTree tree = new();
    [GlobalSetup]
    public void GlobalSetup()
    {
        tree.root = new Node(10);

        tree.root = tree.buildTree(tree.root);
        for (int i = 0; i < 1000; i++)
        {
            tree.Insert(i);
        }
    }

    /*[Benchmark]
    public void Insert()
    {
        for (int i = 0; i < 1000; i++)
        {
            tree.Insert(i);
        }
    }*/
    [Benchmark]
    public void Search()
    {
        for (int i = 0; i < 1000; i++)
        {
            tree.Search(tree.root,i);
        }
    }
    [Benchmark]
    public void Delete()
    {
        for (int i = 0; i < 100; i++)
        {
            tree.DeleteNode(tree.root, i);
        }
    }
}
