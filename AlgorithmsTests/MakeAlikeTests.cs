using MakeAlike;

namespace AlgorithmsTests
{
    public class MakeAlikeTests
    {
        private MakeAlikeLogic _logic;
        public MakeAlikeTests()
        {
            _logic = new MakeAlikeLogic();
        }

        [Fact]
        public void GetDesiredString_EnoughCountMovesToMakeDesiredString_ReturnYes()
        {
            var initialString = "asd";
            var desiredString = "asefr";
            var numberOfOperations = 9;

            var isItPossible = _logic.GetDesiredString(initialString, desiredString, numberOfOperations);

            Assert.Equal("Yes", isItPossible);
        }

        [Fact]
        public void GetDesiredString_NotEnoughMovesToRemoveLeakLetters_ReturnNo()
        {
            var initialString = "asdsd";
            var desiredString = "asefr";
            var numberOfOperations = 2;

            var isItPossible = _logic.GetDesiredString(initialString, desiredString, numberOfOperations);

            Assert.Equal("No", isItPossible);
        }

        [Fact]
        public void GetDesiredString_NotEnoughMovesToAddLetters_ReturnNo()
        {
            var initialString = "asdsd";
            var desiredString = "asefr";
            var numberOfOperations = 5;

            var isItPossible = _logic.GetDesiredString(initialString, desiredString, numberOfOperations);

            Assert.Equal("No", isItPossible);
        }
    }
}
