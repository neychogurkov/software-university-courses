namespace Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Telephony.Exceptions;

    public class Smartphone : ISmartphone
    {
        public string Call(string phoneNumber)
        {
            if (!this.ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string url)
        {
            if (!this.ValidateURL(url))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        private bool ValidatePhoneNumber(string phoneNumber) => phoneNumber.All(ch => char.IsDigit(ch));

        private bool ValidateURL(string url) => url.All(ch => !char.IsDigit(ch));
    }
}
