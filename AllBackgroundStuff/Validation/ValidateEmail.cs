using System.ComponentModel.DataAnnotations;

namespace AllBackgroundStuff
{
    public class ValidateEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email == null)
                return false;

            return email.Contains("@gmail.com");
        }
    }
}
