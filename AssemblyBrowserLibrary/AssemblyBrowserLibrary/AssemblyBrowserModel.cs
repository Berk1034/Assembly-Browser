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
        private readonly ObservableCollection<Namespace> _namespaces = new ObservableCollection<Namespace>();
        public readonly ObservableCollection<Namespace> Namespaces;
        public List<Type> CurrentAssembly = new List<Type>();

        public AssemblyBrowserModel(string path)
        {
            CurrentAssembly = LoadAssembly(path);
            GetNamespaces(CurrentAssembly);
            Namespaces = new ObservableCollection<Namespace>(_namespaces);
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

        public void GetNamespaces(List<Type> Assembly)
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
        }

        private void AddValue(Namespace value)
        {
            _namespaces.Add(value);
        }
    }
}
