using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void DexteryVestPositiveSellInHighQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
            new TestRunner(vest)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(19)
                .Run();
        }

        [Fact]
        public void DexteryVestZeroSellInHighQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20};
            new TestRunner(vest)
                .SetExpectedSellIn(-1)
                .SetExpectedQuality(18)
                .Run();
        }

        [Fact]
        public void DexteryVestPositiveSellInZeroQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0};
            new TestRunner(vest)
                .SetExpectedSellIn(9)
                .SetExpectedQuality(0)
                .Run();
        }

        [Fact]
        public void DexteryVestNegativeSellInZeroQuality()
        {
            var vest = new Item {Name = "+5 Dexterity Vest", SellIn = -10, Quality = 0};
            new TestRunner(vest)
                .SetExpectedSellIn(-11)
                .SetExpectedQuality(0)
                .Run();
        }

        private class TestRunner
        {
            private readonly Item _item;
            private readonly string _originalName;
            private int? _expectedSellIn;
            private int? _expectedQuality;

            public TestRunner(Item item)
            {
                _item = item;
                _originalName = item.Name;
            }

            public TestRunner SetExpectedQuality(int quality)
            {
                _expectedQuality = quality;
                return this;
            }
            public TestRunner SetExpectedSellIn(int sellIn)
            {
                _expectedSellIn = sellIn;
                return this;
            }

            public void Run()
            {
                var app = new Program {Items = new List<Item> {_item}};
                app.UpdateQuality();

                _item.Name.ShouldAllBeEquivalentTo(_originalName);

                if (_expectedSellIn != null)
                {
                    _item.SellIn.ShouldBeEquivalentTo(_expectedSellIn);
                }

                if (_expectedQuality != null)
                {
                    _item.Quality.ShouldBeEquivalentTo(_expectedQuality);
                }
            }
        }
    }
}