using System.Globalization;

namespace FraudProtection
{
    public class FraudProtectionLogic
    {
        private static string readFileName = "input.txt";

        public readonly string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, readFileName));

        int numberOfDays;
        int lookback;
        int[] array;

        public void GetDataFromFile()
        {
            if (!File.Exists(filePath))
            {
                var fileData = "9 5\n2 3 4 2 3 6 8 4 5";
                File.WriteAllText(filePath, fileData);
            }

            var data = File.ReadAllLines(filePath);
            var intList = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                var numbers = data[i].Split(' ')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToArray();
                if (i == 0)
                {
                    numberOfDays = Int32.Parse(numbers[0]);
                    lookback = Int32.Parse(numbers[1]);
                }
                else
                {
                    array = new int[numbers.Length];
                    for(int j = 0; j < numbers.Length; j++)
                    {
                        array[j] = Int32.Parse(numbers[j]);
                    }                    
                }
            }
        }

        public int GetNotificationCount()
        {
            GetDataFromFile();

            int notifications = 0;
            //loop through all previous three numbers
            for(int i = lookback; i < numberOfDays; i++)
            {
                var lookBackList = new List<int>();
                for(int j = i-lookback; j < i; j++)
                {
                    lookBackList.Add(array[j]);
                }
                var mediana = GetMediana(lookBackList.ToArray());
                if (array[i] >= 2*mediana)
                {
                    notifications += 1;
                }
            }

            return notifications;
        }

        public int GetMediana(int[] arrayOfValues)
        {
            int mediana;
            Array.Sort(arrayOfValues);
            if(arrayOfValues.Length % 2 == 0)
            {
                var intOfTwoInTheMiddle = new int[] { arrayOfValues[arrayOfValues.Length / 2 - 1], arrayOfValues[arrayOfValues.Length / 2] };
                mediana = intOfTwoInTheMiddle.Sum()/2;
            }
            else
            {
                mediana = arrayOfValues[arrayOfValues.Length / 2];
            }

            return mediana;
        }
    }
}
