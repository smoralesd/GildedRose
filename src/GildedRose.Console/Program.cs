using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        private readonly IList<IItemUpdater> _itemUpdaters;

        public static Item DexteryVest => new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20};
        public static Item AgedBrie => new Item {Name = "Aged Brie", SellIn = 2, Quality = 0};
        public static Item MongooseElixir => new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7};
        public static Item Sulfuras => new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
        public static Item BackstagePasses => new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20};
        public static Item ManaCake => new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};

        public Program(IEnumerable<Item> items)
        {
            _itemUpdaters = items.Select(ItemUpdaterFactory.Create).ToList();
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
            _itemUpdaters.ToList().ForEach(updater => updater.Update());
        }
    }

    public class ItemUpdaterFactory
    {
        public static IItemUpdater Create(Item item)
        {
            return new ItemUpdater(item);
        }
    }
    public interface IItemUpdater
    {
        void Update();
    }

    public class ItemUpdater : IItemUpdater
    {
        public Item Item { get; }

        public ItemUpdater(Item item)
        {
            Item = item;
        }

        public void Update()
        {
            if (Item.Name != "Aged Brie" && Item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Item.Quality > 0)
                {
                    if (Item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        Item.Quality = Item.Quality - 1;
                    }
                }
            }
            else
            {
                if (Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;

                    if (Item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Item.SellIn < 11)
                        {
                            if (Item.Quality < 50)
                            {
                                Item.Quality = Item.Quality + 1;
                            }
                        }

                        if (Item.SellIn < 6)
                        {
                            if (Item.Quality < 50)
                            {
                                Item.Quality = Item.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Item.Name != "Sulfuras, Hand of Ragnaros")
            {
                Item.SellIn = Item.SellIn - 1;
            }

            if (Item.SellIn < 0)
            {
                if (Item.Name != "Aged Brie")
                {
                    if (Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Item.Quality > 0)
                        {
                            if (Item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Item.Quality = Item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Item.Quality = Item.Quality - Item.Quality;
                    }
                }
                else
                {
                    if (Item.Quality < 50)
                    {
                        Item.Quality = Item.Quality + 1;
                    }
                }
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
