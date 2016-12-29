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

        public Program(IList<Item> items)
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
            for (var i = 0; i < _itemUpdaters.Count; i++)
            {
                if (_itemUpdaters[i].Item.Name != "Aged Brie" && _itemUpdaters[i].Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (_itemUpdaters[i].Item.Quality > 0)
                    {
                        if (_itemUpdaters[i].Item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (_itemUpdaters[i].Item.Quality < 50)
                    {
                        _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality + 1;

                        if (_itemUpdaters[i].Item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_itemUpdaters[i].Item.SellIn < 11)
                            {
                                if (_itemUpdaters[i].Item.Quality < 50)
                                {
                                    _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality + 1;
                                }
                            }

                            if (_itemUpdaters[i].Item.SellIn < 6)
                            {
                                if (_itemUpdaters[i].Item.Quality < 50)
                                {
                                    _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (_itemUpdaters[i].Item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    _itemUpdaters[i].Item.SellIn = _itemUpdaters[i].Item.SellIn - 1;
                }

                if (_itemUpdaters[i].Item.SellIn < 0)
                {
                    if (_itemUpdaters[i].Item.Name != "Aged Brie")
                    {
                        if (_itemUpdaters[i].Item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (_itemUpdaters[i].Item.Quality > 0)
                            {
                                if (_itemUpdaters[i].Item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality - _itemUpdaters[i].Item.Quality;
                        }
                    }
                    else
                    {
                        if (_itemUpdaters[i].Item.Quality < 50)
                        {
                            _itemUpdaters[i].Item.Quality = _itemUpdaters[i].Item.Quality + 1;
                        }
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
