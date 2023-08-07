using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public class GildedRoseUpdateQualitySellInTests
{
    [Theory(DisplayName = "For standard items, reduce sellIn by 1 ")]
    [MemberData(nameof(ItemsForWhichSellInShallDecreaseByOne))]
    public void GivenStandardItem_WhenUpdateQuality_ThenSellInDecreasesByOne(TestItem item)
    {
        var expectedSellIn = item.Item.SellIn - 1;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].SellIn.Should().Be(expectedSellIn);
    }

    [Fact(DisplayName = "For legendary items, sellIn does not change")]
    public void GivenLegendaryItem_WhenUpdateQuality_ThenSellInDoesNotDecrease()
    {
        var item = new TestItem("Sulfuras, Hand of Ragnaros", 0, 80);
        var expectedSellIn = item.Item.SellIn;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].SellIn.Should().Be(expectedSellIn);
    }

    public static TheoryData<TestItem> ItemsForWhichSellInShallDecreaseByOne() =>
        new()
        {
            new TestItem("foo", -5, 0),
            new TestItem("foo", -1, 0),
            new TestItem("foo", 0, 0),
            new TestItem("foo", 1, 0),
            new TestItem("foo", 5, 0),
        };
}