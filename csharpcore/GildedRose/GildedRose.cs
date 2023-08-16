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
        
        UpdateQualityForStandardItem(item);

        qualityIncrease += UpdateQualityForBackstagePasses(item);

        qualityIncrease += UpdateQualityForAgedBrie(item);

        IncreaseQualityForItem(item, qualityIncrease);
    }

    private static void IncreaseQualityForItem(Item item, int qualityIncrease)
    {
        item.Quality = Math.Min(50, item.Quality + qualityIncrease);
    }

    private static int UpdateQualityForAgedBrie(Item item)
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

    private static int UpdateQualityForBackstagePasses(Item item)
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

    private static void UpdateQualityForStandardItem(Item item)
    {
        if (
            item.Name != "Aged Brie"
            && item.Name != "Backstage passes to a TAFKAL80ETC concert"
            && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros"
        )
        {
            item.Quality -= 1;
        }

        if (item.Name != "Aged Brie" && item.SellIn < 0 && item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.Quality -= 1;
        }
    }

    private static void UpdateSellInForItem(Item item)
    {
        if (item.Name != "Sulfuras, Hand of Ragnaros")
        {
            item.SellIn -= 1;
        }
    }
}
