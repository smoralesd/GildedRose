using System;

namespace GildedRose.Console
{
    public class ItemUpdaterFactory
    {
        public static IItemUpdater Create(Item item)
        {
            switch (item.Name)
            {
                case "Conjured Mana Cake":
                    return new UpdateByFunction(item, toUpdate => ItemUpdater.DecreaseByAmount(toUpdate, 2));
                case "+5 Dexterity Vest":
                case "Elixir of the Mongoose":
                    return new UpdateByFunction(item, toUpdate => ItemUpdater.DecreaseByAmount(toUpdate, 1));
                case "Aged Brie":
                    return new UpdateByFunction(item, toUpdate => ItemUpdater.IncreaseByAmount(toUpdate, 1));
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new UpdateByFunction(item, ItemUpdater.BackstagePasses);
                default:
                    return new UpdateByFunction(item, toUpdate => { });
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

    public class ItemUpdater : IItemUpdater
    {
        private readonly Item _item;

        public ItemUpdater(Item item)
        {
            _item = item;
        }

        public void Update()
        {
            UpdateItemQuality(_item);
        }

        public static void DecreaseByAmount(Item item, int amount)
        {
            var effectiveAmount = item.SellIn <= 0 ? 2 * amount : amount;
            item.Quality = Math.Max(item.Quality - effectiveAmount, 0);
            --item.SellIn;
        }

        public static void IncreaseByAmount(Item item, int amount)
        {
            var effectiveAMount = item.SellIn <= 0 ? 2*amount : amount;
            item.Quality = Math.Min(item.Quality + effectiveAMount, 50);
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

        public static void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case "Conjured Mana Cake":
                    DecreaseByAmount(item, 2);
                    return;
                case "+5 Dexterity Vest":
                case "Elixir of the Mongoose":
                    DecreaseByAmount(item, 1);
                    return;
                case "Aged Brie":
                    IncreaseByAmount(item, 1);
                    return;
                case "Backstage passes to a TAFKAL80ETC concert":
                    BackstagePasses(item);
                    return;
                default:
                    return;
            }
        }
    }
}