using LeaderBoard;

namespace AlgorithmsTests
{
    public class LeaderBoardTests
    {
        private LeaderBoardLogic _logic;
        public LeaderBoardTests()
        {
            _logic = new LeaderBoardLogic();
        }

        [Fact]
        public void GetValidInput_InputIsValid_ReturnIntArray()
        {
            var input = new StringReader("12,23");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.NotNull(validInput);
            Assert.Equal(new int[] {12, 23}, validInput);
        }

        [Fact]
        public void GetValidInput_InputIsInvalid_AskForMoreInputTillIsValid()
        {
            var input = new StringReader("dsde,34\nas ddf\n34,45");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.NotNull(validInput);
            Assert.Equal(new int[] {34, 45}, validInput);
        }

        [Fact]
        public void GetValidInput_InvalidInputForMoreThanFiveTimes_ReturnEmptyString()
        {
            var input = new StringReader("asd3dd\nas ddf\na55dd\nds4fds\ndfhg34");
            Console.SetIn(input);

            var validInput = _logic.GetValidInput();

            Assert.Null(validInput);
        }

        [Theory]
        [InlineData("asdfr", null)]
        [InlineData("12,34,56", new int[] {12, 34, 56})]
        [InlineData(null, null)]
        [InlineData("", null)]
        public void ParseToValidFormat_Input_ReturnsExpected(string testValue, int[] expectedResult)
        {
            Assert.Equal(_logic.ParseToValidFormat(testValue), expectedResult);
        }

        [Fact]
        public void GetPlayersRanks_ValidData_ReturnRankedPlayerScores()
        {
            var leaderBoardScores = new int[] { 100, 100, 50, 40, 40, 20, 10 };
            var playerScores = new int[] { 5, 25, 50, 120 };
            
            var playersRanks = _logic.GetPlayersRanks(leaderBoardScores, playerScores);

            Assert.NotNull(playersRanks);
            Assert.Equal(4, playerScores.Length);
            Assert.Equal(new int[] {8, 5, 3, 1}, playersRanks);

        }

        [Fact]
        public void GetPlayersRanks_EmptyRank_ReturnRankedPlayerScores()
        {
            var leaderBoardScores = new int[0];
            var playerScores = new int[] { 5, 25, 50, 120 };

            var playersRanks = _logic.GetPlayersRanks(leaderBoardScores, playerScores);

            Assert.NotNull(playersRanks);
            Assert.Equal(4, playerScores.Length);
            Assert.Equal(new int[] { 4, 3, 2, 1 }, playersRanks);

        }

    }
}
