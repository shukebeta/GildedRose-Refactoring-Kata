namespace GildedRose.IntelligentItem
{
    public class BackstagePasses : IIntelligentItem
    {
        private readonly Item _item;

        public BackstagePasses(Item item)
        {
            _item = item;
        }

        public void Update()
        {
            DecreaseSellIn();
            UpdateQuality();
        }

        private void DecreaseSellIn()
        {
            _item.SellIn -= 1;
        }

        private void UpdateQuality()
        {
            if (IsExpired())
            {
                SetItemQualityZero();
            }
            else
            {
                if (FurtherFromExpiration())
                {
                    IncreaseQualityIfPossible();
                }
                else
                {
                    IncreaseQualityIfPossible();

                    IncreaseQualityIfPossible();
                    if (CloseToExpiration())
                    {
                        IncreaseQualityIfPossible();
                    }
                }
            }
        }


        private bool IsExpired()
        {
            return _item.SellIn < 0;
        }

        private void SetItemQualityZero()
        {
            _item.Quality = 0;
        }

        private bool FurtherFromExpiration()
        {
            return !FarFromExpiration();
        }

        private bool FarFromExpiration()
        {
            return _item.SellIn < Constants.FarFromExpiration;
        }

        private bool CloseToExpiration()
        {
            return _item.SellIn < Constants.CloseToExpiration;
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