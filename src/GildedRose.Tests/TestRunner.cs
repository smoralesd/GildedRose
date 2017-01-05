using System;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestRunner
    {
        private readonly Item _item;
        private readonly string _originalName;
        private int? _expectedSellIn;
        private int? _expectedQuality;

        public TestRunner(Item item)
        {
            if (item == null)
            {
                throw new Exception("null item");
            }

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
            var app = new Program { Items = new List<Item> { _item } };
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