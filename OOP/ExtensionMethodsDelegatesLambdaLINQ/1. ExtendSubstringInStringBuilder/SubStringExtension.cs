using System;
using System.Text;

namespace _1.ExtendSubstringInStringBuilder
{
    public static class SubStringExtension
    {
        public static StringBuilder Substring(this StringBuilder stringBuilder, int index, int length)
        {
            if (index < 0 || length < 0)
            {
                throw new ArgumentOutOfRangeException("Arguments cannot be less than zero");
            } 
            else if (length == 0)
            {
                return new StringBuilder().Append(string.Empty);
            }
            else if (index + length > stringBuilder.Length)
            {
                throw new ArgumentOutOfRangeException("Cannot get elements out of the StringBuilder");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = index; i < index + length; i++)
                {
                    sb.Append(stringBuilder[i]);
                }
                return sb;
            }
        }
    }
}
