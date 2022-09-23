using Microsoft.VisualStudio.TestPlatform.Utilities;
using ReduceAway;
using System.Text;

namespace AlgorithmsTests
{
    public class ReduceAwayTests
    {
        private Logic _logic;
        public ReduceAwayTests()
        {
            _logic = new Logic();
        }

        [Fact]
        public void GetValidInput_InputStringIsValid_ReturnValidString()
        {
            var input = new StringReader("asdd");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.NotNull(validInput);
            Assert.Equal("asdd", validInput);
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

        [Fact]
        public void SuperReducedString_StringHasLettersThatWillNotBeReduced_ReturnReducedString()
        {
            var stringToReduce = "abbal";

            var reducedString = _logic.SuperReducedString(stringToReduce);

            Assert.NotEmpty(reducedString);
            Assert.Equal("l", reducedString);
        }

        [Fact]
        public void SuperReducedString_AllLettersWillBeReduced_ReturnEmptyString()
        {
            var stringToReduce = "abba";

            var reducedString = _logic.SuperReducedString(stringToReduce);

            Assert.Empty(reducedString);
        }

        [Fact]
        public void SuperReducedString_StringIsEmpty_ReturnEmptyString()
        {
            var stringToReduce = "";

            var reducedString = _logic.SuperReducedString(stringToReduce);

            Assert.Empty(reducedString);
        }

        [Theory]
        [InlineData("asdfr", true)]
        [InlineData("ASDfr", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("a3df", false)]
        [InlineData("af df", false)]
        public void IsValidInput_Input_ReturnsExpected(string testValue, bool expectedResult)
        {
            Assert.Equal(_logic.IsValidInput(testValue), expectedResult);
        }
    }
}
