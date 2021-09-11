using System.Runtime.Serialization.Json;

namespace GildedRose.IntelligentItem
{
    public static class IntelligentItemFactory
    {
        public static IIntelligentItem GetIntelligentItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePasses(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(item);
                case "Conjured Mana Cake":
                    return new Conjured(item);
                default:
                    return new StandardItem(item);
            }
        }
    }
}