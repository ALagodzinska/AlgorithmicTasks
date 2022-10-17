using System.Reflection.Emit;

namespace Rotations
{
    public class RotationsLogic
    {
        public void Rotate()
        {
            const int rows = 4;
            const int columns = 4;
            var rotations = 2;
            //var matrix = new int[rows, columns] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            var matrix = new int[5, 7] { { 1, 2, 3, 4, 5, 6, 7 }, { 8, 9, 10, 11, 12, 13, 14 }, { 15, 16, 17, 18, 19, 20, 21 }, { 22, 23, 24, 25, 26, 27, 28 }, { 29, 30, 31, 32, 33, 34, 35 } };

            var fullCircles = Math.Min(rows/2, columns/2);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine();

            int rotationCount = 0;
            while (rotationCount < rotations)
            {
                matrix = RotateOnce(matrix, fullCircles);
                rotationCount++;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine();
            }
            
            //if both are not even
            //if(rows%2 != 0 && columns%2 != 0)        

            
        }

        public int[,] RotateOnce(int[,] matrix, int fullCircles)
        {
            var NEWmatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    for (int counOfCircles = 0; counOfCircles < fullCircles; counOfCircles++)
                    {
                        if (column == counOfCircles && row < matrix.GetLength(0) - (counOfCircles + 1) && row >= counOfCircles)
                        {
                            NEWmatrix[row+1, column] = matrix[row, column];
                        }
                        else if (row == matrix.GetLength(0) - (counOfCircles + 1) && column < matrix.GetLength(1) - (counOfCircles + 1) && column >= counOfCircles)
                        {
                            NEWmatrix[row, column + 1] = matrix[row, column];
                        }
                        else if (column == matrix.GetLength(1) - (counOfCircles + 1) && row > counOfCircles && row < matrix.GetLength(0) - counOfCircles)
                        {
                            NEWmatrix[row-1, column] = matrix[row, column];
                        }
                        else if (row == counOfCircles && column > counOfCircles && column < matrix.GetLength(1) - counOfCircles)
                        {
                            NEWmatrix[row, column - 1] = matrix[row, column];
                        }
                    }
                }
            }

            ChangeZeroToValues(matrix, NEWmatrix);

            return NEWmatrix;
        }

        public void ChangeZeroToValues(int[,] matrix, int[,] newMatrix)
        {
            var emptyValues = Math.Max(matrix.GetLength(0), matrix.GetLength(1)) - Math.Min(matrix.GetLength(0), matrix.GetLength(1)) + 1;


            Console.WriteLine("_______");
            Console.WriteLine(emptyValues);
            Console.WriteLine("_______");


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (newMatrix[row, column] == 0)
                    {
                        if (emptyValues == 1)
                        {
                            newMatrix[row, column] = matrix[row, column];
                        }
                        if (matrix.GetLength(0) > matrix.GetLength(1))
                        {
                            //newMatrix[row, column] = matrix[matrix.GetLength(0) - row, column];
                        }
                        if (matrix.GetLength(1) > matrix.GetLength(0))
                        {
                            //newMatrix[row, column] = matrix[row, column - emptyValues + 1];
                        }

                    }
                }
            }
        }
    }
}
