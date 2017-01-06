using System;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class SulfurasTests
    {
        [Fact]
        public void RandomValuesTests()
        {
            var generator = new Random();
            for (var cycle = 0; cycle < 100; ++cycle)
            {
                var sellIn = generator.Next(-10, 10);
                var quality = generator.Next(0, 50);
                var sulfuras = new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = sellIn,
                    Quality = quality
                };

                new TestRunner(sulfuras)
                    .SetExpectedSellIn(sellIn)
                    .SetExpectedQuality(quality)
                    .Run();
            }
        }
    }
}
