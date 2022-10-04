namespace QueensAttack
{
    public class QueensAttackLogic
    {
        private static string readFileName = "input.txt";

        public readonly string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, readFileName));

        private int NumberOfRowsAndColumns;
        private int NumberOfObstacles;
        private int QueenPositionRow;
        private int QueenPositionColumn;
        private List<int[]> obstacles = new List<int[]>();

        public void GetDataFromFile()
        {
            if (!File.Exists(filePath))
            {
                var fileData = "5 3\n4 3\n5 5\n4 2\n2 3";
                File.WriteAllText(filePath, fileData);
            }

            var data = File.ReadAllLines(filePath);
            var intList = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                var line = data[i].Split(' ')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToArray();
                if(i == 0)
                {
                    NumberOfRowsAndColumns = Int32.Parse(line[0]);
                    NumberOfObstacles = Int32.Parse(line[1]);
                }
                else if(i == 1)
                {
                    QueenPositionRow = Int32.Parse(line[0]);
                    QueenPositionColumn = Int32.Parse(line[1]);
                }
                else
                {
                    obstacles.Add(new int[] { Int32.Parse(line[0]), Int32.Parse(line[1]) });
                }
            }
        }

        public int SquaresToAttack()
        {
            GetDataFromFile();

            int countOfMoves = 0;

            //for all
            //for(int r = 1; r <= NumberOfRowsAndColumns; r++)
            //{
            //    if (row <= 0 || row > NumberOfRowsAndColumns || 
            //        column <= 0 || column > NumberOfRowsAndColumns ||
            //        DoesHaveObstacle(new int[] { row, column }, obstacles)) break;
            //}

            //find all in column
            //all in row
            for (int r = 1; r <= NumberOfRowsAndColumns; r++)
            {
                var rowGoingDown = QueenPositionRow - r;
                if (rowGoingDown <= 0 || DoesHaveObstacle(new int[] { rowGoingDown, QueenPositionColumn }, obstacles)) break;
                countOfMoves += 1;
            }

            for (int r = 1; r <= NumberOfRowsAndColumns; r++)
            {
                var rowGoingUp = QueenPositionRow + r;
                if (rowGoingUp > NumberOfRowsAndColumns || DoesHaveObstacle(new int[] { rowGoingUp, QueenPositionColumn }, obstacles)) break;
                countOfMoves += 1;
            }

            //find all in column
            for (int c = 1; c <= NumberOfRowsAndColumns; c++)
            {
                var columnRight = QueenPositionColumn + c;
                if (columnRight > NumberOfRowsAndColumns || DoesHaveObstacle(new int[] { QueenPositionRow, columnRight }, obstacles)) break;
                countOfMoves += 1;
            }

            for (int c = 1; c <= NumberOfRowsAndColumns; c++)
            {
                var columnLeft = QueenPositionColumn - c;
                if (columnLeft <= 0 || DoesHaveObstacle(new int[] { QueenPositionRow, columnLeft }, obstacles)) break;
                countOfMoves += 1;
            }

            //find one diagonal up
            for (int i = 1; i <= NumberOfRowsAndColumns; i++)
            {
                var rowPosition = QueenPositionRow + i;
                var columnPosition = QueenPositionColumn + i;

                if (rowPosition > NumberOfRowsAndColumns ||
                    columnPosition > NumberOfRowsAndColumns ||
                    DoesHaveObstacle(new int[] { rowPosition, columnPosition }, obstacles)) break;
                countOfMoves += 1;
            }

            //find one diagonal down
            for (int i = 1; i <= NumberOfRowsAndColumns; i++)
            {
                var rowPosition = QueenPositionRow - i;
                var columnPosition = QueenPositionColumn - i;

                if (rowPosition <= 0 || columnPosition <= 0 ||
                    DoesHaveObstacle(new int[] { rowPosition, columnPosition }, obstacles)) break;
                countOfMoves += 1;
            }

            //find other diagonal up
            for (int i = 1; i <= NumberOfRowsAndColumns; i++)
            {
                var rowPosition = QueenPositionRow + i;
                var columnPosition = QueenPositionColumn - i;

                if (rowPosition > NumberOfRowsAndColumns || columnPosition <= 0 ||
                    DoesHaveObstacle(new int[] { rowPosition, columnPosition }, obstacles)) break;
                countOfMoves += 1;
            }

            //find other diagonal down
            for (int i = 1; i <= NumberOfRowsAndColumns; i++)
            {
                var rowPosition = QueenPositionRow - i;
                var columnPosition = QueenPositionColumn + i;

                if (rowPosition <= 0 || columnPosition > NumberOfRowsAndColumns ||
                    DoesHaveObstacle(new int[] { rowPosition, columnPosition }, obstacles)) break;
                countOfMoves += 1;
            }

            return countOfMoves;
        }

        public bool DoesHaveObstacle(int[] place, List<int[]> obstacles)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle[0] == place[0] && obstacle[1] == place[1])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
