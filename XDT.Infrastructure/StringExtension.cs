using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XDT.Infrastructure
{
    public static class StringExtension
    {
        public static int ToInt32(this string source)
        {
            return source.ToInt32(0);
        }

        public static int ToInt32(this string source, int defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            int value;

            if (!int.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static int? ToNullableInt32(this string source)
        {
            return source.ToNullableInt32(null);
        }

        public static int? ToNullableInt32(this string source, int? defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;
            int? result = null;
            int value;
            result = int.TryParse(source, out value) ? value : (int?)null;
            return result;
        }

        public static long ToLong(this string source)
        {
            return source.ToLong(0);
        }

        public static long ToLong(this string source, long defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            long value;

            if (!long.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static short ToShort(this string source)
        {
            return source.ToShort(0);
        }

        public static short ToShort(this string source, short defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            short value;

            if (!short.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static decimal ToDecimal(this string source)
        {
            return source.ToDecimal(0);
        }

        public static decimal ToDecimal(this string source, decimal defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            decimal value;

            if (!decimal.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static decimal? ToNullableDecimal(this string source)
        {
            return source.ToNullableDecimal(null);
        }

        public static decimal? ToNullableDecimal(this string source, decimal? defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            decimal? result = null;
            decimal value;
            result = decimal.TryParse(source, out value) ? value : (decimal?)null;
            return result;
        }

        public static bool ToBoolean(this string source)
        {
            return source.ToBoolean(false);
        }

        public static bool ToBoolean(this string source, bool defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            bool value;

            if (!bool.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static bool? ToNullableBoolean(this string source)
        {
            return source.ToNullableBoolean(null);
        }

        public static bool? ToNullableBoolean(this string source, bool? defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            bool? result = null;
            bool value;
            result = bool.TryParse(source, out value) ? value : (bool?)null;
            return result;
        }

        public static byte ToByte(this string source)
        {
            return source.ToByte(0);
        }

        public static byte ToByte(this string source, byte defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            byte value;

            if (!byte.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static byte? ToNullableByte(this string source)
        {
            return source.ToNullableByte(null);
        }

        public static byte? ToNullableByte(this string source, byte? defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            byte? result = null;
            byte value;
            result = byte.TryParse(source, out value) ? value : (byte?)null;
            return result;
        }

        public static DateTime ToDateTime(this string source)
        {
            return source.ToDateTime(DateTime.MinValue);
        }

        public static DateTime ToDateTime(this string source, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            DateTime value;

            if (!DateTime.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static DateTime? ToNullableDateTime(this string source)
        {
            return source.ToNullableDateTime(null);
        }
        public static DateTime? ToNullableDateTime(this string source, DateTime? defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;
            DateTime? result = null;
            DateTime value;
            result = DateTime.TryParse(source, out value) ? value : (DateTime?)null;
            return result;
        }

        public static DateTime? ToNullableDateTime(this string source, DateTime? defaultValue, string timeStyle)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;
            DateTime? result = null;
            DateTime value;
            result = DateTime.TryParseExact(source, timeStyle, System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None, out value) ? value : (DateTime?)null;
            return result;
        }

        public static double ToDouble(this string source)
        {
            return source.ToDouble(0);
        }

        public static double ToDouble(this string source, double defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            double value;

            if (!double.TryParse(source, out value))
                value = defaultValue;

            return value;
        }

        public static double? ToNullableDouble(this string source)
        {
            return source.ToNullableDouble(null);
        }

        public static double? ToNullableDouble(this string source, double? defaultValue)
        {
            if (string.IsNullOrEmpty(source))
                return defaultValue;

            double? result = null;
            double value;
            result = double.TryParse(source, out value) ? value : (double?)null;
            return result;
        }

        public static byte[] ToBuffer(this string source)
        {
            return source.ToBuffer("utf-8");
        }

        public static byte[] ToBuffer(this string source, string encoding)
        {
            return System.Text.Encoding.GetEncoding(encoding).GetBytes(source);
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }
    }



}

