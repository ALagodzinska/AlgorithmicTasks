using System.IO;
using System.IO.Abstractions;

namespace MakeMeRoundly
{
    public class MakeMeRoundlyLogic
    {
        private readonly IFileSystem _fileSystem;

        public MakeMeRoundlyLogic() : this(new FileSystem()) { }

        public MakeMeRoundlyLogic(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        private static string folderName = "FileData";
        private static string readFileName = "input.txt";
        private static string writeFileName = "output.txt";

        public readonly string readFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName, readFileName));
        public readonly string writeFilePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName, writeFileName));

        public void Run()
        {
            var gradesFromFile = GetGradesFromFile(readFilePath);

            if (gradesFromFile == null || gradesFromFile.Length < 0 || gradesFromFile.Length > 60)
            {
                Console.WriteLine("File data in invalid!");
                return;
            }

            var roundedGrades = RoundGrades(gradesFromFile);

            WriteGradesToFile(roundedGrades, writeFilePath);

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

        public int[]? GetGradesFromFile(string filePath)
        {
            if (!_fileSystem.File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var grades = _fileSystem.File.ReadAllText(filePath);
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

                    return null;
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

        public void WriteGradesToFile(int[] roundedGrades, string filePath)
        {
            string joinGradesString = string.Join(",", roundedGrades);

            _fileSystem.File.WriteAllText(filePath, joinGradesString);
        }
    }
}
