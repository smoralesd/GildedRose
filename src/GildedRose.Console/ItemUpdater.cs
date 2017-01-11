using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class ItemUpdaterFactory
    {
        public static IItemUpdater Create(Item item)
        {
            switch (item.Name)
            {
                case "Conjured Mana Cake":
                    return new UpdateByFunction(item, toUpdate => ItemUpdater.UpdateByAmount(toUpdate, -2));
                case "+5 Dexterity Vest":
                case "Elixir of the Mongoose":
                    return new UpdateByFunction(item, toUpdate => ItemUpdater.UpdateByAmount(toUpdate, -1));
                case "Aged Brie":
                    return new UpdateByFunction(item, toUpdate => ItemUpdater.UpdateByAmount(toUpdate, 1));
                case "Backstage passes to a TAFKAL80ETC concert":
                    var updater = new RangeUpdater.Builder()
                        .AddThreshold(new RangeUpdater.Threshold {MaxValue = 6, UpdateAmount = 3})
                        .AddThreshold(new RangeUpdater.Threshold {MaxValue = 11, UpdateAmount = 2})
                        .AddThreshold(new RangeUpdater.Threshold {MaxValue = int.MaxValue, UpdateAmount = 1})
                        .Build();
                    return new UpdateByFunction(item, updater.Update);
                default:
                    return new UpdateByFunction(item, toUpdate => { });
            }
        }

        private class RangeUpdater
        {
            private int _maxQualityValue;
            private IEnumerable<Threshold> _thresholds;

            public void Update(Item item)
            {
                if (item.SellIn <= 0)
                {
                    --item.SellIn;
                    item.Quality = 0;
                    return;
                }

                var posibleThresholds = _thresholds.Where(t => t.MaxValue > item.SellIn).ToList();
                posibleThresholds.Sort((a, b) => a.MaxValue - b.MaxValue);
                var threshold = posibleThresholds.First();
                item.Quality = Math.Min(item.Quality + threshold.UpdateAmount, _maxQualityValue);
                --item.SellIn;
            }

            public class Threshold
            {
                public int MaxValue;
                public int UpdateAmount;


            }

            public class Builder
            {
                private const int MaxQualityValue = 50;
                private readonly IList<Threshold> _thresholds = new List<Threshold>();

                public Builder AddThreshold(Threshold t)
                {
                    _thresholds.Add(t);
                    return this;
                }

                public RangeUpdater Build()
                {
                    var toSort = _thresholds.ToList();
                    toSort.Sort((a, b) => a.MaxValue - b.MaxValue);

                    return new RangeUpdater {_maxQualityValue = MaxQualityValue, _thresholds = toSort};
                }
            }
        }

        private static class ItemUpdater
        {
            public static void UpdateByAmount(Item item, int amount)
            {
                var effectiveAmount = item.SellIn <= 0 ? 2 * amount : amount;
                item.Quality = Math.Max(item.Quality + effectiveAmount, 0);
                item.Quality = Math.Min(item.Quality, 50);
                --item.SellIn;
            }

            public static void BackstagePasses(Item item)
            {
                ++item.Quality;

                if (item.SellIn < 11)
                {
                    ++item.Quality;
                }

                if (item.SellIn < 6)
                {
                    ++item.Quality;
                }

                item.Quality = Math.Min(item.Quality, 50);
                --item.SellIn;

                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
            }
        }
    }

    public interface IItemUpdater
    {
        void Update();
    }

    public class UpdateByFunction : IItemUpdater
    {
        private readonly Item _item;
        private readonly Action<Item> _updateFunction;

        public UpdateByFunction(Item item, Action<Item> updateFunction)
        {
            _item = item;
            _updateFunction = updateFunction;
        }

        public void Update()
        {
            _updateFunction(_item);
        }
    }
}