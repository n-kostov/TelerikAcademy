using System;

namespace _11.LinkedList
{
    public class LinkedList<T>
    {
        private ListItem<T> firstItem;
        private ListItem<T> lastItem;
        private int count;

        public LinkedList()
        {
            this.firstItem = null;
            this.lastItem = null;
            this.count = 0;
        }

        public ListItem<T> First
        {
            get
            {
                return this.firstItem;
            }
        }

        public ListItem<T> Last
        {
            get
            {
                return this.lastItem;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void AddAfter(ListItem<T> node, T value)
        {
            this.ValidateNode(node);

            ListItem<T> newNode = new ListItem<T>(value, node.NextItem);
            if (node == this.lastItem)
            {
                this.lastItem = newNode;
            }

            node.NextItem = newNode;
            this.count++;
        }

        public void AddBefore(ListItem<T> node, T value)
        {
            this.ValidateNode(node);

            ListItem<T> newNode = new ListItem<T>(node.Value, node.NextItem);
            if (node == this.lastItem)
            {
                this.lastItem = newNode;
            }

            node.Value = value;
            node.NextItem = newNode;
            this.count++;
        }

        public void AddFirst(T value)
        {
            if (this.firstItem == null)
            {
                this.firstItem = new ListItem<T>(value, null);
                this.lastItem = this.firstItem;
                this.count++;
                return;
            }

            this.AddBefore(this.firstItem, value);
        }

        public void AddLast(T value)
        {
            this.AddAfter(this.lastItem, value);
        }

        public void RemoveFirst()
        {
            this.ValidateNode(this.firstItem);
            this.firstItem = this.firstItem.NextItem;
            this.count--;
        }

        public void RemoveLast()
        {
            this.Remove(this.lastItem);
        }

        public void Remove(ListItem<T> node)
        {
            this.ValidateNode(node);

            if (node == this.firstItem)
            {
                if (this.firstItem == this.lastItem)
                {
                    this.firstItem = null;
                    this.lastItem = null;
                    this.count--;
                }
                else
                {
                    this.RemoveFirst();
                }
            }
            else
            {
                ListItem<T> currentNode = this.firstItem;
                while (currentNode.NextItem != node)
                {
                    currentNode = currentNode.NextItem;
                }

                this.RemoveAfter(currentNode);
            }
        }

        private void RemoveAfter(ListItem<T> node)
        {
            this.ValidateNode(node);

            if (node.NextItem != null)
            {
                ListItem<T> currentNode = node.NextItem;
                node.NextItem = currentNode.NextItem;
                if (currentNode == this.lastItem)
                {
                    this.lastItem = node;
                }

                this.count--;
            }
        }

        private void ValidateNode(ListItem<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }
        }
    }
}
