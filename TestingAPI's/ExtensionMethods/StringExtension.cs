﻿namespace TestingAPI_s.ExtensionMethods
{
    public static class StringExtension
    {
        public static string GetLastCharacters(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        public static string RemoveLastCharacters(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
           return source.Remove(source.Length - tail_length, tail_length);
        }
    }
}
