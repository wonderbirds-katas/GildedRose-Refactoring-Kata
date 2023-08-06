using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Theory]
    [InlineData("foo", 0, 0, -1, 0)]
    [InlineData("foo", 10, 0, 9, 0)]
    public void UpdateStandardItem(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
    {
        var input = new Item {Name = name, SellIn = sellIn, Quality = quality};
        var items = new List<Item> {input};

        new GildedRose.GildedRose(items).UpdateQuality();
        
        var expected = new Item {Name = "foo", SellIn = expectedSellIn, Quality = expectedQuality};
        items[0].Should().BeEquivalentTo(expected);
    }
}
