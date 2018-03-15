using System;
using System.Collections.Generic;

namespace CookingSchool.ExtensionMethods
{
    public static class TruncateToWholeWords
    {
        public static string Truncate(this string text)
        {
            if(text.Length < 100)
            {
                return text;
            }
            if(text == "")
            {
                return "Przepis nie posiada Opisu. Dodaj go!!!";
            }
            var subString = text.Substring(0, Math.Min(text.Length, 150));

            var lastCharIndex = subString.Length - 1;

            while (subString[lastCharIndex] != ' ')
            {
                subString = subString.Remove(lastCharIndex, 1);
                lastCharIndex--;
            }

            subString = subString.Remove(lastCharIndex, 1);
            lastCharIndex--;

            var endingCharacters = new List<char>{'.', ',', '&', '-', '?', ';', '!'};

            if (endingCharacters.Contains(subString[lastCharIndex]))
            {
                subString = subString.Remove(lastCharIndex, 1);
            }

            return subString + "...";
        }

        public static string FirstToUpperCase( this string text)
        {
            if (text == "")
            {
                return "Podaj frazę do wyszkunia";
            }

            return char.ToUpper(text[0]) + text.Substring(1).ToLower();
        }
    }
}