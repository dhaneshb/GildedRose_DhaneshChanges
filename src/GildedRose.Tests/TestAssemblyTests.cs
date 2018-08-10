using Xunit;
using GildedRose.Console;
using System.Collections.Generic;
using System;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
        [Theory]
        [InlineData("Conjured Mana Cake", 3, 1)]
        public void UpdateQuality_Degrading_quality_and_Quality_isAlways_Postive(string pItemName, int pSellin, int pQuality)
        {
            var lItems = new List<Item> { new Item { Name = pItemName, SellIn = pSellin, Quality = pQuality } };
            Program lPgm = new Program();
            lPgm._Items = lItems;
            lPgm.UpdateQuality();
            if (lPgm._Items[0].Quality < 0) Assert.False(true); else Assert.True(true);
        }
        [Theory]
        [InlineData("Conjured Mana Cake", 3, 5)]
        public void UpdateQuality_Degrade_Quality_Twice_because_item_is_Conjured(string pItemName, int pSellin, int pQuality)
        {
            var lItems = new List<Item> { new Item { Name = pItemName, SellIn = pSellin, Quality = pQuality } };
            Program lPgm = new Program();
            lPgm._Items = lItems;
            lPgm.UpdateQuality();
            if (Math.Abs(pQuality - lPgm._Items[0].Quality) == 2) Assert.True(true); else Assert.False(true);
        }
    }
}
