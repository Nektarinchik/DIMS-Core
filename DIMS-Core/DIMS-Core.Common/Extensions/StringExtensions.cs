namespace DIMS_Core.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNull(this string value)
        {
            return value is null;
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string Format(this string value, params object[] args)
        {
            return string.Format(value, args);
        }
    }
}