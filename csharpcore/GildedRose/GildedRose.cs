﻿using System.Collections.Generic;

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

        UpdateQualityForStandardItem(item);

        UpdateQualityForBackstagePasses(item);

        UpdateQualityForAgedBrie(item);
    }

    private static void UpdateQualityForAgedBrie(Item item)
    {
        if (item.Name == "Aged Brie" && item.Quality < 50)
        {
            item.Quality += 1;
        }

        if (item.Name == "Aged Brie" && item.SellIn < 0 && item.Quality < 50)
        {
            item.Quality += 1;
        }
    }

    private static void UpdateQualityForBackstagePasses(Item item)
    {
        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
        {
            return;
        }
        
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        if (item.SellIn < 10 && item.Quality < 50)
        {
            item.Quality += 1;
        }

        if (item.SellIn < 5 && item.Quality < 50)
        {
            item.Quality += 1;
        }

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
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
