namespace GildedRose;

internal static class QualityCalculatorFactory
{
    public static IQualityCalculator Create(Item item) =>
        item.Name switch
        {
            "Aged Brie" => new AgedBrieQualityCalculator(),
            "Backstage passes to a TAFKAL80ETC concert" => new ZeroQualityIncreaseCalculator(),
            "Sulfuras, Hand of Ragnaros" => new ZeroQualityIncreaseCalculator(),
            _ => new StandardItemQualityCalculator()
        };
}