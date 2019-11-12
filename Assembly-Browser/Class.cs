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
        public ObservableCollection<Field> Fields { get; set; }
        public ObservableCollection<Property> Properties { get; set; }

        public Class(Type type)
        {
            Name = type.Name;
            Methods = new ObservableCollection<Method>();
            GetMethods(type);
            GetFields(type);
            GetProperties(type);
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

        public void GetFields(Type type)
        {
            FieldInfo[] fields = type.GetFields();
            ObservableCollection<Field> tmp = new ObservableCollection<Field>();
            foreach (FieldInfo fieldInfo in fields)
            {
                Field field = new Field(fieldInfo);
                tmp.Add(field);
            }
            Fields = tmp;
        }

        public void GetProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties();
            ObservableCollection<Property> tmp = new ObservableCollection<Property>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                Property property = new Property(propertyInfo);
                tmp.Add(property);
            }
            Properties = tmp;
        }
    }
}
