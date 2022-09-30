namespace DivisibleSums
{
    public class DivisibleSumsLogic
    {
        public void Run(int divisor, int[] array)
        {
            var countArray = GetArrayOfDevisionEvenlyCount(array, divisor);

            var listOfValues = array.ToList();

            while (!DoesAllValuesInArrayAreZero(countArray))
            {
                var listOfNew = GetUpdatedList(countArray, listOfValues);
                countArray = GetArrayOfDevisionEvenlyCount(listOfNew.ToArray(), 4);
            }

            Console.WriteLine(listOfValues.Count);
        }

        public int? GetValidIntInput()
        {
            string? input = Console.ReadLine();
            int tryCount = 1;
            int intDevisor;

            var devisor = int.TryParse(input, out intDevisor);

            while (devisor == false || intDevisor <= 0)
            {
                if (tryCount < 5)
                {
                    Console.WriteLine("Devisor has invalid format.");
                    Console.WriteLine("Try one more time: ");
                    input = Console.ReadLine();
                    devisor = int.TryParse(input, out intDevisor);
                    tryCount++;
                }
                else
                {
                    return null;
                }
            }

            return intDevisor;
        }

        public int[]? GetValidArrayInput()
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

        /// <summary>
        /// Return an array the same length as array with values. For each value in array counts it appearence in the int pair which sum is devisible evenly on devisor.
        /// </summary>
        /// <param name="intArray"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public int[] GetArrayOfDevisionEvenlyCount(int[] intArray, int divisor)
        {
            //array for devisiblity count
            var countsOfBeingInDevidablePair = new int[intArray.Length];

            //fill array with values
            for (int i = 0; i < intArray.Length; i++)
            {
                for (int j = i+1; j < intArray.Length; j++)
                {
                    //check if sum devides evenly
                    var isDevidedEvenly = (intArray[i] + intArray[j]) % divisor == 0;
                    //if it is devided evenly increase count by one
                    //to check how frequently such value appears in evenly devided sum of pair
                    if (isDevidedEvenly)
                    {
                        countsOfBeingInDevidablePair[i] += 1;
                        countsOfBeingInDevidablePair[j] += 1;
                    }
                }
            }

            return countsOfBeingInDevidablePair;
        }

        /// <summary>
        /// Returns list with removed values that has the largest count of apperances in the sum pairs that are devidable.
        /// </summary>
        /// <param name="arrayOfCounts"></param>
        /// <param name="listOfValues"></param>
        /// <returns></returns>
        public List<int> GetUpdatedList(int[] arrayOfCounts, List<int> listOfValues)
        {
            if(arrayOfCounts.Length != listOfValues.Count)
            {
                throw new Exception("Length of array and list doesnt match!");
            }

            var indexOfValueToRemove = Array.IndexOf(arrayOfCounts, arrayOfCounts.Max());
            listOfValues.RemoveAt(indexOfValueToRemove);

            return listOfValues;
        }

        /// <summary>
        /// Check if alll values are zero.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public bool DoesAllValuesInArrayAreZero(int[] array)
        {
            foreach(var item in array)
            {
                if(item != 0)
                {
                    return false;
                }
            }
            
            return true;
        }

    }

}
