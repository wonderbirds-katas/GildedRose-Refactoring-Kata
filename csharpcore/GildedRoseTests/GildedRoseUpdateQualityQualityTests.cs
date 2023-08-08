using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public partial class GildedRoseUpdateQualityQualityTests
{
    [Theory(DisplayName = "For standard items, reduce quality by 1 ")]
    [MemberData(nameof(ItemsWithDecayingQuality))]
    public void GivenStandardItem_WhenUpdateQuality_ThenQualityDecreasesByOne(TestItem item)
    {
        var expectedQuality = item.Item.Quality - 1;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Aged Brie, increase quality by 1")]
    public void GivenAgedBrie_WhenUpdateQuality_ThenQualityIncreasesByOne()
    {
        var item = new TestItem("Aged Brie", 1, 10);
        var expectedQuality = item.Item.Quality + 1;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Theory(DisplayName = "Items with increasing quality never exceed quality of 50")]
    [MemberData(nameof(ItemsWithIncreasingQualityAtMaximum))]
    public void GivenItemIncreasingInQuality_WhenUpdateQuality_ThenQualityDoesNotExceed50(TestItem item)
    {
        const int expectedQuality = 50;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    public static TheoryData<TestItem> ItemsWithDecayingQuality() =>
        new()
        {
            new TestItem("Pizza", -5, 1),
            new TestItem("Pizza", -1, 1),
            new TestItem("Pizza", 0, 1),
            new TestItem("Pizza", 1, 1),
            new TestItem("Pizza", 5, 1),
        };

    public static TheoryData<TestItem> ItemsWithIncreasingQualityAtMaximum() =>
        new()
        {
            new TestItem("Aged Brie", 10, 50),
            new TestItem("Backstage passes to a TAFKAL80ETC concert", 5, 50),
        };
}