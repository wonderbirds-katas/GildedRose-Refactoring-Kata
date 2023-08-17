namespace GildedRose;

internal static class QualityCalculatorFactory
{
    public static IQualityCalculator Create(Item item)
    {
        switch (item.Name)
        {
            case ItemNames.AgedBrie: // Update Obsidian note after this change
                return new AgedBrieQualityCalculator();
            case "Backstage passes to a TAFKAL80ETC concert":
                return new BackstagePassesQualityCalculator();
            case "Sulfuras, Hand of Ragnaros":
                return new LegendaryItemQualityCalculator();
            default:
                return new StandardItemQualityCalculator();
        }
    }
}