using System;
using System.Collections.Generic;
using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestDexteryVest()
        {
            var expectedValue = new List<ExpectedValues>
            {
                new ExpectedValues { Quality = 19, SellIn = 9 },
                new ExpectedValues { Quality = 18, SellIn = 8 },
                new ExpectedValues { Quality = 17, SellIn = 7 },
                new ExpectedValues { Quality = 16, SellIn = 6 },
                new ExpectedValues { Quality = 15, SellIn = 5 },
                new ExpectedValues { Quality = 14, SellIn = 4 },
                new ExpectedValues { Quality = 13, SellIn = 3 },
                new ExpectedValues { Quality = 12, SellIn = 2 },
                new ExpectedValues { Quality = 11, SellIn = 1 },
                new ExpectedValues { Quality = 10, SellIn = 0 },
                new ExpectedValues { Quality = 8, SellIn = -1 },
                new ExpectedValues { Quality = 6, SellIn = -2 },
                new ExpectedValues { Quality = 4, SellIn = -3 },
                new ExpectedValues { Quality = 2, SellIn = -4 },
                new ExpectedValues { Quality = 0, SellIn = -5 },
                new ExpectedValues { Quality = 0, SellIn = -6 },
            };

            RunUpdatesAndAssert(Program.DexteryVest, expectedValue);
        }

        [Fact]
        public void TestAgedBrie()
        {
            var expectedValues = new List<ExpectedValues>
            {
                new ExpectedValues { Quality = 1, SellIn = 1 },
                new ExpectedValues { Quality = 2, SellIn = 0 },
                new ExpectedValues { Quality = 4, SellIn = -1 },
                new ExpectedValues { Quality = 6, SellIn = -2 },
                new ExpectedValues { Quality = 8, SellIn = -3 },
                new ExpectedValues { Quality = 10, SellIn = -4 },
                new ExpectedValues { Quality = 12, SellIn = -5 },
                new ExpectedValues { Quality = 14, SellIn = -6 },
                new ExpectedValues { Quality = 16, SellIn = -7 },
                new ExpectedValues { Quality = 18, SellIn = -8 },
                new ExpectedValues { Quality = 20, SellIn = -9 },
                new ExpectedValues { Quality = 22, SellIn = -10 },
                new ExpectedValues { Quality = 24, SellIn = -11 },
                new ExpectedValues { Quality = 26, SellIn = -12 },
                new ExpectedValues { Quality = 28, SellIn = -13 },
                new ExpectedValues { Quality = 30, SellIn = -14 },
                new ExpectedValues { Quality = 32, SellIn = -15 },
                new ExpectedValues { Quality = 34, SellIn = -16 },
                new ExpectedValues { Quality = 36, SellIn = -17 },
                new ExpectedValues { Quality = 38, SellIn = -18 },
                new ExpectedValues { Quality = 40, SellIn = -19 },
                new ExpectedValues { Quality = 42, SellIn = -20 },
                new ExpectedValues { Quality = 44, SellIn = -21 },
                new ExpectedValues { Quality = 46, SellIn = -22 },
                new ExpectedValues { Quality = 48, SellIn = -23 },
                new ExpectedValues { Quality = 50, SellIn = -24 },
                new ExpectedValues { Quality = 50, SellIn = -25 },
            };

            RunUpdatesAndAssert(Program.AgedBrie, expectedValues);
        }

        [Fact]
        public void TestMongooseElixir()
        {
            var expectedValues = new List<ExpectedValues>
            {
                new ExpectedValues { Quality = 6, SellIn = 4 },
                new ExpectedValues { Quality = 5, SellIn = 3 },
                new ExpectedValues { Quality = 4, SellIn = 2 },
                new ExpectedValues { Quality = 3, SellIn = 1 },
                new ExpectedValues { Quality = 2, SellIn = 0 },
                new ExpectedValues { Quality = 0, SellIn = -1 },
                new ExpectedValues { Quality = 0, SellIn = -2 }
            };

            RunUpdatesAndAssert(Program.MongooseElixir, expectedValues);
        }

        private static void RunUpdatesAndAssert(Item updatee, IEnumerable<ExpectedValues> values)
        {
            var expectedName = updatee.Name;
            var app = new Program(new List<Item> { updatee });
            var updateStep = 1;

            foreach (var expected in values)
            {
                app.UpdateQuality();

                updatee.Name.ShouldBeEquivalentTo(expectedName, $"<Name on update step [{updateStep}]>");
                updatee.Quality.ShouldBeEquivalentTo(expected.Quality, $"<Quality on update step [{updateStep}]?");
                updatee.SellIn.ShouldBeEquivalentTo(expected.SellIn, $"<SellIn on update step [{updateStep}]>");

                ++updateStep;
            }
        }

        private class ExpectedValues
        {
            public int Quality;
            public int SellIn;
        }
    }
}