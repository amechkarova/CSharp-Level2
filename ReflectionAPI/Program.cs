using System.Reflection;

namespace ReflectionAPI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine($"Assembly Name: {assembly.GetName().Name}");
            Console.WriteLine($"Version: {assembly.GetName().Version}");

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var nspace = type.Namespace;
                if ( nspace.StartsWith("Refl") )
                {
                    Console.WriteLine(@"Type name: {0}", type.Name);
                }
            }


            //exercise 2
            Worker workerInstance = new Worker("aneliya", "mechkarova", 27);
            Type worker = workerInstance.GetType();
            PropertyInfo fullNameProperty = worker.GetProperty("FullName");
            fullNameProperty.SetValue(workerInstance, "Aneliya Emilova Mechkarova");
            Console.WriteLine(workerInstance.FullName);

            //exercise 3
            MethodInfo gethCharacteristicsMethod = worker.GetMethod("GetCharacteristics");
            gethCharacteristicsMethod.Invoke(workerInstance, new object[] { true });

            //foreach (var type in types)
            //{
            //    Console.WriteLine($"{type.FullName} has {type.GetProperties()} properties");
            //}

            //Type workerType = typeof(Worker);
            //MemberInfo[] membersMetaData = workerType.GetMembers();
            //foreach (MemberInfo member in membersMetaData)
            //{
            //    Console.WriteLine($"{member.MemberType} {member.Name}");
            //}
            //FieldInfo[] fieldInfo = workerType.GetFields();
            //foreach (FieldInfo field in fieldInfo)
            //{
            //    Console.WriteLine($"{field.Name} {field.FieldType}");
            //}

            //var propertyInfos = workerType.GetProperties();
            //foreach (var propertyInfo in propertyInfos)
            //{
            //    Console.Write(propertyInfo.Name);
            //    var accessors = propertyInfo.GetAccessors();
            //    foreach (var accessor in accessors)
            //        Console.Write(accessor.Name);
            //}

            //MethodInfo[] methods = typeof(Worker).GetMethods(BindingFlags.Instance |
            //BindingFlags.Public);
            //foreach (MethodInfo info in methods)
            //{
            //    Console.Write(info.Name);
            //}
        }   

    }
}
