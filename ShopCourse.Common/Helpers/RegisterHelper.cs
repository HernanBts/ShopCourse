namespace ShopCourse.Common.Helpers
{
    using System;
    using System.Net.Mail;

    public static class RegisterHelper
    {
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                var mail = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }

}
