namespace GildedRose.IntelligentItem
{
    public class AgedBrie : IIntelligentItem
    {
        private readonly Item _item;

        public AgedBrie(Item item)
        {
            _item = item;
        }

        public void Update()
        {
            DecreaseSellIn();
            IncreaseQuality();
        }

        private void DecreaseSellIn()
        {
            _item.SellIn -= 1;
        }

        private void IncreaseQuality()
        {
            if (NotExpired())
            {
                IncreaseQualityIfPossible();
            }
            else
            {
                IncreaseQualityIfPossible();
                IncreaseQualityIfPossible();
            }

        }

        private bool NotExpired()
        {
            return _item.SellIn >= 0;
        }

        private void IncreaseQualityIfPossible()
        {
            if (_item.Quality < Constants.QualityMax)
            {
                _item.Quality += 1;
            }
        }
    }
}