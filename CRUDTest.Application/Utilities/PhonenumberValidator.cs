using PhoneNumbers;

namespace CRUDTest.Application.Utilities
{
    public static class PhonenumberValidator
    {
        public static bool Validate(string number)
        {
            bool result = false;
            try
            {
                if (string.IsNullOrWhiteSpace(number))
                    return false;

                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                string countryCode = "NL"; //Netherlands
                PhoneNumber phoneNumber = phoneUtil.Parse(number, countryCode);
                if (phoneUtil.IsValidNumber(phoneNumber)) // returns true for valid netherlands number
                {
                    if (phoneUtil.GetNumberType(phoneNumber) == PhoneNumberType.MOBILE) // return true if it is mobile number
                        result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
