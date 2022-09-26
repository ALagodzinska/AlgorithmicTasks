using MakeMeRoundly;
using Moq;
using System.IO.Abstractions.TestingHelpers;

namespace AlgorithmsTests
{
    public class MakeMeRoundlyTests
    {
        private MakeMeRoundlyLogic _simpleLogic;
        private MakeMeRoundlyLogic _logicWithFiles;
        private MockFileSystem _fileSystem;
        public MakeMeRoundlyTests()
        {
            _simpleLogic = new MakeMeRoundlyLogic();

            _fileSystem = new MockFileSystem();
            _logicWithFiles = new MakeMeRoundlyLogic(_fileSystem);
        }

        [Fact]
        public void GetGradesFromFile_WhenFileExistAndHaveGrades_ReturnGradeArray()
        {
            var mockInputFile = new MockFileData("12, 34, 58, 89, 65");
            _fileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var grades = _logicWithFiles.GetGradesFromFile(@"C:\temp\in.txt");

            Assert.NotNull(grades);
            Assert.Equal(5, grades.Length);
        }

        [Fact]
        public void GetGradesFromFile_FileDoesntExsist_ThrowException()
        {
            var action = () => _logicWithFiles.GetGradesFromFile(@"C:\temp\in.txt");

            Assert.Throws<FileNotFoundException>(action);
        }

        [Fact]
        public void GetGradesFromFile_FileIsEmpty_ReturnEmptyGradeArray()
        {
            var mockInputFile = new MockFileData("");
            _fileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var grades = _logicWithFiles.GetGradesFromFile(@"C:\temp\in.txt");

            Assert.NotNull(grades);
            Assert.Empty(grades);
        }

        [Fact]
        public void GetGradesFromFile_WrongData_ReturnNull()
        {
            var mockInputFile = new MockFileData("87. 67. ");
            _fileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var grades = _logicWithFiles.GetGradesFromFile(@"C:\temp\in.txt");

            Assert.Null(grades);
        }

        [Fact]
        public void RoundGrades_ValidGrades_RoundedGradesByRules()
        {
            var grades = new int[]
            {
                34, 56, 78
            };

            var roundedGrades = _simpleLogic.RoundGrades(grades);

            Assert.Equal(34, roundedGrades.First());
            Assert.Equal(56, roundedGrades[1]);
            Assert.Equal(80, roundedGrades.Last());
        }

        [Fact]
        public void RoundGrades_GradesAreNotInRange_ThrowException()
        {
            var grades = new int[]
            {
                -1, 1001
            };

            var action = () => _simpleLogic.RoundGrades(grades);

            var exeption = Assert.Throws<Exception>(action);
            Assert.Contains("Grade does not fit in a range.", exeption.Message);
        }

        [Fact]
        public void RoundGrades_EmptyGradeArray_ReturnArrayWithZeroValues()
        {
            var grades = new int[2];

            var roundedGrades = _simpleLogic.RoundGrades(grades);

            Assert.Equal(0, roundedGrades.First());
            Assert.Equal(0, roundedGrades.Last());
        }

        [Fact]
        public void WriteGradesToFile_ValidData_DataIsWrittenToAFile()
        {
            var mockInputFile = new MockFileData("");
            _fileSystem.AddFile(@"C:\temp\in.txt", mockInputFile);

            var grades = new int[]
            {
                34, 56, 80
            };

            _logicWithFiles.WriteGradesToFile(grades, @"C:\temp\in.txt");

            var textFromFile = _fileSystem.File.ReadAllText(@"C:\temp\in.txt");

            Assert.Equal("34,56,80", textFromFile);
        }

        [Fact]
        public void WriteGradesToFile_FileDoesNotExsist_FileIsCreated()
        {
            var grades = new int[]
            {
                34, 56, 80
            };

            _logicWithFiles.WriteGradesToFile(grades, @"C:\temp\in.txt");

            Assert.True(_fileSystem.FileExists(@"C:\temp\in.txt"));
            var textFromFile = _fileSystem.File.ReadAllText(@"C:\temp\in.txt");

            Assert.Equal("34,56,80", textFromFile);
        }

        [Fact]
        public void PrintGrades_GradesToPrint_GradesAreDisplayedToConsole()
        {
            var grades = new int[]
            {
                34, 56, 80
            };

            var output = new StringWriter();
            Console.SetOut(output);

            var logic = new MakeMeRoundlyLogic();

            logic.PrintGrades(grades);

            Assert.Equal(output.ToString(), String.Format($"{Environment.NewLine}Rounded Grades: {Environment.NewLine}34, 56, 80, "));
        }
    }
}