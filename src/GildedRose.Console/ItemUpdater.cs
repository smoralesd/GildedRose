using System;

namespace GildedRose.Console
{
    public interface IItemUpdater
    {
        void Update();
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

        private static void DecreaseByAmount(Item item, int amount)
        {
            var effectiveAmount = item.SellIn <= 0 ? 2 * amount : amount;
            item.Quality = Math.Max(item.Quality - effectiveAmount, 0);
            --item.SellIn;
        }

        private static void IncreaseByAmount(Item item, int amount)
        {
            var effectiveAMount = item.SellIn <= 0 ? 2*amount : amount;
            item.Quality = Math.Min(item.Quality + effectiveAMount, 50);
            --item.SellIn;
        }

        private static void BackstagePasses(Item item)
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