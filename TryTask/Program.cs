
int m = Convert.ToInt32(firstMultipleInput[0]);

int n = Convert.ToInt32(firstMultipleInput[1]);

int r = Convert.ToInt32(firstMultipleInput[2]);

int[,] matrix = new int[m, n];

for (int i = 0; i < m; i++)
{
    
    = Console.ReadLine().TrimEnd().Split(' ').ToArray()
    .Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToArray();
}

Result.matrixRotation(matrix, r);

int[,] array = new int[matrix.Count, matrix[0].Count];

for(int i = 0; i < matrix.Count; i++)
{
    for(int j = 0; j < matrix[i].Count; j++)
    {
        array[i,j] = matrix[i][j];
    }
}

for (int i = 0; i < array.GetLength(0); i++)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        Console.Write(array[i,j] + " ");
    }
    Console.WriteLine();
}

class Result
{

    /*
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        var fullCircles = Math.Min(matrix[0].Count/2, matrix[1].Count/2);

        int rotationCount = 0;
        while (rotationCount < r)
        {
            matrix = RotateOnce(matrix, fullCircles);
            rotationCount++;
        }

        for (int i = 0; i < matrix[0].Count; i++)
        {
            for (int j = 0; j < matrix[1].Count; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static List<List<int>> RotateOnce(List<List<int>> matrix, int fullCircles)
    {
        var NEWmatrix = new List<List<int>>();

        for (int row = 0; row < matrix[0].Count; row++)
        {
            for (int column = 0; column < matrix[1].Count; column++)
            {
                for (int counOfCircles = 0; counOfCircles < fullCircles;
                 counOfCircles++)
                {
                    if (column == counOfCircles &&
                    row < matrix[0].Count - (counOfCircles + 1) &&
                    row >= counOfCircles)
                    {
                        NEWmatrix[row+1][column] = matrix[row][column];
                    }
                    else if (row == matrix[0].Count - (counOfCircles + 1) &&
                    column < matrix[1].Count - (counOfCircles + 1) &&
                    column >= counOfCircles)
                    {
                        NEWmatrix[row][column + 1] = matrix[row][column];
                    }
                    else if (column == matrix[1].Count - (counOfCircles + 1) &&
                     row > counOfCircles &&
                     row < matrix[0].Count - counOfCircles)
                    {
                        NEWmatrix[row-1][column] = matrix[row][column];
                    }
                    else if (row == counOfCircles &&
                    column > counOfCircles &&
                    column < matrix[1].Count - counOfCircles)
                    {
                        NEWmatrix[row][column - 1] = matrix[row][column];
                    }
                }
            }
        }

        ChangeZeroToValues(matrix, NEWmatrix);

        return NEWmatrix;
    }

    public static void ChangeZeroToValues(List<List<int>> matrix,
    List<List<int>> newMatrix)
    {
        var emptyValues = Math.Max(matrix[0].Count, matrix[1].Count) -
         Math.Min(matrix[0].Count, matrix[1].Count) + 1;

        for (int row = 0; row < matrix[0].Count; row++)
        {
            for (int column = 0; column < matrix[1].Count; column++)
            {
                if (newMatrix[row][column] == 0)
                {
                    newMatrix[row][column] = matrix[row][column];
                }
            }
        }
    }

}
