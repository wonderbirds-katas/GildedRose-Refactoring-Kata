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

        if (
            item.Name != "Aged Brie"
            && item.Name != "Backstage passes to a TAFKAL80ETC concert"
        )
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.Quality -= 1;
                }
            }
        }
        else
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;

                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.SellIn < 10)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }

                    if (item.SellIn < 5)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
                }
            }
        }

        if (item.SellIn < 0)
        {
            if (item.Name != "Aged Brie")
            {
                if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    item.Quality -= item.Quality;
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
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
