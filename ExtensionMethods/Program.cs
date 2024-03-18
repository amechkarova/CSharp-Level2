using System.Text;

namespace ExtensionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("Aneliya");
            StringBuilder sb2 = sb.SubString(0, 3);
            Console.WriteLine(sb2);

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 1 };
            int[] array = {1, 2, 3};

            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Product: {numbers.Product()}");
            Console.WriteLine($"Min: {numbers.Min()}");
            Console.WriteLine($"Max: {numbers.Max()}");
            Console.WriteLine($"Average: {numbers.Average()}");
            Console.WriteLine();
            Console.WriteLine($"Sum: {array.Sum()}");
            Console.WriteLine($"Product: {array.Product()}");
            Console.WriteLine($"Min: {array.Min()}");
            Console.WriteLine($"Max: {array.Max()}");
            Console.WriteLine($"Average: {array.Average()}");

            ColorsEnum color = ColorsEnum.DeepRed;
            var colorEnumDescription = color.GetEnumDescription();
            Console.WriteLine(colorEnumDescription);

            int enumConst = 2;
            string enumName = enumConst.GetEnumName<ColorsEnum>();
            Console.WriteLine(enumName);

        }
    }
}
