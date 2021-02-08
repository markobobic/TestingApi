namespace TestingAPI_s.ExtensionMethods
{
    public static class IntExtensions
    {
        public static int? TryParseNull(this string s)
        {
            int fallback;
            int? value;
            if (int.TryParse(s, out fallback))
            {
                value = fallback;
            }
            else
            {
                value = null;
            }
            return value;
        }
    }
}
