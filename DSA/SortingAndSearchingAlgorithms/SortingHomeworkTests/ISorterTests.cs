namespace SortingHomeworkTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class ISorterTests
    {
        [TestMethod]
        public void SelectionSorter_0Elements()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Sort(sorter);
            Assert.AreEqual(0, collection.Items.Count);
        }

        [TestMethod]
        public void SelectionSorter_1Element()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(1);
            collection.Sort(sorter);
            Assert.AreEqual(1, collection.Items[0]);
        }

        [TestMethod]
        public void SelectionSorter_3Elements()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(3);
            collection.Items.Add(1);
            collection.Items.Add(2);
            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3 }, collection.Items.ToList());
        }

        [TestMethod]
        public void SelectionSorter_6Elements_ProgramExample()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(22);
            collection.Items.Add(11);
            collection.Items.Add(101);
            collection.Items.Add(33);
            collection.Items.Add(0);
            collection.Items.Add(101);
            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 0, 11, 22, 33, 101, 101 }, collection.Items.ToList());
        }

        [TestMethod]
        public void SelectionSorter_10DescendingSortedElements()
        {
            ISorter<int> sorter = new SelectionSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 9; i >= 0; i--)
            {
                collection.Items.Add(i);
            }

            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, collection.Items.ToList());
        }

        [TestMethod]
        public void Quicksorter_0Elements()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Sort(sorter);
            Assert.AreEqual(0, collection.Items.Count);
        }

        [TestMethod]
        public void Quicksorter_1Element()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(1);
            collection.Sort(sorter);
            Assert.AreEqual(1, collection.Items[0]);
        }

        [TestMethod]
        public void Quicksorter_3Elements()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(3);
            collection.Items.Add(1);
            collection.Items.Add(2);
            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3 }, collection.Items.ToList());
        }

        [TestMethod]
        public void Quicksorter_6Elements_ProgramExample()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(22);
            collection.Items.Add(11);
            collection.Items.Add(101);
            collection.Items.Add(33);
            collection.Items.Add(0);
            collection.Items.Add(101);
            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 0, 11, 22, 33, 101, 101 }, collection.Items.ToList());
        }

        [TestMethod]
        public void Quicksorter_10DescendingSortedElements()
        {
            ISorter<int> sorter = new Quicksorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 9; i >= 0; i--)
            {
                collection.Items.Add(i);
            }

            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, collection.Items.ToList());
        }

        [TestMethod]
        public void MergeSorter_0Elements()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Sort(sorter);
            Assert.AreEqual(0, collection.Items.Count);
        }

        [TestMethod]
        public void MergeSorter_1Element()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(1);
            collection.Sort(sorter);
            Assert.AreEqual(1, collection.Items[0]);
        }

        [TestMethod]
        public void MergeSorter_3Elements()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(3);
            collection.Items.Add(1);
            collection.Items.Add(2);
            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 1, 2, 3 }, collection.Items.ToList());
        }

        [TestMethod]
        public void MergeSorterr_6Elements_ProgramExample()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(22);
            collection.Items.Add(11);
            collection.Items.Add(101);
            collection.Items.Add(33);
            collection.Items.Add(0);
            collection.Items.Add(101);
            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 0, 11, 22, 33, 101, 101 }, collection.Items.ToList());
        }

        [TestMethod]
        public void MergeSorter_10DescendingSortedElements()
        {
            ISorter<int> sorter = new MergeSorter<int>();
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 9; i >= 0; i--)
            {
                collection.Items.Add(i);
            }

            collection.Sort(sorter);
            CollectionAssert.AreEqual(new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, collection.Items.ToList());
        }
    }
}
