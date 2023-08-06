using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void UpdateStandardItem()
    {
        var input = new Item {Name = "foo", SellIn = 0, Quality = 0};
        var items = new List<Item> {input};

        new GildedRose.GildedRose(items).UpdateQuality();
        
        var expected = new Item {Name = "foo", SellIn = -1, Quality = 0};
        items[0].Should().BeEquivalentTo(expected);
    }
}
