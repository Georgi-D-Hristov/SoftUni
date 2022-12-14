namespace FootballManager.Data.Models
{
    public static class DataConstants
    {

        public const int MinUsername = 5;
        public const int MaxUsername = 20;

        public const int EmailMaxLength = 60;
        public const int EmailMinLength = 10;

        public const int MinPassword = 5;
        public const int MaxPassword = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int FullNameMaxLength = 80;
        public const int FullNameMinLength = 5;

        public const byte PositionMaxLength = 20;
        public const byte PositionMinLength = 5;

        public const byte SpeedLimit = 10;
        public const byte EnduranceLimit = 10;

        public const int DescriptionMaxLength = 200;

    }
}
