using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public partial class GildedRoseUpdateQualityQualityTests
{
    [Theory(DisplayName = "For standard items, reduce quality by 1 ")]
    [MemberData(nameof(ItemsForWhichQualityShallDecreaseByOne))]
    public void GivenStandardItem_WhenUpdateQuality_ThenQualityDecreasesByOne(TestItem item)
    {
        var expectedQuality = item.Item.Quality - 1;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].Quality.Should().Be(expectedQuality);
    }

    public static TheoryData<TestItem> ItemsForWhichQualityShallDecreaseByOne() =>
        new()
        {
            new TestItem("foo", -5, 1),
            new TestItem("foo", -1, 1),
            new TestItem("foo", 0, 1),
            new TestItem("foo", 1, 1),
            new TestItem("foo", 5, 1),
        };
}