using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class DexteryVestTests
    {
        [Fact]
        public void PositiveSellInHighQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
            new TestRunner(vest)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(19)
                .Run();
        }

        [Fact]
        public void ZeroSellInHighQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20};
            new TestRunner(vest)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(18)
                .Run();
        }

        [Fact]
        public void NegativeSellInHighQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = -10, Quality = 20};
            new TestRunner(vest)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(18)
                .Run();
        }

        [Fact]
        public void PositiveSellInZeroQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0};
            new TestRunner(vest)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void ZeroSellInZeroQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0};
            new TestRunner(vest)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void NegativeSellInZeroQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = -10, Quality = 0};
            new TestRunner(vest)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(0)
                .Run();
        }
    }
}