namespace Telephony.Exceptions
{
    using System;

    public class InvalidPhoneNumberException : Exception
    {
        private const string DefaultMessage = "Invalid number!";

        public InvalidPhoneNumberException()
            : base(DefaultMessage)
        {

        }

        public InvalidPhoneNumberException(string message)
            : base(message)
        {

        }
    }
}
