namespace ValidateAPI.Helpers
{
    public class Lenght
    {
        public static bool IsLengthValid(string word)
        {
            var length = 6;
            if (word.Length == 6)
            {
                return true;
            }
            return false;
        }
    }
}
