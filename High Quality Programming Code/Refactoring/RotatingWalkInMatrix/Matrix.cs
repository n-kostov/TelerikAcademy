namespace RotatingWalkInMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private readonly int[] directionX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private readonly int[] directionY = { 1, 0, -1, -1, -1, 0, 1, 1 };
        private int[,] body;
        private int size;
        private int valueIncrementer;

        public Matrix(int size)
        {
            if (size < 1)
            {
                throw new ArgumentOutOfRangeException("size", "The matrix cannot have size less than 1!");
            }

            this.body = new int[size, size];
            this.size = size;
            int row = 0, col = 0;
            this.valueIncrementer = 1;

            this.FillMatrix(ref row, ref col);

            // quick fix for performance - if this.body is with size 4 or below, it doesn't need to be traversed second time.
            if (size > 4)
            {
                this.FindFirstFreeCell(out row, out col);
                this.valueIncrementer++;
                this.FillMatrix(ref row, ref col);
            }
        }

        public override string ToString()
        {
            return this.PrintMatrix();
        }

        private void FillMatrix(ref int row, ref int col)
        {
            int currentDirectionX = 1;
            int currentDirectionY = 1;

            while (true)
            {
                this.body[row, col] = this.valueIncrementer;

                if (!this.HasFreeNeighbor(row, col))
                {
                    return;
                }

                while (this.IsOutOfMatrixBounds(row, col, currentDirectionX, currentDirectionY) ||
                       (this.body[row + currentDirectionX, col + currentDirectionY] != 0))
                {
                    this.ChangeCurrentDirection(ref currentDirectionX, ref currentDirectionY);
                }

                row += currentDirectionX;
                col += currentDirectionY;
                this.valueIncrementer++;
            }
        }

        private bool HasFreeNeighbor(int row, int col)
        {
            int[] collisionDetectionX = (int[])this.directionX.Clone();
            int[] collisionDetectionY = (int[])this.directionY.Clone();

            for (int i = 0; i < collisionDetectionX.Length; i++)
            {
                if ((row + collisionDetectionX[i] >= this.body.GetLength(0)) ||
                    (row + collisionDetectionX[i] < 0))
                {
                    collisionDetectionX[i] = 0;
                }

                if ((col + collisionDetectionY[i] >= this.body.GetLength(0)) ||
                    (col + collisionDetectionY[i] < 0))
                {
                    collisionDetectionY[i] = 0;
                }
            }

            for (int i = 0; i < collisionDetectionX.Length; i++)
            {
                if (this.body[(row + collisionDetectionX[i]),
                    (col + collisionDetectionY[i])] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindFirstFreeCell(out int emptyCellAtXPos, out int emptyCellAtYPos)
        {
            emptyCellAtXPos = 0;
            emptyCellAtYPos = 0;

            for (int row = 0; row < this.body.GetLength(0); row++)
            {
                for (int col = 0; col < this.body.GetLength(1); col++)
                {
                    if (this.body[row, col] == 0)
                    {
                        emptyCellAtXPos = row;
                        emptyCellAtYPos = col;
                        return;
                    }
                }
            }
        }

        private bool IsOutOfMatrixBounds(int row, int col, int currentDirectionX, int currentDirectionY)
        {
            bool rowOutsideMatrix = row + currentDirectionX >= this.size || row + currentDirectionX < 0;
            bool colOutsideMatrix = col + currentDirectionY >= this.size || col + currentDirectionY < 0;

            return rowOutsideMatrix || colOutsideMatrix;
        }

        private void ChangeCurrentDirection(ref int currentDirectionX, ref int currentDirectionY)
        {
            int currentDirection = 0;
            for (int count = 0; count < this.directionX.Length; count++)
            {
                if (this.directionX[count] == currentDirectionX &&
                    this.directionY[count] == currentDirectionY)
                {
                    currentDirection = count;
                    break;
                }
            }

            // go to the next possible direction
            if (currentDirection == this.directionX.Length - 1)
            {
                currentDirectionX = this.directionX[(currentDirection + 1) % this.directionX.Length];
                currentDirectionY = this.directionY[(currentDirection + 1) % this.directionX.Length];
            }
            else
            {
                currentDirectionX = this.directionX[currentDirection + 1];
                currentDirectionY = this.directionY[currentDirection + 1];
            }
        }

        private string PrintMatrix()
        {
            char paddingSymbol = ' ';
            int[] columnLargestNumbers = this.GetLargestNumbersInEachColumn();
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.size; row++)
            {
                for (int col = 0; col < this.size; col++)
                {
                    int paddingLength = columnLargestNumbers[col].ToString().Length;
                    string cellString = string.Format("{0}", this.body[row, col]).PadLeft(
                        paddingLength,
                        paddingSymbol);

                    result.Append(cellString + ' ');
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        private int[] GetLargestNumbersInEachColumn()
        {
            int[] result = new int[this.size];

            for (int col = 0; col < this.size; col++)
            {
                int max = this.body[0, col];
                for (int row = 0; row < this.size; row++)
                {
                    if (this.body[row, col] > max)
                    {
                        max = this.body[row, col];
                    }
                }

                result[col] = max;
            }

            return result;
        }
    }
}
