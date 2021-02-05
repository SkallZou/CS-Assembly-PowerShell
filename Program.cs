using System;
using System.IO;
using System.Reflection;

namespace AssemblyLoader
{
    public class Program
    {
        public static void Main()
        {
            Byte[] bytes =
                File.ReadAllBytes(
                    "C:\\Users\\Root\\Desktop\\Programming\\C#\\Seatbelt-master\\Seatbelt-master\\Seatbelt\\bin\\Debug\\Seatbelt.exe");
            RunAssembly(bytes, new [] {"-group=user"});
            Console.WriteLine("Press any key to quit.");
            Console.Read();
        }

        public static void RunAssembly(Byte[] assemblyBytes, string[] param)
        {
            Assembly assembly = Assembly.Load(assemblyBytes); //Load the assembly in memory
            MethodInfo entryPoint = assembly.EntryPoint; //Find the entry point of the assembly
            object[] parameters = new[] {param};
            object execute = entryPoint.Invoke(null, parameters);
        }
    }
}