using System.Net.Mail;

namespace ValidateAPI.Helpers
{
    public static class Email
    {
        public static bool IsEmailValid(string email)
        {
            var valid = true;
            try
            {
                var emailAdress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }
            return valid;
        }
    }
}
