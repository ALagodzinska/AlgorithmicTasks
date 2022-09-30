namespace MakeAlike
{
    public class MakeAlikeLogic
    {
        public string GetValidInput()
        {
            Console.WriteLine("Please input one string of lowercase characters");
            string? input = Console.ReadLine();
            int tryCount = 1;

            while (!IsValidInput(input))
            {
                if (tryCount < 5)
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

            return input.ToLower();
        }

        public int GetValidIntInput()
        {
            string? input = Console.ReadLine();
            int tryCount = 1;
            int intCountOfOperations;

            var devisor = int.TryParse(input, out intCountOfOperations);

            while (devisor == false || intCountOfOperations <= 0)
            {
                if (tryCount < 5)
                {
                    Console.WriteLine("Count of Operations has invalid format.");
                    Console.WriteLine("Try one more time: ");
                    input = Console.ReadLine();
                    devisor = int.TryParse(input, out intCountOfOperations);
                    tryCount++;
                }
                else
                {
                    return 0;
                }
            }

            return intCountOfOperations;
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

        public string GetDesiredString(string initialString, string desiredString, int numberOfOperations)
        {
            //check how many letters mathes desired string , starting from 0
            //those letters will stay
            var shortestStringLength = Math.Min(initialString.Length, desiredString.Length);

            int countOfMatchingLetters = 0;
            for(int i = 0; i < shortestStringLength; i++)
            {
                if (initialString[i] == desiredString[i]) countOfMatchingLetters++;
                else break;
            }
            
            var operationCount = initialString.Length - countOfMatchingLetters;
            if(operationCount > numberOfOperations)
            {
                return "No";
            }
            //remove all unneeded letters
            initialString = initialString.Substring(0, countOfMatchingLetters);

            //compare initialStringCount to desired string count, add missing letters
            var countOfLettersToAddToInitialString = desiredString.Length - countOfMatchingLetters;
            if ((operationCount+countOfLettersToAddToInitialString) > numberOfOperations)
            {
                return "No";
            }

            //place one by one leftover letters
            var leftoverLetters = desiredString.Substring(countOfMatchingLetters);
            initialString = initialString + leftoverLetters;

            return "Yes";
        }
    }
}
