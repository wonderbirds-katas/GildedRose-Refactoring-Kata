namespace GildedRose;

internal class AgedBrieQualityCalculator : IQualityCalculator
{
    public int CalculateQualityIncrease(int sellIn, int quality)
    {
        if (sellIn >= 0)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}