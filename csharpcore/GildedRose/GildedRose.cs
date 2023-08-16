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

        qualityIncrease += calculator.CalculateQualityIncrease(item.SellIn, item.Quality);
        
        IncreaseQualityForItem(item, qualityIncrease);
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