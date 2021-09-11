using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace GildedRoseKata
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
                DoUpdateQuality(item);
            }
        }

        private static void DoUpdateQuality(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                {
                    DecreaseSellIn(item);
                    IncreaseQualityIfPossible(item);
                    if (IsExpired(item))
                    {
                        IncreaseQualityIfPossible(item);
                    }

                    break;
                }
                case "Backstage passes to a TAFKAL80ETC concert":
                {
                    DecreaseSellIn(item);
                    if (FurtherFromExpiration(item))
                    {
                        IncreaseQualityIfPossible(item);
                    }
                    else
                    {
                        IncreaseQualityIfPossible(item);
                        IncreaseQualityIfPossible(item);
                        if (CloseToExpiration(item))
                        {
                            IncreaseQualityIfPossible(item);
                        }
                    }

                    if (IsExpired(item))
                    {
                        SetItemQualityZero(item);
                    }

                    break;
                }
                case "Sulfuras, Hand of Ragnaros":
                    break;
                case "Conjured Mana Cake":
                    DecreaseSellIn(item);
                    DecreaseDoubleQualityIfPossible(item);
                    break;
                default:
                {
                    DecreaseSellIn(item);
                    StandardDecreaseQuality(item);
                    break;
                }
            }
        }

        private static bool FurtherFromExpiration(Item item)
        {
            return !FarFromExpiration(item);
        }

        private static bool FarFromExpiration(Item item)
        {
            return item.SellIn < Constants.FarFromExpiration;
        }

        private static bool CloseToExpiration(Item item)
        {
            return item.SellIn < Constants.CloseToExpiration;
        }

        private static void StandardDecreaseQuality(Item item)
        {
            if (NotExpired(item))
            {
                DecreaseQualityIfPossible(item);
            }
            else
            {
                DecreaseDoubleQualityIfPossible(item);
            }
        }

        private static bool NotExpired(Item item)
        {
            return item.SellIn >= 0;
        }

        private static bool IsExpired(Item item)
        {
            return !NotExpired(item);
        }

        private static void SetItemQualityZero(Item item)
        {
            item.Quality = 0;
        }

        private static void DecreaseDoubleQualityIfPossible(Item item)
        {
            DecreaseQualityIfPossible(item);
            DecreaseQualityIfPossible(item);
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }

        private static void DecreaseQualityIfPossible(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }

        private static void IncreaseQualityIfPossible(Item item)
        {
            if (item.Quality < Constants.QualityMax)
            {
                item.Quality += 1;
            }
        }
    }
}