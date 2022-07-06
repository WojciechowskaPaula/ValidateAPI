namespace ValidateAPI.Helpers
{
    public class PhoneNumber
    {
        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            phoneNumber = String.Concat(phoneNumber.Where(c => !Char.IsWhiteSpace(c)));
            if ((phoneNumber.StartsWith("+48") || phoneNumber.StartsWith("048")) && phoneNumber.Length == 12)
            {
                var checkOnlyDigits = phoneNumber.Substring(3);
                var result = checkOnlyDigits.CheckIsANumber();
                return result;
            }

            else if (phoneNumber.Length == 9)
            {
                var result = phoneNumber.CheckIsANumber();
                return result;
            }

            else if (phoneNumber.StartsWith("48") && phoneNumber.Length == 11)
            {
                var checkOnlyDigits = phoneNumber.Substring(2);
                var result = phoneNumber.CheckIsANumber();
                return result;
            }
            return false;
        }
    }
}
