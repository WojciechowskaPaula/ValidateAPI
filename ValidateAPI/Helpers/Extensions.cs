namespace ValidateAPI.Helpers
{
    public static class Extensions
    {
        public static bool CheckIsANumber(this string phoneNum)
        {
            for (int i = 0; i < phoneNum.Length; i++)
            {
                if (!Char.IsDigit(phoneNum[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
