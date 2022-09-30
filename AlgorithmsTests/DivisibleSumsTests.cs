using DivisibleSums;

namespace AlgorithmsTests
{
    public class DivisibleSumsTests
    {
        private DivisibleSumsLogic _logic;
        public DivisibleSumsTests()
        {
            _logic = new DivisibleSumsLogic();
        }

        [Fact]
        public void GetValidIntInput_InputIsValid_ReturnIntArray()
        {
            var input = new StringReader("12");
            Console.SetIn(input);

            var validInput = _logic.GetValidIntInput();

            Assert.NotNull(validInput);
            Assert.Equal(12, validInput);
        }

        [Fact]
        public void GetValidIntInput_InputIsInvalid_AskForMoreInputTillIsValid()
        {
            var input = new StringReader("dsde,34\nas ddf\n4");
            Console.SetIn(input);

            var validInput = _logic.GetValidIntInput();

            Assert.NotNull(validInput);
            Assert.Equal(4, validInput);
        }

        [Fact]
        public void GetValidIntInput_InvalidInputForMoreThanFiveTimes_ReturnEmptyString()
        {
            var input = new StringReader("asd3dd\nas ddf\na55dd\nds4fds\ndfhg34");
            Console.SetIn(input);

            var validInput = _logic.GetValidIntInput();

            Assert.Null(validInput);
        }

        [Fact]
        public void GetValidArrayInput_InputIsValid_ReturnIntArray()
        {
            var input = new StringReader("12,23");
            Console.SetIn(input);

            var validInput = _logic.GetValidArrayInput();
            Console.In.Close();
            Assert.NotNull(validInput);
            Assert.Equal(new int[] { 12, 23 }, validInput);
        }

        [Fact]
        public void GetValidArrayInput_InputIsInvalid_AskForMoreInputTillIsValid()
        {
            var input = new StringReader("dsde,34\nas ddf\n34,45");
            Console.SetIn(input);

            var validInput = _logic.GetValidArrayInput();

            Assert.NotNull(validInput);
            Assert.Equal(new int[] { 34, 45 }, validInput);
        }

        [Fact]
        public void GetValidArrayInput_InvalidInputForMoreThanFiveTimes_ReturnEmptyString()
        {
            var input = new StringReader("asd3dd\nas ddf\na55dd\nds4fds\ndfhg34");
            Console.SetIn(input);

            var validInput = _logic.GetValidArrayInput();

            Assert.Null(validInput);
        }

        [Theory]
        [InlineData("asdfr", null)]
        [InlineData("12,34,56", new int[] { 12, 34, 56 })]
        [InlineData(null, null)]
        [InlineData("", null)]
        public void ParseToValidFormat_Input_ReturnsExpected(string testValue, int[] expectedResult)
        {
            Assert.Equal(_logic.ParseToValidFormat(testValue), expectedResult);
        }

        [Fact]
        public void GetArrayOfDevisionEvenlyCount_HaveDevisableSum_ReturnArrayThatHaveCount()
        {
            int[] intArray = new int[] { 1, 2, 3 };
            int divisor = 2;

            var array = _logic.GetArrayOfDevisionEvenlyCount(intArray, divisor);

            Assert.NotNull(array);
            Assert.Equal(new int[] { 1, 0, 1 }, array);
        }

        [Fact]
        public void GetArrayOfDevisionEvenlyCount_DontHaveDevisableSum_ReturnArrayWithAllZero()
        {
            int[] intArray = new int[] { 1, 2, 3 };
            int divisor = 6;

            var array = _logic.GetArrayOfDevisionEvenlyCount(intArray, divisor);

            Assert.NotNull(array);
            Assert.Equal(new int[] { 0, 0, 0 }, array);
        }

        [Fact]
        public void GetUpdatedList_ValidData_ListWithRemovedValue()
        {
            int[] arrayOfCounts = new int[] { 0, 0, 1, 2, 1 };
            List<int> listOfValues = new List<int> { 1, 2, 3, 4, 3 };

            var updatedList = _logic.GetUpdatedList(arrayOfCounts, listOfValues);

            Assert.DoesNotContain(4, updatedList);
            Assert.Equal(4, updatedList.Count);
        }

        [Fact]
        public void GetUpdatedList_ArrayAndListLengthIsDifferent_ListWithRemovedValue()
        {
            int[] arrayOfCounts = new int[] { 0, 0, 1};
            List<int> listOfValues = new List<int> { 1, 2, 3, 4, 3 };

            var action = () => _logic.GetUpdatedList(arrayOfCounts, listOfValues);

            var exception = Assert.Throws<Exception>(action);
            Assert.Equal("Length of array and list doesnt match!", exception.Message);
        }

        [Fact]
        public void GetUpdatedList_ArrayHaveTwoItemsWithSameCount_ListWithRemovedFirstValue()
        {
            int[] arrayOfCounts = new int[] { 0, 1, 0, 0, 1 };
            List<int> listOfValues = new List<int> { 1, 2, 3, 4, 3 };

            var updatedList = _logic.GetUpdatedList(arrayOfCounts, listOfValues);

            Assert.DoesNotContain(2, updatedList);
            Assert.Equal(4, updatedList.Count);
        }

        [Theory]
        [InlineData(new int[] { 1, 0, 0, 3, 0 }, false)]
        [InlineData(new int[] { 0, 0, 0, 0, 0 }, true)]
        public void DoesAllValuesInArrayAreZero_NotAllAreZero_ReturnFalse(int[] testValue, bool expectedResult)
        {
            Assert.Equal(_logic.DoesAllValuesInArrayAreZero(testValue), expectedResult);
        }
    }
}
