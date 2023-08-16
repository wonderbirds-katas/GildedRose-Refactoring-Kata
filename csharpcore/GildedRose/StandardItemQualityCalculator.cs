namespace GildedRose;

internal class StandardItemQualityCalculator : IQualityCalculator
{
    private readonly Item _item;

    public StandardItemQualityCalculator(Item item)
    {
        _item = item;
    }

    public int CalculateQualityIncrease()
    {
        int result = 0;

        if (_item.Name == "Aged Brie"
            || _item.Name == "Backstage passes to a TAFKAL80ETC concert"
            || _item.Quality <= 0 || _item.Name == "Sulfuras, Hand of Ragnaros")
        {
            return result;
        }

        result -= 1;

        if (_item.SellIn < 0)
        {
            result -= 1;
        }

        return result;
    }
}