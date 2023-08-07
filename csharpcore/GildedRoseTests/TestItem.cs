using GildedRose;

namespace GildedRoseTests;

public class TestItem
{
    public Item Item { get; }

    public TestItem(string name, int sellIn, int quality)
    {
        Item = new Item {Name = name, SellIn = sellIn, Quality = quality};
    }

    public override string ToString() => $"quality: {Item.Quality}, sellIn: {Item.SellIn}";
}
