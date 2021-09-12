namespace GildedRose.IntelligentItem
{
    public class Conjured : IIntelligentItem
    {
        private readonly Item _item;

        public Conjured(Item item)
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
            DecreaseQualityTwiceIfPossible();
            if (Expired())
            {
                DecreaseQualityTwiceIfPossible();
            }
        }

        private void DecreaseQualityTwiceIfPossible()
        {
            DecreaseQualityIfPossible();
            DecreaseQualityIfPossible();
        }

        private bool Expired()
        {
            return _item.SellIn < 0;
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