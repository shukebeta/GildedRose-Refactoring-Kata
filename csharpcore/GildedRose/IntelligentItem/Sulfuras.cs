namespace GildedRose.IntelligentItem
{
    public class Sulfuras: IIntelligentItem
    {
        private readonly Item _item;
        public Sulfuras(Item item)
        {
            _item = item;
        }

        public void Update()
        {
            // do nothing
        }
    }
}