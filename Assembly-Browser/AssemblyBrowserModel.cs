using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class AssemblyBrowserModel
    {
        public List<Type> CurrentAssembly = new List<Type>();

        public AssemblyBrowserModel(string path)
        {
            CurrentAssembly = LoadAssembly(path);
        }

        public List<Type> LoadAssembly(string path)
        {
            List<Type> result = new List<Type>();
            Assembly asm = Assembly.LoadFrom(path);
            Type[] types = asm.GetTypes();
            foreach (Type type in types)
            {
                result.Add(type);
            }
            return result;
        }
    }
}
