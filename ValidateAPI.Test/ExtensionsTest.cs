using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAPI.Helpers;

namespace ValidateAPI.Test
{
    public class ExtensionsTest
    {
        [Fact]
        public void Should_ReturnTrueWhenCharIsADigit()
        {
            string phoneNum = "223222122";
            var result = phoneNum.CheckIsANumber();
            Assert.True(result);
        }
        
        [Theory]
        [InlineData("98878oop")]
        [InlineData("443434343434344566!!")]
        [InlineData(" ")]
        [InlineData("e")]
        public void Should_ReturnFalseWhenPhoneNumberIsNotValid(string phoneNumber)
        {
            var result = phoneNumber.CheckIsANumber();
            Assert.False(result);
        }
    }
}
