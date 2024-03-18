using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription<T>(this T enumeration) where T : Enum
        {
            if(typeof(T).IsEnum)
            {
                Type enumType = enumeration.GetType();
                FieldInfo fieldInfo = enumType.GetField(enumeration.ToString());
                if(fieldInfo != null)
                {
                    var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if(attributes != null && attributes.Length > 0)
                    {
                        return ((DescriptionAttribute)attributes[0]).Description;
                    }
                }
                throw new Exception("FiledInfo is null");
            }
            throw new ArgumentException("Type is not Enum");
        }

        public static string GetEnumName<T>(this int enumConst) where T : Enum
        {
            if (typeof(T).IsEnum)
            {
                foreach (int enumerationItem in Enum.GetValues(typeof(T)))
                {
                    if (enumConst == enumerationItem)
                    {
                        return Enum.GetName(typeof(T), enumConst);
                    }
                }
                throw new Exception("Invalid constant");
            }
            throw new ArgumentException("Type is not Enum");
        }
    }
}
