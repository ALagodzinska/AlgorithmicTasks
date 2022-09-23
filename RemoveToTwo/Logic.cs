namespace RemoveToTwo
{
    public class Logic
    {
        public string GetValidInput()
        {
            Console.WriteLine("Please input one string of lowercase characters");
            string? input = Console.ReadLine();
            while (input == null ||
                input.Any(Char.IsWhiteSpace) ||
                input.Any(char.IsDigit) ||
                input.Length < 1 && input.Length > 100)
            {
                Console.WriteLine("String has invalid format.");
                Console.WriteLine("Try one more time: ");
                input = Console.ReadLine();
            }

            return input.ToLower();
        }

        public int LongestPossibleStringCount(string inputString)
        {
            //find all unique letters
            var uniqueLetters = new string(inputString.Distinct().ToArray());

            var possiblePairs = GetAllPossiblePairs(uniqueLetters);

            var stringsWithSequence = GetListOfStringsWithSequence(inputString, uniqueLetters, possiblePairs);

            if (stringsWithSequence.Count == 0)
            {
                return 0;
            }

            var stringsOrderedByLettersCount = stringsWithSequence.OrderByDescending(s => s.Length);

            return stringsOrderedByLettersCount.First().Length;

        }

        private List<string> GetAllPossiblePairs(string uniqueLetters)
        {
            var possiblePairs = new List<string>();
            //make all possible pairs
            for (int i = 0; i < uniqueLetters.Length; i++)
            {
                for (int j = i + 1; j < uniqueLetters.Length; j++)
                {
                    var pair = "";
                    pair = pair + uniqueLetters[i] + uniqueLetters[j];

                    if (possiblePairs.Contains(pair) || possiblePairs.Contains(pair.Reverse())) break; ;

                    possiblePairs.Add(pair);
                }
            }
            return possiblePairs;
        }

        private string GetStringOfTwoLetters(string input, string uniqueLetters, string pair)
        {
            var stringOfTwoLetters = input;

            foreach (var letter in uniqueLetters)
            {
                if (letter != pair[0] && letter != pair[1])
                {
                    stringOfTwoLetters = stringOfTwoLetters.Replace(letter.ToString(), String.Empty);
                }
            }

            return stringOfTwoLetters;
        }

        private bool DoesLettersHasSequence(string stringOfTwoLetters)
        {
            bool hasSequence = true;

            for (int i = 0; i < stringOfTwoLetters.Length; i++)
            {
                if (i + 1 == stringOfTwoLetters.Length) continue;

                if (stringOfTwoLetters[i] == stringOfTwoLetters[i + 1])
                {
                    hasSequence = false;
                    break;
                }
            }

            return hasSequence;
        }

        private List<string> GetListOfStringsWithSequence(string inputString, string uniqueLetters, List<string> possiblePairs)
        {
            var stringsWithSecuence = new List<string>();

            foreach (var pair in possiblePairs)
            {
                var stringOfTwoLetters = GetStringOfTwoLetters(inputString, uniqueLetters, pair);

                var hasSequence = DoesLettersHasSequence(stringOfTwoLetters);

                if (hasSequence)
                {
                    stringsWithSecuence.Add(stringOfTwoLetters);
                }
            }

            return stringsWithSecuence;
        }
    }
}
