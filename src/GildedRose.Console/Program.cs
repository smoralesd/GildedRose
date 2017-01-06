using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        private readonly IList<Item> _items;

        public Program(IList<Item> items)
        {
            _items = items;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program(
                new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                }
            );

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            _items.ToList().ForEach(UpdateItemQuality);
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

        private static void UpdateItemQuality(Item item)
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

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}