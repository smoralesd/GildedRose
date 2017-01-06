using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class BackstagePassesTests
    {
        [Fact]
        public void HighRangeMinValueSellIn()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 11,
                Quality = 20
            };

            new TestRunner(passes)
                .SetExpectedSellIn(10)
                .SetExpectedQuality(21)
                .Run();
        }

        [Fact]
        public void MidRangeMaxValueSellIn()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 20
            };

            new TestRunner(passes)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(22)
                .Run();
        }

        [Fact]
        public void MidRangeMinValueSellIn()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 6,
                Quality = 20
            };

            new TestRunner(passes)
                .SetExpectedSellIn(5)
                .SetExpectedQuality(22)
                .Run();
        }

        [Fact]
        public void LowRangeMaxValueSellIn()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 20
            };

            new TestRunner(passes)
                .SetExpectedSellIn(4)
                .SetExpectedQuality(23)
                .Run();
        }

        [Fact]
        public void LowRangeMinValueSellIn()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 1,
                Quality = 20
            };

            new TestRunner(passes)
                .SetExpectedSellIn(0)
                .SetExpectedQuality(23)
                .Run();
        }

        [Fact]
        public void SellInZero()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 50
            };

            new TestRunner(passes)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void LowRangeMaxQuality()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 1,
                Quality = 50
            };

            new TestRunner(passes)
                .SetExpectedSellIn(0)
                .SetExpectedQuality(50)
                .Run();
        }

        [Fact]
        public void MidRangeMaxQuality()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 8,
                Quality = 50
            };

            new TestRunner(passes)
                .SetExpectedSellIn(7)
                .SetExpectedQuality(50)
                .Run();
        }

        [Fact]
        public void HighRangeMaxQuality()
        {
            var passes = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 20,
                Quality = 50
            };

            new TestRunner(passes)
                .SetExpectedSellIn(19)
                .SetExpectedQuality(50)
                .Run();
        }
    }
}
