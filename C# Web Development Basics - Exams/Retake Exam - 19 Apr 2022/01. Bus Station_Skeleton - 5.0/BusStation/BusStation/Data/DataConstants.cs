namespace BusStation.Data
{
    public static class DataConstants
    {
        public class User
        {
            public const int UsernameMaxLength = 20;
            public const int PasswordMinLength = 5;

            public const int EmailMaxLength = 60;
            public const int EmailMinLength = 10;

            public const int PasswordMaxLength = 20;
            public const int PasswordMinLengt = 5;
        }

        public class Destination
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            public const int OriginMaxLength = 50;
            public const int OriginMinLength = 2;

            public const int DateTimeMaxLength = 30;
        }

        public class Ticket
        {
            public const int MaxPrice = 90;
            public const int MinPrice = 10;
        }
    }
}
