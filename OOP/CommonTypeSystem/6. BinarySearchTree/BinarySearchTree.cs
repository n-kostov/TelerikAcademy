using System;
using System.Collections.Generic;
using System.Text;

public class BinarySearchTree<T> : ICloneable, IEnumerable<T> where T : IComparable
{
    TreeNode<T> root;

    public BinarySearchTree()
    {
        this.root = null;
    }

    public void Add(T value)
    {
        TreeNode<T> p = root;
        if (p == null)
        {
            TreeNode<T> q = new TreeNode<T>();
            q.Value = value;
            root = q;
            root.Left = null;
            root.Right = null;
            return;
        }
        while (p != null)
        {
            if (value.CompareTo(p.Value) < 0 && p.Left != null)
            {
                p = p.Left;
            }
            else if (value.CompareTo(p.Value) > 0 && p.Right != null)
            {
                p = p.Right;
            }
            else
            {
                break;
            }
        }

        if (value.CompareTo(p.Value) < 0)
        {
            TreeNode<T> q = new TreeNode<T>();
            q.Value = value;
            p.Left = q;
            p.Left.Left = null;
            p.Left.Right = null;
        }
        else
        {
            TreeNode<T> q = new TreeNode<T>();
            q.Value = value;
            p.Right = q;
            p.Right.Left = null;
            p.Right.Right = null;
        }
    }

    public bool Search(T value)
    {
        TreeNode<T> p = root;
        while (p != null)
        {
            if (value.CompareTo(p.Value) < 0)
            {
                p = p.Left;
            }
            else if (value.CompareTo(p.Value) > 0)
            {
                p = p.Right;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public void Print()
    {
        Print(root);
    }

    private void Print(TreeNode<T> r)
    {
        if (r == null)
        {
            return;
        }
        Print(r.Left);
        Console.WriteLine(r.Value);
        Print(r.Right);
    }

    private void DeleteNode(TreeNode<T> node, TreeNode<T> parent, T value)
    {
        if (node == null)
        {
            return;
        }
        else if (value.CompareTo(node.Value) < 0)
        {
            DeleteNode(node.Left, node, value);
        }
        else if (value.CompareTo(node.Value) > 0)
        {
            DeleteNode(node.Right, node, value);
        }
        else
        {
            if (node.Left == null)
            {
                if (parent.Left == node)
                {
                    parent.Left = node.Right;
                }
                else
                {
                    parent.Right = node.Right;
                }
                node = null;
            }
            else if (node.Right == null)
            {

                if (parent.Left == node)
                {
                    parent.Left = node.Left;
                }
                else
                {
                    parent.Right = node.Left;
                }
                node = null;
            }
            else
            {
                TreeNode<T> p = findMin(node.Right);
                node.Value = p.Value;
                DeleteNode(node.Right, node, p.Value);
            }
        }
    }

    private TreeNode<T> findMin(TreeNode<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    public void Delete(T value)
    {
        DeleteNode(root, null, value);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var item in this)
        {
            stringBuilder.Append(item + " ");
        }
        return stringBuilder.ToString();
    }

    public override bool Equals(object obj)
    {
        BinarySearchTree<T> tree = obj as BinarySearchTree<T>;
        if (tree == null)
        {
            return false;
        }

        IEnumerator<T> enumerator1 = this.GetEnumerator();
        IEnumerator<T> enumerator2 = tree.GetEnumerator();

        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            if (!Object.Equals(enumerator1.Current, enumerator2.Current))
            {
                return false;
            }
        }
        if (enumerator1.Current != null && enumerator2.Current != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static bool operator ==(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
    {
        return BinarySearchTree<T>.Equals(firstTree, secondTree);
    }

    public static bool operator !=(BinarySearchTree<T> firstTree, BinarySearchTree<T> secondTree)
    {
        return !BinarySearchTree<T>.Equals(firstTree, secondTree);
    }

    public object Clone()
    {
        BinarySearchTree<T> tree = new BinarySearchTree<T>();
        foreach (var item in this)
        {
            tree.Add(item);
        }
        return tree;
    }

    public IEnumerable<T> InOrder
    { get { return IterateInOrder(root); } }

    private IEnumerable<T> IterateInOrder(TreeNode<T> parent)
    {
        if (parent != null)
        {
            foreach (var item in IterateInOrder(parent.Left))
            {
                yield return item;
            }

            yield return parent.Value;

            foreach (var item in IterateInOrder(parent.Right))
            {
                yield return item;
            }
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrder.GetEnumerator();
    }

}
