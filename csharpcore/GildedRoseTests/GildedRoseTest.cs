using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Theory(DisplayName = "For standard item, reduce sellIn by 1 ")]
    [MemberData(nameof(ItemsForWhichSellInShallDecreaseByOne))]
    public void GivenStandardItem_WhenUpdateQuality_ThenSellInDecreasesByOne(TestItem item)
    {
        var expectedSellIn = item.Item.SellIn - 1;

        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();

        items[0].SellIn.Should().Be(expectedSellIn);
    }

    public static TheoryData<TestItem> ItemsForWhichSellInShallDecreaseByOne() =>
        new()
        {
            new TestItem("foo", -5, 0, "sellIn = -5"),
            new TestItem("foo", -1, 0, "sellIn = -1"),
            new TestItem("foo", 0, 0, "sellIn = 0"),
            new TestItem("foo", 1, 0, "sellIn = 1"),
            new TestItem("foo", 5, 0, "sellIn = 5"),
        };

    public class TestItem
    {
        private readonly string _description;

        public Item Item { get; }

        public TestItem(string name, int sellIn, int quality, string description)
        {
            Item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            _description = description;
        }

        public override string ToString() => _description;
    }
}