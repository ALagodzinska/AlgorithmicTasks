namespace AlgorithmsTests
{
    using RemoveToTwo;

    public class RemoveToTwoTests
    {
        private RemoveToTwoLogic _logic;

        public RemoveToTwoTests()
        {
            _logic = new RemoveToTwoLogic();
        }

        [Fact]
        public void GetValidInput_InputStringIsValid_ReturnValidString()
        {
            var input = new StringReader("assdd");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.NotNull(validInput);
            Assert.Equal("assdd", validInput);
        }

        [Fact]
        public void GetValidInput_InputContainsUppercaseLetters_ReturnValidStringInLowercase()
        {
            var input = new StringReader("ASSDD");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.NotNull(validInput);
            Assert.Equal("assdd", validInput);
        }

        [Fact]
        public void GetValidInput_InputStrindIsInvalid_AskForMoreInputTillStringIsValid()
        {
            var input = new StringReader("asd3dd\nas ddf\nasdd");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.NotNull(validInput);
            Assert.Equal("asdd", validInput);
        }

        [Fact]
        public void GetValidInput_InvalidInputForMoreThanFiveTimes_ReturnEmptyString()
        {
            var input = new StringReader("asd3dd\nas ddf\na55dd\nds4fds\ndfhg34");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.Empty(validInput);
        }

        [Theory]
        [InlineData("asdfr", true)]
        [InlineData("ASDfr", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a3df", false)]
        [InlineData("af df", false)]
        //how to make a long string
        public void IsValidInput_Input_ReturnsExpected(string testValue, bool expectedResult)
        {
            Assert.Equal(_logic.IsValidInput(testValue), expectedResult);
        }

        [Fact]
        public void LongestPossibleStringCount_EmptyString_ReturnZero()
        {
            var inputString = "";

            var count = _logic.LongestPossibleStringCount(inputString);

            Assert.Equal(0, count);
        }

        [Fact]
        public void LongestPossibleStringCount_ValidString_LongestSequenceCount()
        {
            var inputString = "beabeefeab";

            var count = _logic.LongestPossibleStringCount(inputString);

            Assert.Equal(5, count);
        }

        [Fact]
        public void LongestPossibleStringCount_NoStringsWithSequenceFound_()
        {
            var inputString = "bffb";

            var count = _logic.LongestPossibleStringCount(inputString);

            Assert.Equal(0, count);
        }
    }
}
