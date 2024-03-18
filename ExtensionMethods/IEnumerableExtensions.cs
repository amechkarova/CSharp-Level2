using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> IEnum) where T : IComparable<T>
        {
            dynamic result = 0;
            if(IEnum != null)
            {
                if(IEnum.Any())
                {
                    foreach (var item in IEnum)
                    {
                        result += item;
                    }
                    return result;
                }
                throw new ArgumentException("There are no elements");
            }

            throw new ArgumentNullException(nameof(IEnum));
        }

        public static T Product<T>(this IEnumerable<T> IEnum) where T : IComparable<T>
        {
            dynamic result = 1;
            if (IEnum != null)
            {
                if (IEnum.Any())
                {
                    foreach (var item in IEnum)
                    {
                        result *= item;
                    }
                    return result;
                }
                throw new ArgumentException("There are no elements");
            }

            throw new ArgumentNullException(nameof(IEnum));
        }

        public static T Min<T>(this IEnumerable<T> IEnum) where T : IComparable<T>
        {  
            if (IEnum != null)
            {
                if(IEnum.Any())
                {
                    dynamic minValue = IEnum.First();
                    foreach (var item in IEnum)
                    {
                        if (minValue.CompareTo(item) > 0)
                        {
                            minValue = item;
                        }
                    }
                    return minValue;  
                }
                throw new ArgumentException("There are no elements");
            }
            throw new ArgumentNullException(nameof(IEnum));
        }

        public static T Max<T>(this IEnumerable<T> IEnum) where T : IComparable<T>
        {
            if (IEnum != null)
            {
                if(IEnum.Any())
                {
                    dynamic maxValue = IEnum.First();
                    foreach (var item in IEnum)
                    {
                        if (maxValue.CompareTo(item) < 0)
                        {
                            maxValue = item;
                        }
                    }
                    return maxValue;
                }
                throw new ArgumentException("There are no elements");
            }

            throw new ArgumentNullException(nameof(IEnum));
        }

        public static double Average<T>(this IEnumerable<T> IEnum) where T : IComparable<T>
        {
            dynamic sum = 0;
            int count = 0;
            if (IEnum != null)
            {
               if(IEnum.Any())
                {
                    foreach (var item in IEnum)
                    {
                        sum += item;
                        count++;
                    }

                    return sum / (double)count;
                }
                throw new ArgumentException("There are no elements");
            }

            throw new ArgumentNullException(nameof(IEnum));
        }
    }
}
