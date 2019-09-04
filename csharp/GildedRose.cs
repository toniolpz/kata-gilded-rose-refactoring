using ApprovalUtilities.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        private const string sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string agedBrie = "Aged Brie";
        private const string backstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string conjured = "Conjured Mana Cake";

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                // Update SellIn in everything except for sulfuras
                if (!item.Name.Equals(sulfuras)) item.SellIn--;

                switch (item.Name)
                {
                    case agedBrie:
                        // Increases quality with time
                        if (item.Quality < 50) item.Quality++;
                        // Increase quality one more if sell date has passed
                        if (item.Quality < 50 && item.SellIn < 0) item.Quality++;
                        break;
                    case backstagePasses:
                        // Increases quality with time
                        if (item.Quality < 50) item.Quality++;
                        // Increases quality by two within 10 days
                        if (item.Quality < 50 && item.SellIn < 10) item.Quality++;
                        // Increases quality by thrw within 5 days
                        if (item.Quality < 50 && item.SellIn < 5) item.Quality++;
                        // Quality drops to cero after the concert
                        if (item.SellIn < 0) item.Quality = 0;
                        break;
                    case sulfuras:
                        // I'm legendary
                        break;
                    case conjured:
                        // Decrease in one
                        if (item.Quality > 0) item.Quality--;
                        // If still have value in quality, decrease one more
                        if (item.Quality > 0) item.Quality--;
                        break;
                    default:
                        // Decreases quality of regular Items
                        if (item.Quality > 0) item.Quality--;
                        // Decreases double if sell date has passed
                        if (item.Quality > 0 && item.SellIn < 0) item.Quality--;
                        break;
                }
            }
        }
    }
}
