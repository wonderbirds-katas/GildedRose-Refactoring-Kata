namespace GildedRose;

internal static class QualityCalculatorFactory
{
    public static IQualityCalculator Create(Item item)
    {
        if (item.Name == "Aged Brie")
        {
            return new AgedBrieQualityCalculator();
        }
        if (item.Name != "Aged Brie"
            && item.Name != "Backstage passes to a TAFKAL80ETC concert"
            && item.Name != "Sulfuras, Hand of Ragnaros")
        {
            return new StandardItemQualityCalculator();
        }
        else
        {
            return new ZeroQualityIncreaseCalculator();
        }
    }
}