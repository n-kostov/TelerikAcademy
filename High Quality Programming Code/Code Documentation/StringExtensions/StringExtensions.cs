// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="TelerikAcademy">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
// -

namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Contain extension methods defined for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Return the MD5 hash of a string.
        /// </summary>
        /// <param name="input">The string whose hash the method computes.</param>
        /// <returns>The 128-bit hash of the input string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Check if the string can be interpreted as the <see cref="System.Boolean"/>
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <returns>True if the string can be converted to the <see cref="System.Boolean"/> "true".</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Convert the input string to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The string value as <see cref="System.Int16"/></returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Convert the input string to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The string value as <see cref="System.Int32"/></returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Convert the input string to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The string value as <see cref="System.Int64"/>.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Convert the input string to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The string value as <see cref="System.DateTime"/>.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Convert the first letter to uppercase.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The input string with capital first letter. </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Get the substring between <paramref name="startString"/>
        /// and <paramref name="endString"/> starting from <paramref name="startFrom"/> index.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="startString">The left delimiter of the result string.</param>
        /// <param name="endString">The right delimiter of the result string.</param>
        /// <param name="startFrom">The start position of the search.</param>
        /// <returns>The substring that is between <paramref name="startString"/>
        /// and <paramref name="endString"/> searching from <paramref name="startFrom"/> or System.String.Empty
        /// if <paramref name="startString"/> or <paramref name="endString"/> don't occur within the input string.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replace all Cyrillic letters in a string with their Latin counterparts.
        /// </summary>
        /// <param name="input">This input string.</param>
        /// <returns>A string in which all instances of Cyrillic letters are replaced with
        /// their Latin equivalents.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };

            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Replace all Latin letters in a string with their Cyrillic counterparts
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A string in which all instances of Latin letters are replaced with
        /// their Cyrillic equivalents.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Convert the Cyrillic letters to their Latin equivalents
        /// and remove all non-alphanumeric characters (excluding the period ".") in a username.
        /// </summary>
        /// <param name="input">The input username.</param>
        /// <returns>A valid username.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Convert the Cyrillic letters to their Latin equivalents,
        /// spaces to hyphens and remove all non-alphanumeric characters
        /// (excluding the period "." and hyphen "-") in the input filename.</summary>
        /// <param name="input">The input filename.</param>
        /// <returns>A valid latin filename. </returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns a substring of this instance which starts from the beginning and
        /// whose length is the lesser of the string's length or <paramref name="charsCount"/>.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="charsCount">The number of characters to get from the string.</param>
        /// <returns>A string containing the first <paramref name="charsCount"/> characters of the input string
        /// if available or the whole input string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Extract the extension from the filename.
        /// </summary>
        /// <param name="fileName">The input filename.</param>
        /// <returns>Get the filename's extension.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Convert the file extension to the corresponding content type for the specified file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns>The content type.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convert array of characters into array of bytes.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A byte array containing the specified set of characters.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
