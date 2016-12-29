using System.Collections.Generic;
using FluentAssertions;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            var app = new Program()
            {
                Items = new List<Item>()
            };
            app.Should().NotBeNull();
            app.UpdateQuality();
            true.Should().BeTrue();
        }
    }
}