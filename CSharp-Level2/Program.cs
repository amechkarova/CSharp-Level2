using System.Runtime.Serialization;

namespace CSharp_Level2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Program that counts in a given array of double values the number of occurences of each value
            double[] array = {3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Dictionary<double, int> keyValuePairs = new Dictionary<double, int>();
            for (int i = 0; i < array.Length; i++)
            {
                int occurrences = array.Count(x => x == array[i]);
                if (!keyValuePairs.ContainsKey(array[i]))
                {
                    keyValuePairs.Add(array[i], occurrences);
                }
            }

            foreach(KeyValuePair<double, int> pair in keyValuePairs)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }

            
            HashTableStructure<string, int> ht = new HashTableStructure<string, int>();
            ht.Add("alabala", 17);
            ht.Add("abracadabra", 19);
            Console.WriteLine($"Count: {ht.Count}");
            int value = ht["alabala"];
            Console.WriteLine(value);
            ht.Remove("alabala");
            Console.WriteLine($"Count: {ht.Count}");
            List<string> keys = ht.Keys();
            foreach(var key in keys)
            {
                Console.WriteLine(key);
            }
        }
    }
}
