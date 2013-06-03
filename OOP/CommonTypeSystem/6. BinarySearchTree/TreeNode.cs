using System;
using System.Collections.Generic;

public class TreeNode<K> : IEnumerable<K> where K : IComparable
{

    public K Value { get; set; }
    public TreeNode<K> Left { get; set; }
    public TreeNode<K> Right { get; set; }

    public TreeNode()
    {
        this.Left = null;
        this.Right = null;
    }

    public IEnumerator<K> GetEnumerator()
    {
        if (Left != null)
        {
            yield return Left.Value;
        }
        if (Right != null)
        {
            yield return Right.Value;
        }
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
