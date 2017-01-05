using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class MongooseElixirTests
    {
        [Fact]
        public void PositiveSellInPositiveQuality()
        {
            var elixir = new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7};
            new TestRunner(elixir)
                .SetExpectedSellIn(4)
                .SetExpectedQuality(6)
                .Run();
        }

        [Fact]
        public void ZeroSellInPositiveQuality()
        {
            var elixir = new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7};
            new TestRunner(elixir)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(5)
                .Run();
        }

        [Fact]
        public void NegativeSellInPositiveQuality()
        {
            var elixir = new Item {Name = "Elixir of the Mongoose", SellIn = -10, Quality = 7};
            new TestRunner(elixir)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(5)
                .Run();
        }

        [Fact]
        public void PositiveSellInZeroQuality()
        {
            var elixir = new Item {Name = "Elixir of the Mongoose", SellIn = 10, Quality = 0};
            new TestRunner(elixir)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void ZeroSellInZeroQuality()
        {
            var elixir = new Item {Name = "Elixir of the Mongoose", SellIn = 0, Quality = 0};
            new TestRunner(elixir)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void NegativeSellInZeroQuality()
        {
            var elixir = new Item {Name = "Elixir of the Mongoose", SellIn = -10, Quality = 0};
            new TestRunner(elixir)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(0)
                .Run();
        }
    }
}