using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public class GildedRoseUpdateQualityQualityTests
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";

    [Theory(DisplayName = "For standard items, reduce quality by 1 ")]
    [MemberData(nameof(ItemsWithQualityReducedByOne))]
    public void GivenStandardItem_WhenUpdateQuality_ThenQualityDecreasesByOne(TestItem item)
    {
        var expectedQuality = item.Item.Quality - 1;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Theory(DisplayName = "For standard items with sellIn 0, reduce quality by 2")]
    [MemberData(nameof(ItemsWithQualityReducedByTwo))]
    public void GivenStandardItemWithSellInZero_WhenUpdateQuality_ThenQualityDecreasesByTwo(
        TestItem item
    )
    {
        var expectedQuality = item.Item.Quality - 2;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Aged Brie, increase quality by 1")]
    public void GivenAgedBrie_WhenUpdateQuality_ThenQualityIncreasesByOne()
    {
        var item = new TestItem(AgedBrie, 1, 10);
        var expectedQuality = item.Item.Quality + 1;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Aged Brie with sellIn 0, increase quality by 2")]
    public void GivenAgedBrieWithSellInZero_WhenUpdateQuality_ThenQualityIncreasesByTwo()
    {
        var item = new TestItem(AgedBrie, 0, 10);
        var expectedQuality = item.Item.Quality + 2;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Backstage Passes with sellIn greater 10, increase quality by 1")]
    public void GivenBackstagePassesWithSellInGreaterThan10_WhenUpdateQuality_ThenQualityIncreasesByOne()
    {
        var item = new TestItem(BackstagePasses, 11, 10);
        var expectedQuality = item.Item.Quality + 1;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Backstage Passes with sellIn less than 10, increase quality by 2")]
    public void GivenBackstagePassesWithSellInLessThan10_WhenUpdateQuality_ThenQualityIncreasesByTwo()
    {
        var item = new TestItem(BackstagePasses, 9, 10);
        var expectedQuality = item.Item.Quality + 2;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Backstage Passes with sellIn less than 5, increase quality by 3")]
    public void GivenBackstagePassesWithSellInLessThan5_WhenUpdateQuality_ThenQualityIncreasesByThree()
    {
        var item = new TestItem(BackstagePasses, 4, 10);
        var expectedQuality = item.Item.Quality + 3;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Fact(DisplayName = "For Backstage Passes with sellIn less than 0, set quality to 0")]
    public void GivenBackstagePassesWithSellInLessThan0_WhenUpdateQuality_ThenQualityIsZero()
    {
        var item = new TestItem(BackstagePasses, -1, 10);
        var expectedQuality = 0;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Theory(DisplayName = "Items with increasing quality never exceed quality of 50")]
    [MemberData(nameof(ItemsWithIncreasingQualityAtMaximum))]
    public void GivenItemIncreasingInQuality_WhenUpdateQuality_ThenQualityDoesNotExceed50(
        TestItem item
    )
    {
        const int expectedQuality = 50;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    [Theory(DisplayName = "Items with decreasing quality never go below 0")]
    [MemberData(nameof(ItemsWithDecreasingQualityAtMinimum))]
    public void GivenItemDecreasingInQuality_WhenUpdateQuality_ThenQualityDoesNotGoBelow0(
        TestItem item
    )
    {
        const int expectedQuality = 0;

        var items = new List<Item> { item.Item };
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    public static TheoryData<TestItem> ItemsWithQualityReducedByOne() =>
        new()
        {
            new TestItem("Pizza", -5, 1),
            new TestItem("Pizza", -1, 1),
            new TestItem("Pizza", 0, 1),
            new TestItem("Pizza", 1, 1),
            new TestItem("Pizza", 5, 1),
        };

    public static TheoryData<TestItem> ItemsWithQualityReducedByTwo() =>
        new() { new TestItem("Pizza", 0, 5), new TestItem("Pizza", -1, 5), };

    public static TheoryData<TestItem> ItemsWithIncreasingQualityAtMaximum() =>
        new() { new TestItem(AgedBrie, 10, 50), new TestItem(BackstagePasses, 5, 50), };

    public static TheoryData<TestItem> ItemsWithDecreasingQualityAtMinimum() =>
        new()
        {
            new TestItem("Pizza", 1, 1),
            new TestItem("Pizza", 0, 0),
            new TestItem("Pizza", -1, 0),
        };
}
