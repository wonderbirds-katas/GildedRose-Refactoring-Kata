namespace GildedRose;

internal class StandardItemQualityCalculator : IQualityCalculator
{
    public int CalculateQualityIncrease(int sellIn)
    {
        var result = -1;

        if (sellIn < 0)
        {
            result -= 1;
        }

        return result;
    }
}