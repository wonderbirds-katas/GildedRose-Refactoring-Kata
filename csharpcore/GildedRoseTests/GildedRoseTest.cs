using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose;

namespace GildedRoseTests;

public class GildedRoseTest
{
    public class TestItem {
        public Item Item { get; set; }
        public string Description { get; set; }
        public override string ToString() => Description;
    }
    
    public static TheoryData<TestItem> ItemsForWhichSellInShallDecreaseByOne()
    {
        var data = new TheoryData<TestItem>();
        data.Add(new TestItem
        {
            Item = new Item{Name = "foo", SellIn = -5, Quality = 0},
            Description = "negative sellin"
        });
        return data;
    }
    
    [Theory(DisplayName = "For standard item, reduce sellin by 1")]
    [MemberData(nameof(ItemsForWhichSellInShallDecreaseByOne))]
    public void GivenStandardItem_WhenUpdateQuality_ThenSellInDecreasesByOne(TestItem item)
    {
        var expectedSellIn = item.Item.SellIn - 1;
        
        var items = new List<Item> {item.Item};
        new GildedRose.GildedRose(items).UpdateQuality();
        
        items[0].SellIn.Should().Be(expectedSellIn);
    }
}