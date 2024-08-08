namespace LynxPro.Models
{
    public static class StandardDateTimeFormats
    {
        public const string Full = "{0:G}";
        public const string Short = "{0:dd/MM HH:mm}"; // TODO: find a way to display this format based on culture
        public const string Date = "{0:d}";
        public const string Time = "{0:HH:mm:ss}";
    }
}