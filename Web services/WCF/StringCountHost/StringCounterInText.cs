using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StringCountHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StringCounterInText" in both code and config file together.
    public class StringCounterInText : IStringCounterInText
    {
        public int CountOccurrance(string text, string str)
        {
            int count = 0;
            int index = text.IndexOf(str);
            while (index != -1)
            {
                count++;
                index = text.IndexOf(str, index + 1);
            }

            return count;
        }
    }
}
