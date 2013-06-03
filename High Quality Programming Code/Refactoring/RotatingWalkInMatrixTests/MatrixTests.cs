using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RotatingWalkInMatrix;
using System.Text;

namespace RotatingWalkInMatrixTests
{
    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateMatrixithNegativeLenhth()
        {
            Matrix matrix = new Matrix(-6);
        }

        [TestMethod]
        public void TestMatrixToString_MatrixSize1()
        {
            Matrix matrix = new Matrix(1);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("1 ");

            string actual = matrix.ToString();

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestMatrixToString_MatrixSize3()
        {
            Matrix matrix = new Matrix(3);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("1 7 8 ");
            expected.AppendLine("6 2 9 ");
            expected.AppendLine("5 4 3 ");

            string actual = matrix.ToString();

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestMatrixToString_MatrixSize4()
        {
            Matrix matrix = new Matrix(4);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("1 10 11 12 ");
            expected.AppendLine("9  2 15 13 ");
            expected.AppendLine("8 16  3 14 ");
            expected.AppendLine("7  6  5  4 ");

            string actual = matrix.ToString();

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestMatrixToString_MatrixSize6()
        {
            Matrix matrix = new Matrix(6);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine(" 1 16 17 18 19 20 ");
            expected.AppendLine("15  2 27 28 29 21 ");
            expected.AppendLine("14 31  3 26 30 22 ");
            expected.AppendLine("13 36 32  4 25 23 ");
            expected.AppendLine("12 35 34 33  5 24 ");
            expected.AppendLine("11 10  9  8  7  6 ");

            string actual = matrix.ToString();

            Assert.AreEqual(expected.ToString(), actual);
        }

        [TestMethod]
        public void TestMatrixToString_MatrixSize10()
        {
            Matrix matrix = new Matrix(10);

            StringBuilder expected = new StringBuilder();
            expected.AppendLine(" 1 28 29  30 31 32 33 34 35 36 ");
            expected.AppendLine("27  2 51  52 53 54 55 56 57 37 ");
            expected.AppendLine("26 73  3  50 66 67 68 69 58 38 ");
            expected.AppendLine("25 90 74   4 49 65 72 70 59 39 ");
            expected.AppendLine("24 89 91  75  5 48 64 71 60 40 ");
            expected.AppendLine("23 88 99  92 76  6 47 63 61 41 ");
            expected.AppendLine("22 87 98 100 93 77  7 46 62 42 ");
            expected.AppendLine("21 86 97  96 95 94 78  8 45 43 ");
            expected.AppendLine("20 85 84  83 82 81 80 79  9 44 ");
            expected.AppendLine("19 18 17  16 15 14 13 12 11 10 ");

            string actual = matrix.ToString();

            Assert.AreEqual(expected.ToString(), actual);
        }
    }
}
