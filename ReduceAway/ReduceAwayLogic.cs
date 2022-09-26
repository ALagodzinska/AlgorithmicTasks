namespace ReduceAway
{
    public class ReduceAwayLogic
    {
        public string SuperReducedString(string stringToReduce)
        {
            while (stringToReduce.Length > ReduceString(stringToReduce).Length)
            {
                stringToReduce = ReduceString(stringToReduce);
            }

            return stringToReduce;
        }

        public string? GetValidInput()
        {
            Console.WriteLine("Please input one string of lowercase characters");
            string? input = Console.ReadLine();
            int tryCount = 1;

            while (!IsValidInput(input))
            {
                if(tryCount < 5)
                {
                    Console.WriteLine("String has invalid format.");
                    Console.WriteLine("Try one more time: ");
                    input = Console.ReadLine();
                    tryCount++;
                }
                else
                {
                    return "";
                }                
            }

            return input?.ToLower();
        }

        public bool IsValidInput(string? input)
        {
            if (input == null ||
                input.Any(Char.IsWhiteSpace) ||
                input.Any(char.IsDigit) ||
                input.Length < 1 || input.Length > 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string ReduceString(string stringToReduce)
        {
            string reducedString = "";

            if (stringToReduce.Length == 1 || stringToReduce.Length == 0)
            {
                return stringToReduce;
            }

            for (int i = 0; i <= stringToReduce.Length; i++)
            {
                if (i + 1 <= stringToReduce.Length)
                {
                    if (i - 1 < 0)
                    {
                        if (stringToReduce[i] != stringToReduce[i+1])
                        {
                            reducedString += stringToReduce[i];
                        }
                    }
                    else if (i + 1 == stringToReduce.Length)
                    {
                        if (stringToReduce[i] != stringToReduce[i-1])
                        {
                            reducedString += stringToReduce[i];
                        }
                    }
                    else if (stringToReduce[i] != stringToReduce[i+1] &&
                        stringToReduce[i] != stringToReduce[i-1])
                    {
                        reducedString += stringToReduce[i];
                    }
                }
            }

            return reducedString;
        }
    }
}
