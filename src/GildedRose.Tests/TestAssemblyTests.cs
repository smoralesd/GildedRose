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
        public void TestProgramConstruction()
        {
            var app = new Program(new List<Item>());
            app.Should().NotBeNull();
            app.UpdateQuality();
            true.Should().BeTrue();
        }

        [Fact]
        public void TestDexteryVest()
        {
            var baseDexteryVest = Program.DexteryVest;
            var dexteryVest = Program.DexteryVest;
            var app = new Program(new List<Item> { dexteryVest });
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
                new ExpectedValues { Quality = 0, SellIn = -7 },
                new ExpectedValues { Quality = 0, SellIn = -8 },
                new ExpectedValues { Quality = 0, SellIn = -9 },
                new ExpectedValues { Quality = 0, SellIn = -10 },
                new ExpectedValues { Quality = 0, SellIn = -11 },
                new ExpectedValues { Quality = 0, SellIn = -12 },
                new ExpectedValues { Quality = 0, SellIn = -13 },
                new ExpectedValues { Quality = 0, SellIn = -14 },
                new ExpectedValues { Quality = 0, SellIn = -15 },
                new ExpectedValues { Quality = 0, SellIn = -16 },
                new ExpectedValues { Quality = 0, SellIn = -17 },
                new ExpectedValues { Quality = 0, SellIn = -18 },
                new ExpectedValues { Quality = 0, SellIn = -19 },
                new ExpectedValues { Quality = 0, SellIn = -20 },
            };

            var updateStep = 1;
            foreach (var expected in expectedValue)
            {
                app.UpdateQuality();

                dexteryVest.Name.ShouldBeEquivalentTo(baseDexteryVest.Name, $"<Name on update step [{updateStep}]>");
                dexteryVest.Quality.ShouldBeEquivalentTo(expected.Quality, $"<Quality on update step [{updateStep}]?");
                dexteryVest.SellIn.ShouldBeEquivalentTo(expected.SellIn, $"<SellIn on update step [{updateStep}]>");

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