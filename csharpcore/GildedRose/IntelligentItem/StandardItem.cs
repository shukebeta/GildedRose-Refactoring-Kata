namespace GildedRose.IntelligentItem
{
    public class StandardItem: IIntelligentItem
    {
        private readonly Item _item;
        public StandardItem(Item item)
        {
            _item = item;
        }

        public void Update()
        {
            DecreaseSellIn();
            DecreaseQuality();
        }

        private void DecreaseSellIn()
        {
            _item.SellIn -= 1;
        }

        private void DecreaseQuality()
        {
            if (NotExpired())
            {
                DecreaseQualityIfPossible();
            }
            else
            {
                DecreaseDoubleQualityIfPossible();
            }
        }

        private bool NotExpired()
        {
            return _item.SellIn >= 0;
        }

        private void DecreaseDoubleQualityIfPossible()
        {
            DecreaseQualityIfPossible();
            DecreaseQualityIfPossible();
        }

        private void DecreaseQualityIfPossible()
        {
            if (_item.Quality > 0)
            {
                _item.Quality -= 1;
            }
        }
    }
}