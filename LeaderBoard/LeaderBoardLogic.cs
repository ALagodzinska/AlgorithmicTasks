namespace LeaderBoard
{
    public class LeaderBoardLogic
    {
        public int[]? GetValidInput()
        {            
            string? input = Console.ReadLine();
            int tryCount = 1;

            var arrayOfScores = ParseToValidFormat(input);

            while (arrayOfScores == null)
            {
                if (tryCount < 5)
                {
                    Console.WriteLine("Input has invalid format.");
                    Console.WriteLine("Try one more time: ");
                    input = Console.ReadLine();
                    arrayOfScores = ParseToValidFormat(input);
                    tryCount++;
                }
                else
                {
                    return null;
                }
            }

            return arrayOfScores;
        }

        public int[]? ParseToValidFormat(string? input)
        {
            if (input == null) { return null; }
            var stringWithoutSpaces = String.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
            var stringScoreArray = stringWithoutSpaces.Split(',').ToArray<string>();

            var intArray = new int[stringScoreArray.Length];

            for (int i = 0; i < stringScoreArray.Length; i++)
            {
                int number;

                bool isNumber = int.TryParse(stringScoreArray[i], out number);
                if (!isNumber)
                {
                    return null;
                }

                intArray[i] = number;
            }

            return intArray;
        }

        public int[] GetPlayersRanks(int[] leaderBoardScores, int[] playerScores)
        {
            var allScores = leaderBoardScores.Union(playerScores).ToArray();
            var orderedLeaderBoard = allScores.OrderByDescending(x => x).ToArray();

            var newPlayersRanks = new int[playerScores.Length];

            for (int i = 0; i < playerScores.Length; i++)
            {
                var rank = Array.IndexOf(orderedLeaderBoard, playerScores[i]) + 1;
                newPlayersRanks[i] = rank;
            }

            return newPlayersRanks;
        }
    }
}
