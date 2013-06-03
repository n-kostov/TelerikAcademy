using System;

namespace _8_10_Matrix
{
    public class Matrix<T> where T :
           struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private readonly T[,] matrix;
        private readonly int defaultSize = 8;
        private int row;
        private int col;

        public Matrix()
        {
            matrix = new T[defaultSize, defaultSize];
            Row = defaultSize;
            Col = defaultSize;
        }

        public Matrix(int rowCapacity, int colCapacity)
        {
            matrix = new T[rowCapacity, colCapacity];
            Row = rowCapacity;
            Col = colCapacity;
        }

        public int Col
        {
            get
            {
                return this.col;
            }
            private set
            {
                this.col = value;
            }
        }

        public int Row
        {
            get
            {
                return this.row;
            }
            private set
            {
                this.row = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (Row < row + 1 || Col < col + 1 || row < 0 || col < 0)
                {
                    throw new ArgumentOutOfRangeException("Index out of range for Row or Col");
                }
                else
                {
                    return matrix[row, col];
                }
            }
            set
            {
                if (Row < row + 1 || Col < col + 1 || row < 0 || col < 0)
                {
                    throw new ArgumentOutOfRangeException("Index out of range for Row or Col");
                }
                else
                {
                    matrix[row, col] = value;
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Col != secondMatrix.Col || firstMatrix.Row != secondMatrix.Row)
            {
                throw new ArgumentException("The two matrices must have equal sizes");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Row, firstMatrix.Col);
                for (int i = 0; i < firstMatrix.Row; i++)
                {
                    for (int j = 0; j < firstMatrix.Col; j++)
                    {
                        resultMatrix[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
                    }
                }
                return resultMatrix;
            }
        }

        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Col != secondMatrix.Col || firstMatrix.Row != secondMatrix.Row)
            {
                throw new ArgumentException("The two matrices must have equal sizes");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(firstMatrix.Row, firstMatrix.Col);
                for (int i = 0; i < firstMatrix.Row; i++)
                {
                    for (int j = 0; j < firstMatrix.Col; j++)
                    {
                        resultMatrix[i, j] = (dynamic)firstMatrix[i, j] - secondMatrix[i, j];
                    }
                }
                return resultMatrix;
            }
        }

        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Col != secondMatrix.Row)
            {
                throw new ArgumentException("The first matrix must have equal number of columns as the rows in the second matrix");
            }
            else
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.Row, secondMatrix.Col);
                for (int i = 0; i < firstMatrix.Row; i++)
                {
                    for (int j = 0; j < secondMatrix.Col; j++)
                    {
                        dynamic sum = 0;
                        for (int k = 0; k < firstMatrix.Col; k++)
                        {
                            sum += (dynamic)firstMatrix[i, k] * secondMatrix[k, j];
                        }
                        result[i,j] = sum;
                    }
                }
                return result;
            }
        }

        public static bool operator true(Matrix<T> matrix)
        {
            if (matrix.Row > 0 && matrix.Col > 0)
            {
                for (int i = 0; i < matrix.Row; i++)
                {
                    for (int j = 0; j < matrix.Col; j++)
                    {
                        if (matrix[i,j].CompareTo(0) == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            } 
            else
            {
                return false;
            }
        }

        public static bool operator false(Matrix<T> matrix)
        {
            if (matrix.Row > 0 && matrix.Col > 0)
            {
                for (int i = 0; i < matrix.Row; i++)
                {
                    for (int j = 0; j < matrix.Col; j++)
                    {
                        if (matrix[i, j].CompareTo(0) == 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
