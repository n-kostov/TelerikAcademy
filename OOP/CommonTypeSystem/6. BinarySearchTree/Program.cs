using System;

//  6.* Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". It is not necessary to keep the tree balanced. Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode() and the operators for comparison  == and !=. Add and implement the ICloneable interface for deep copy of the tree. Remark: Use two types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements). Implement IEnumerable<T> to traverse the tree.

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

        tree.Add(4);
        tree.Add(3);
        tree.Add(1);
        tree.Add(100);
        tree.Add(5);

        BinarySearchTree<int> newTree = (BinarySearchTree<int>)tree.Clone();

        tree.Delete(4);

        Console.WriteLine(tree);
        Console.WriteLine(newTree);

        Console.WriteLine(tree.Search(100));

        Console.WriteLine(tree.Equals(newTree));
    }
}
