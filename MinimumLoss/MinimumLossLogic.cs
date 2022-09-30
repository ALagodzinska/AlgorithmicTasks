using System.Collections.Immutable;

namespace MinimumLoss
{
    public class MinimumLossLogic
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

        public int GetMinimumLoss(int[] pricesEachYear)
        {
            //check that it doesnt contain only items in ascending order.
            var sortedArray = pricesEachYear;
            Array.Sort(sortedArray);
            if (sortedArray== pricesEachYear) return 0;

            var loss = pricesEachYear.Max() - pricesEachYear.Min();
            //find the minimum difference
            for(int i = 0; i < pricesEachYear.Length; i++)
            {
                if(i == pricesEachYear.Length - 1) continue;
                for(int j = i + 1; j < pricesEachYear.Length; j++)
                {
                    var countedLoss = pricesEachYear[i] - pricesEachYear[j];
                    if (countedLoss < loss && countedLoss > 0) loss = countedLoss;           
                }
            }

            return loss;
        }
    }
}
