namespace SMS.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DataConstants
    {
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        public const string EmailValidationPattern = @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

        public const int ProductNameMaxLength = 20;
        public const int ProductNameMinLength = 4;

        public const double PriceMinValue = 0.05;
        public const double PriceMaxValue = 1000;
    }
}
