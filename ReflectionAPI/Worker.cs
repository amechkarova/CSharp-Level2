using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAPI
{
    public class Worker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName {  get; set; }
        public int Age { get; set; }

        public Worker(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void GetCharacteristics(bool getFullName)
        {
            if(getFullName)
            {
                Console.WriteLine(FullName);
            }
            Console.WriteLine(FirstName + " " + LastName);
            Console.WriteLine(Age);
        }
    }
}
