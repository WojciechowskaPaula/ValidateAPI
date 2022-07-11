using System.Net.Mail;
using ValidateAPI.Helpers;
using Xunit;

namespace ValidateAPI.Test
{
    public class EmailTest
    {
        [Fact]
        public void ShouldCheckIsEmailValid()
        {
            string email1 = "test@gmail.com";
            bool result = Email.IsEmailValid(email1);
            Assert.True(result, "Email1 should be valid");
        }

        [Fact]
        public void ShouldCheckIsEmailNotValid()
        {
            string email = "test24";
            bool result = Email.IsEmailValid(email);
            Assert.False(result, "Email should be not valid");
        }

        [Theory]
        [InlineData("test.test@test.pl")]
        [InlineData("test@test.com")]
        public void ShouldCheckIsEmailValid2(string email)
        {
            bool result = Email.IsEmailValid(email);
            Assert.True(result);
        }

        [Theory]
        [InlineData("test1.com")]
        [InlineData("@t.com")]
        public void ShouldCheckIsEmailNotValid2(string email)
        {
            bool result = Email.IsEmailValid(email);
            Assert.False(result);
        }
    }
}