using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        private readonly IList<ItemUpdater> _itemUpdaters;

        public static Item DexteryVest => new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
        public static Item AgedBrie => new Item {Name = "Aged Brie", SellIn = 2, Quality = 0};
        public static Item MongooseElixir => new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7};
        public static Item Sulfuras => new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
        public static Item BackstagePasses => new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20};
        public static Item ManaCake => new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};

        public Program(IEnumerable<Item> items)
        {
            _itemUpdaters = items.Select(i => new ItemUpdater(i)).ToList();
        }

        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var items = new List<Item>
            {
                DexteryVest,
                AgedBrie,
                MongooseElixir,
                Sulfuras,
                BackstagePasses,
                ManaCake
            };

            var app = new Program(items);

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            _itemUpdaters.ToList().ForEach(updater => UpdateItem(updater.Item));
        }

        private static void UpdateItem(Item currentItem)
        {
            if (currentItem.Name != "Aged Brie" && currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (currentItem.Quality > 0)
                {
                    if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        currentItem.Quality = currentItem.Quality - 1;
                    }
                }
            }
            else
            {
                if (currentItem.Quality < 50)
                {
                    currentItem.Quality = currentItem.Quality + 1;

                    if (currentItem.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (currentItem.SellIn < 11)
                        {
                            if (currentItem.Quality < 50)
                            {
                                currentItem.Quality = currentItem.Quality + 1;
                            }
                        }

                        if (currentItem.SellIn < 6)
                        {
                            if (currentItem.Quality < 50)
                            {
                                currentItem.Quality = currentItem.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
            {
                currentItem.SellIn = currentItem.SellIn - 1;
            }

            if (currentItem.SellIn < 0)
            {
                if (currentItem.Name != "Aged Brie")
                {
                    if (currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (currentItem.Quality > 0)
                        {
                            if (currentItem.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                currentItem.Quality = currentItem.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        currentItem.Quality = currentItem.Quality - currentItem.Quality;
                    }
                }
                else
                {
                    if (currentItem.Quality < 50)
                    {
                        currentItem.Quality = currentItem.Quality + 1;
                    }
                }
            }
        }
    }

    public class ItemUpdater
    {
        public Item Item { get; }

        public ItemUpdater(Item item)
        {
            Item = item;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
