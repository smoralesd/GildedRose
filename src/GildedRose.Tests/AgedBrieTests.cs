using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class AgedBrieTests
    {
        [Fact]
        public void PositiveSellInPositiveQuality()
        {
            var brie = new Item {Name = "Aged Brie", SellIn = 5, Quality = 5};
            new TestRunner(brie)
                .SetExpectedSellIn(4)
                .SetExpectedQuality(6)
                .Run();
        }

        [Fact]
        public void ZeroSellInPositiveQuality()
        {
            var brie = new Item {Name = "Aged Brie", SellIn = 0, Quality = 5};
            new TestRunner(brie)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(7)
                .Run();
        }

        [Fact]
        public void NegativeSellInPositiveQuality()
        {
            var brie = new Item {Name = "Aged Brie", SellIn = -10, Quality = 5};
            new TestRunner(brie)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(7)
                .Run();
        }

        [Fact]
        public void PositiveSellInMaximumQuality()
        {
            var brie = new Item {Name = "Aged Brie", SellIn = 5, Quality = 50};
            new TestRunner(brie)
                .SetExpectedSellIn(4)
                .SetExpectedQuality(50)
                .Run();
        }

        [Fact]
        public void ZeroSellInMaximumQuality()
        {
            var brie = new Item {Name = "Aged Brie", SellIn = 0, Quality = 50};
            new TestRunner(brie)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(50)
                .Run();
        }

        [Fact]
        public void NegativeSellInMaximumQuality()
        {
            var brie = new Item {Name = "Aged Brie", SellIn = -10, Quality = 50};
            new TestRunner(brie)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(50)
                .Run();
        }
    }
}