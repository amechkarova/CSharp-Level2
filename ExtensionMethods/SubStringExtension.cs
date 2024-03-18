using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class SubStringExtension
    {
        public static StringBuilder SubString(this StringBuilder sb, int index, int length)
        {
            if(index < 0) throw new ArgumentOutOfRangeException("index");
            if(length < 0) throw new ArgumentOutOfRangeException("length");
            if(index + length > sb.Length) throw new ArgumentOutOfRangeException("position not within this instance");

            StringBuilder subStringBuilder = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                subStringBuilder.Append(sb[index + i]);
            }

            return subStringBuilder;
        }
    }
}
