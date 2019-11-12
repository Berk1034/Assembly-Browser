using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class Class
    {
        public string Name { get; set; }
        public ObservableCollection<Method> Methods { get; set; }

        public Class(Type type)
        {
            Name = type.Name;
            Methods = new ObservableCollection<Method>();
            GetMethods(type);
        }

        public void GetMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            ObservableCollection<Method> tmp = new ObservableCollection<Method>();
            foreach (MethodInfo methodInfo in methods)
            {
                Method method = new Method(methodInfo);
                tmp.Add(method);
            }
            Methods = tmp;
        }
    }
}
