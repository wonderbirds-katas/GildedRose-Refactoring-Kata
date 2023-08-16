namespace GildedRose;

internal static class QualityCalculatorFactory
{
    public static IQualityCalculator Create(Item item)
    {
        if (item.Name == "Aged Brie"
            || item.Name == "Backstage passes to a TAFKAL80ETC concert"
            || item.Name == "Sulfuras, Hand of Ragnaros")
        {
            return new StandardItemQualityCalculator(item);
        }
        else
        {
            return new StandardItemQualityCalculator(item);
        }
    }
}