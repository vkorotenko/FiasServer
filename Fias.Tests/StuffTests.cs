using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;

namespace Fias.Tests
{
    public class StuffTests
    {
        [Fact]
        public void NumTest()
        {
            var test = "block(99)";
            var test2 = "block(99)block(99)block(-99)";

            var exp = ExtractIntFromString(test);
            var exp2 = ExtractIntFromString(test2);

            Assert.Single(exp);
            Assert.Equal(3,exp2.Length);
            Assert.Equal(-99,exp2[2]);
        }

        public int[] ExtractIntFromString(string src)
        {
            var result = new List<int>();
            var sb = new StringBuilder();
            var valid = new[] { '-', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            foreach (var ch in src)
            {
                if (valid.Contains(ch)) sb.Append(ch);
                else
                {
                    if (sb.Length <= 0) continue;
                    result.Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
            }
            return result.ToArray();
        }
    }
}
