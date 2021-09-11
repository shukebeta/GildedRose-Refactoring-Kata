using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRose;

namespace GildedRoseTests
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();
            Approvals.Verify(output);
        }

        private string DoUpdate(string name, int sellIn, int quality)
        {
            // do the update here
            return string.Empty;
        }
    }
}
