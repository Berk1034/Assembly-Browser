using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Assembly_Browser
{
    public class Class
    {
        public string Name { get; set; }
        public ObservableCollection<Method> Methods { get; set; }
        public ObservableCollection<Field> Fields { get; set; }
        public ObservableCollection<Property> Properties { get; set; }
        public ObservableCollection<Constructor> Constructors { get; set; }

        public ICollection Collections
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer(){ Collection = Methods },
                    new CollectionContainer(){ Collection = Fields },
                    new CollectionContainer(){ Collection = Properties },
                    new CollectionContainer(){ Collection = Constructors }
                };
            }
        }

        public Class(Type type)
        {
            TypeAttributes attributes = type.Attributes;

            if (attributes.HasFlag(TypeAttributes.Public))
            {
                Name = "public ";
            }
            else if (attributes.HasFlag(TypeAttributes.NotPublic))
            {
                Name = "private ";
            }
            else if (attributes.HasFlag(TypeAttributes.NestedFamily))
            {
                Name = "protected ";
            }
            else if (attributes.HasFlag(TypeAttributes.NestedAssembly))
            {
                Name = "internal ";
            }

            if (attributes.HasFlag(TypeAttributes.Interface))
            {
                Name = Name + "interface ";
            }
            else if (attributes.HasFlag(TypeAttributes.Class))
            {
                Name = Name + "class ";
            }

            Name = Name + type.Name;
            Methods = new ObservableCollection<Method>();

            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            GetMethods(type, bindingFlags);
            GetFields(type, bindingFlags);
            GetProperties(type, bindingFlags);
            GetConstructors(type, bindingFlags);
        }

        public void GetMethods(Type type, BindingFlags bindingFlags)
        {
            MethodInfo[] methods = type.GetMethods(bindingFlags);
            ObservableCollection<Method> tmp = new ObservableCollection<Method>();
            foreach (MethodInfo methodInfo in methods)
            {
                Method method = new Method(methodInfo);
                tmp.Add(method);
            }
            Methods = tmp;
        }

        public void GetFields(Type type, BindingFlags bindingFlags)
        {
            FieldInfo[] fields = type.GetFields(bindingFlags);
            ObservableCollection<Field> tmp = new ObservableCollection<Field>();
            foreach (FieldInfo fieldInfo in fields)
            {
                Field field = new Field(fieldInfo);
                tmp.Add(field);
            }
            Fields = tmp;
        }

        public void GetProperties(Type type, BindingFlags bindingFlags)
        {
            PropertyInfo[] properties = type.GetProperties(bindingFlags);
            ObservableCollection<Property> tmp = new ObservableCollection<Property>();
            foreach (PropertyInfo propertyInfo in properties)
            {
                Property property = new Property(propertyInfo);
                tmp.Add(property);
            }
            Properties = tmp;
        }

        public void GetConstructors(Type type, BindingFlags bindingFlags)
        {
            ConstructorInfo[] constructors = type.GetConstructors(bindingFlags);
            ObservableCollection<Constructor> tmp = new ObservableCollection<Constructor>();
            foreach(ConstructorInfo constructorInfo in constructors)
            {
                Constructor constructor = new Constructor(constructorInfo);
                tmp.Add(constructor);
            }
            Constructors = tmp;
        }
    }
}
