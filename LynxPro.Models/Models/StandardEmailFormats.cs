namespace LynxPro.Models
{
    public static class StandardEmailFormats
    {
        public const string Default = @"\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*";
        public const string MultiWithSemicolon = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*([;]\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)*";
    }
}