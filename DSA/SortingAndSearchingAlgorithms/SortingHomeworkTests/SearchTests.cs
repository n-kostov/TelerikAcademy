namespace SortingHomeworkTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void LinearSearch_0Elements()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            Assert.AreEqual(false, collection.LinearSearch(2));
        }

        [TestMethod]
        public void LinearSearch_1Element_Match()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(2);
            Assert.AreEqual(true, collection.LinearSearch(2));
        }

        [TestMethod]
        public void LinearSearch_1Element_NoMatch()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(1);
            Assert.AreEqual(false, collection.LinearSearch(2));
        }

        [TestMethod]
        public void LinearSearch_5Elements_Match1()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(1));
        }

        [TestMethod]
        public void LinearSearch_5Elements_Match2()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(2));
        }

        [TestMethod]
        public void LinearSearch_5Elements_Match3()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(3));
        }

        [TestMethod]
        public void LinearSearch_5Elements_Match4()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(4));
        }

        [TestMethod]
        public void LinearSearch_5Elements_Match5()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(5));
        }

        [TestMethod]
        public void LinearSearch_4Elements_Match1()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(1));
        }

        [TestMethod]
        public void LinearSearch_4Elements_Match2()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(2));
        }

        [TestMethod]
        public void LinearSearch_4Elements_Match3()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(3));
        }

        [TestMethod]
        public void LinearSearch_4Elements_Match4()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.LinearSearch(4));
        }

        [TestMethod]
        public void LinearSearch_5Elements_NoMatch()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 2; i <= 10; i *= 2)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(false, collection.LinearSearch(5));
        }

        [TestMethod]
        public void LinearSearch_4Elements_NoMatch()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 2; i <= 4; i *= 2)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(false, collection.LinearSearch(9));
        }

        [TestMethod]
        public void LinearSearch_RandomElements()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(5);
            collection.Items.Add(9);
            collection.Items.Add(3032);
            collection.Items.Add(-324);
            collection.Items.Add(3254);
            collection.Items.Add(463);

            Assert.AreEqual(true, collection.LinearSearch(-324));
        }

        [TestMethod]
        public void BinarySearch_0Elements()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            Assert.AreEqual(false, collection.BinarySearch(2));
        }

        [TestMethod]
        public void BinarySearch_1Element_Match()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(2);
            Assert.AreEqual(true, collection.BinarySearch(2));
        }

        [TestMethod]
        public void BinarySearch_1Element_NoMatch()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            collection.Items.Add(1);
            Assert.AreEqual(false, collection.BinarySearch(2));
        }

        [TestMethod]
        public void BinarySearch_5Elements_Match1()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(1));
        }

        [TestMethod]
        public void BinarySearch_5Elements_Match2()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(2));
        }

        [TestMethod]
        public void BinarySearch_5Elements_Match3()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(3));
        }

        [TestMethod]
        public void BinarySearch_5Elements_Match4()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(4));
        }

        [TestMethod]
        public void BinarySearch_5Elements_Match5()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 5; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(5));
        }

        [TestMethod]
        public void BinarySearch_4Elements_Match1()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(1));
        }

        [TestMethod]
        public void BinarySearch_4Elements_Match2()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(2));
        }

        [TestMethod]
        public void BinarySearch_4Elements_Match3()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(3));
        }

        [TestMethod]
        public void BinarySearch_4Elements_Match4()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 1; i <= 4; i++)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(true, collection.BinarySearch(4));
        }

        [TestMethod]
        public void BinarySearch_5Elements_NoMatch()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 2; i <= 10; i *= 2)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(false, collection.BinarySearch(5));
        }

        [TestMethod]
        public void BinarySearch_4Elements_NoMatch()
        {
            SortableCollection<int> collection = new SortableCollection<int>();
            for (int i = 2; i <= 4; i *= 2)
            {
                collection.Items.Add(i);
            }

            Assert.AreEqual(false, collection.BinarySearch(9));
        }
    }
}
