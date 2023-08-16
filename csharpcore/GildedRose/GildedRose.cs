using System;
using System.Collections.Generic;

namespace GildedRose;

public class GildedRose
{
    readonly IList<Item> _items;

    public GildedRose(IList<Item> items)
    {
        _items = items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < _items.Count; i++)
        {
            UpdateQualityForItem(_items[i]);
        }
    }

    private void UpdateQualityForItem(Item item)
    {
        UpdateSellInForItem(item);

        var qualityIncrease = 0;
        
        var calculator = QualityCalculatorFactory.Create(item);

        qualityIncrease += calculator.CalculateQualityIncrease(item.SellIn);
        
        qualityIncrease += CalculateQualityIncreaseForBackstagePasses(item);

        qualityIncrease += CalculateQualityIncreaseForAgedBrie(item);

        IncreaseQualityForItem(item, qualityIncrease);
    }

    private static int CalculateQualityIncreaseForBackstagePasses(Item item)
    {
        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            return 0;
        }

        var result = 1;

        if (item.SellIn < 10)
        {
            result++;
        }

        if (item.SellIn < 5)
        {
            result++;
        }

        if (item.SellIn < 0)
        {
            result = -item.Quality;
        }

        return result;
    }

    private static int CalculateQualityIncreaseForAgedBrie(Item item)
    {
        if (item.Name != "Aged Brie")
        {
            return 0;
        }

        if (item.SellIn >= 0)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private static void IncreaseQualityForItem(Item item, int qualityIncrease)
    {
        item.Quality = Math.Clamp(item.Quality + qualityIncrease, 0, 50);
    }

    private static void UpdateSellInForItem(Item item)
    {
        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn -= 1;
        }
    }
}