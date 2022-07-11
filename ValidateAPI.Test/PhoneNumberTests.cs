using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ValidateAPI.Helpers;

namespace ValidateAPI.Test
{
    public class PhoneNumberTests
    {
        [Theory]
        [InlineData("48996887564")]
        [InlineData("+48776843904")]
        [InlineData("887403982")]
        public void ShouldCheckIsPhoneNumberValid(string phoneNumber)
        {
            var result = PhoneNumber.IsPhoneNumberValid(phoneNumber);
            Assert.True(result);
        }

        [Theory]
        [InlineData("557333jj54")]
        [InlineData("557334000000000000033")]
        [InlineData("")]
        [InlineData("> ")]
        public void ShouldCheckIsPhoneNumberNotValid(string phoneNumber)
        {
            var result = PhoneNumber.IsPhoneNumberValid(phoneNumber);
            Assert.False(result);
        }
    }
}