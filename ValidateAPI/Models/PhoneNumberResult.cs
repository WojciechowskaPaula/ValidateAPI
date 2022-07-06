namespace ValidateAPI.Models
{
    public class PhoneNumberResult
    {
        public bool IsValid { get; set; }
        public int CountryCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
