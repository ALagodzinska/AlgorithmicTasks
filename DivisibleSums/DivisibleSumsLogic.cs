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

            var indexOfValueToRemove = Array.IndexOf(arrayOfCounts, arrayOfCounts.Max());
            listOfValues.RemoveAll(x => x == listOfValues[indexOfValueToRemove]);

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
