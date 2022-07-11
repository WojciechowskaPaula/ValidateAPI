using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAPI.Helpers;

namespace ValidateAPI.Test
{
    public class LengthTest
    {
        [Theory]
        [InlineData("notes", 5)]
        [InlineData("pillow", 6)]
        public void CheckIsWordLengthMatchDefaultLength(string word, int length)
        {
            var result = Length.IsLengthValid(word, length);
            Assert.True(result);
        }

        [Theory]
        [InlineData("notes", 3)]
        [InlineData("pillow", 2)]
        public void CheckIsWordLengthNotMatchDefaultLength(string word, int length)
        {
            var result = Length.IsLengthValid(word, length);
            Assert.False(result);
        }
    }
}
