using System.Collections.Generic;
using GildedRose.IntelligentItem;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                IntelligentItemFactory.GetIntelligentItem(item).Update();
            }
        }
    }
}