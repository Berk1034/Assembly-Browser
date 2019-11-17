using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary
{
    public class AssemblyBrowserModel
    {
        private readonly List<Namespace> _namespaces;

        public AssemblyBrowserModel()
        {
            _namespaces = new List<Namespace>();
        }

        public List<Namespace> LoadAssembly(string path)
        {
            Assembly asm = Assembly.LoadFrom(path);
            return GetNamespaces(asm.GetTypes());
        }

        private List<Namespace> GetNamespaces(IEnumerable<Type> Assembly)
        {
            foreach (Type type in Assembly)
            {
                Namespace nmspace = new Namespace(type.Namespace);
                Namespace innernamespace = _namespaces.FirstOrDefault(namesp => namesp.Name == nmspace.Name);
                if (innernamespace == default(Namespace))
                {
                    nmspace.Classes.Add(new Class(type));
                    AddValue(nmspace);
                }
                else
                {
                    innernamespace.Classes.Add(new Class(type));
                }
            }
            return _namespaces;
        }

        private void AddValue(Namespace value)
        {
            _namespaces.Add(value);
        }
    }
}
