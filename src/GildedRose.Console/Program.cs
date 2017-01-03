using System;
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
            if (item.Name.Equals(Program.Sulfuras.Name))
            {
                return new NullItemUpdater(item);
            }

            if (item.Name.Equals(Program.DexteryVest.Name) || item.Name.Equals(Program.MongooseElixir.Name))
            {
                return new CustomMethodQualityUpdater(item, current => Math.Max(current - 1, 0));
            }

            if (item.Name.Equals(Program.ManaCake.Name))
            {
                return new CustomMethodQualityUpdater(item, current => Math.Max(current - 2, 0));
            }

            if (item.Name.Equals(Program.BackstagePasses.Name))
            {
                return new RangeItemUpdater(item);
            }

            if (item.Name.Equals(Program.AgedBrie.Name))
            {
                return new CustomMethodQualityUpdater(item, current => Math.Min(current + 1, 50));
            }

            throw new Exception(@"Unsuported item: <{item.Name}>");
        }
    }

    public interface IItemUpdater
    {
        void Update();
    }

    public class NullItemUpdater : IItemUpdater
    {
        public Item Item { get; }

        public NullItemUpdater(Item item)
        {
            Item = item;
        }

        public void Update()
        {
            //NO OP
        }
    }

    public class CustomMethodQualityUpdater : NullItemUpdater, IItemUpdater
    {
        private readonly Func<int, int> _getUpdatedQuality;

        public CustomMethodQualityUpdater(Item item, Func<int, int> getUpdatedQuality) : base(item)
        {
            _getUpdatedQuality = getUpdatedQuality;
        }

        public new void Update()
        {
            Item.Quality = _getUpdatedQuality(Item.Quality);

            Item.SellIn = Item.SellIn - 1;

            if (Item.SellIn < 0)
            {
                Item.Quality = _getUpdatedQuality(Item.Quality);
            }
        }
    }

    public class RangeItemUpdater : NullItemUpdater, IItemUpdater
    {
        public RangeItemUpdater(Item item) : base(item)
        {
        }

        public new void Update()
        {
            if (Item.SellIn <= 0)
            {
                Item.Quality = 0;
                --Item.SellIn;
                return;
            }

            if (Item.Quality < 50)
            {
                Item.Quality = Item.Quality + 1;

                if (Item.SellIn < 11 && Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;
                }

                if (Item.SellIn < 6 && Item.Quality < 50)
                {
                    Item.Quality = Item.Quality + 1;
                }
            }

            --Item.SellIn;
        }
    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}