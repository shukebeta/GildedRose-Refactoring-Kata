using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {

        [Theory]
        [InlineData(20, 1, 19, 0)]
        [InlineData(11, 2, 10, 1)]
        [InlineData(6, 0, 5, 0)]
        [InlineData(0, 0, -1, 0)]
        public void StandardItemUpdateTheory(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            TestItemUpdate("Standard", sellIn, quality, expectedSellIn, expectedQuality);
        }

        private void TestItemUpdate(string itemName, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = itemName,
                    SellIn = sellIn,
                    Quality = quality,
                }
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }

        [Theory]
        [InlineData(20, 1, 19, 2)]
        [InlineData(11, 2, 10, 4)]
        [InlineData(10, 2, 9, 4)]
        [InlineData(6, 0, 5, 3)]
        [InlineData(5, 3, 4, 6)]
        [InlineData(0, 10, -1, 0)]
        public void BackstageUpdateTheory(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            TestItemUpdate("Backstage passes to a TAFKAL80ETC concert", sellIn, quality, expectedSellIn, expectedQuality);
        }

        [Theory]
        [InlineData(1, 1, 0, 2)]
        [InlineData(0, 2, -1, 4)]
        [InlineData(-1, 3, -2, 5)]
        [InlineData(0, 0, -1, 2)]
        public void AgedBrieUpdateTheory(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            TestItemUpdate("Aged Brie", sellIn, quality, expectedSellIn, expectedQuality);
        }

        [Theory]
        [InlineData(1, 1, 0, 0)]
        [InlineData(1, 2, 0, 0)]
        [InlineData(2, 3, 1, 1)]
        [InlineData(0, 0, -1, 0)]
        public void ConjuredUpdateTheory(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            TestItemUpdate("Conjured Mana Cake", sellIn, quality, expectedSellIn, expectedQuality);

        }

        [Theory]
        [InlineData(1, 80, 1, 80)]
        [InlineData(2, 80, 2, 80)]
        public void SulfurasUpdateTheory(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            TestItemUpdate("Sulfuras, Hand of Ragnaros", sellIn, quality, expectedSellIn, expectedQuality);
        }
    }
}