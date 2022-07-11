namespace ValidateAPI.Helpers
{
    public class Length
    {
        public static bool IsLengthValid(string word, int length)
        {
            if (word.Length == length)
            {
                return true;
            }
            return false;
        }
    }
}
