using MinimumLoss;

namespace AlgorithmsTests
{
    public class MinimumLossTests
    {
        private MinimumLossLogic _logic;
        public MinimumLossTests()
        {
            _logic = new MinimumLossLogic();
        }

        [Fact]
        public void GetMinimumLoss_ArrayContainsLoss_ReturnLoss()
        {
            int[] pricesEachYear = new int[] { 20, 12, 34, 25, 15 };

            var minimumLoss = _logic.GetMinimumLoss(pricesEachYear);

            Assert.Equal(5, minimumLoss);
        }

        [Fact]
        public void GetMinimumLoss_ArrayInAscendingOrder_ReturnZero()
        {
            int[] pricesEachYear = new int[] { 20, 22, 25, 26, 28 };

            var minimumLoss = _logic.GetMinimumLoss(pricesEachYear);

            Assert.Equal(0, minimumLoss);
        }
    }
}
