using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredManaCakeTests
    {
        [Fact]
        public void PositiveSellInHighQuality()
        {
            var cake = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};
            new TestRunner(cake)
                .SetExpectedSellIn(2)
                .SetExpectedQuality(4)
                .Run();
        }

        [Fact]
        public void ZeroSellInHighQuality()
        {
            var cake = new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 6};
            new TestRunner(cake)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(2)
                .Run();
        }

        [Fact]
        public void NegativeSellInHighQuality()
        {
            var cake = new Item {Name = "Conjured Mana Cake", SellIn = -10, Quality = 6};
            new TestRunner(cake)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(2)
                .Run();
        }

        [Fact]
        public void PositiveSellInQualityOne()
        {
            var cake = new Item {Name = "Conjured Mana Cake", SellIn = 10, Quality = 1};
            new TestRunner(cake)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void ZeroSellInQualityOne()
        {
            var cake = new Item {Name = "Conjured Mana Cake", SellIn = 0, Quality = 1};
            new TestRunner(cake)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void NegaiveSellInQualityOne()
        {
            var cake = new Item {Name = "Conjured Mana Cake", SellIn = -10, Quality = 1};
            new TestRunner(cake)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(0)
                .Run();
        }
    }
}
