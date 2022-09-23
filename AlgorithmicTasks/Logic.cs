namespace MakeMeRoundly
{
    public class Logic
    {
        public void Run ()
        {
            var gradesFromFile = GetGradesFromFile();

            if (gradesFromFile.Length < 0 || gradesFromFile.Length > 60)
            {
                Console.WriteLine("Grade count in invalid!");
                return;
            }

            var roundedGrades = RoundGrades(gradesFromFile);

            WriteGradesToFile(roundedGrades);

            PrintGrades(roundedGrades);
        }

        public void PrintGrades(int[] roundedGrades)
        {
            Console.WriteLine();
            Console.WriteLine($"Rounded Grades: ");

            foreach (var grade in roundedGrades)
            {
                Console.Write($"{grade}, ");
            }
        }

        public int[] GetGradesFromFile()
        {
            var path = @"C:\Users\a.lagodzinska\source\repos\AlgorithmicTasks\input.txt";
            var grades = File.ReadAllText(path);
            string[] gradeArrayStrings = grades.Split(',')
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToArray();
            int[] gradeArrayInt = new int[gradeArrayStrings.Length];

            for (int i = 0; i < gradeArrayStrings.Length; i++)
            {
                try
                {
                    gradeArrayInt[i] = int.Parse(gradeArrayStrings[i]);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Grade is not in correct format. Exception message: {exception.Message}");
                }
            }

            return gradeArrayInt;
        }

        public int[] RoundGrades(int[] grades)
        {
            int[] gradesAfterRounding = new int[grades.Length];

            for (int i = 0; i < grades.Length; i++)
            {
                gradesAfterRounding[i] = RoundGrade(grades[i]);
            }

            return gradesAfterRounding;
        }

        private int RoundGrade(int grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new Exception("Grade does not fit in a range.");
            }

            if (grade < 40)
            {
                return grade;
            }

            var nextMultiple = ((grade/5) + 1) * 5;
            var difference = nextMultiple - grade;

            if (difference < 3)
            {
                return nextMultiple;
            }
            else
            {
                return grade;
            }
        }

        public void WriteGradesToFile(int[] roundedGrades)
        {
            var path = @"C:\Users\a.lagodzinska\source\repos\AlgorithmicTasks\output.txt";
            string joinGradesString = string.Join(",", roundedGrades);

            File.WriteAllText(path, joinGradesString);
        }
    }
}
