namespace LynxPro.Models
{
    public static class StandardPhoneNoFormats
    {
        public const string Default = @"^(\+?)(?![0| ]+$)[\d ]+$";
        public const string DefaultOrZeroes = @"^(\+?)(?![0| ]+$)[\d ]+$|^(0{4})$";
        public const string MultiWithSemicolon = @"^((^([\d|+])[\d ]+))(;([\d|+])[\d ]+)*$";
    }
}
