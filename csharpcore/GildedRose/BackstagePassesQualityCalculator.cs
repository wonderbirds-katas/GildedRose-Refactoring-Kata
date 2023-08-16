namespace GildedRose;

internal class BackstagePassesQualityCalculator : IQualityCalculator
{
    public int CalculateQualityIncrease(int sellIn, int quality)
    {
        var result = 1;

        if (sellIn < 10)
        {
            result++;
        }

        if (sellIn < 5)
        {
            result++;
        }

        if (sellIn < 0)
        {
            result = -quality;
        }

        return result;
    }
}