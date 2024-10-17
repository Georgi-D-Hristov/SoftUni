namespace SeminarHub.Common
{
    public static class ValidationConstants
    {
        public static class Category
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 3;
        }

        public static class Seminar
        {
            public const int TopicMaxLength = 100;
            public const int TopicMinLength = 3;

            public const int LecturerMaxLength = 60;
            public const int LecturerMinLength = 5;

            public const int DetailsMaxLength = 500;
            public const int DetailsMinLength = 10;

            public const string DateAndTimePattern = "dd/MM/yyyy HH:mm";

            public const int DurationMaxLength = 180;
            public const int DurationMinLength = 30;
        }
    }
}
