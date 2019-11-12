using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLibrary
{
    public class Property
    {
        public string Signature { get; set; }
        public Property(PropertyInfo propertyinfo)
        {
            string AccessModifier = "";

            if (propertyinfo.PropertyType.IsPublic)
            {
                AccessModifier = "public";
            }
            else if (propertyinfo.PropertyType.IsNotPublic)
            {
                AccessModifier = "private";
            }
            else if (propertyinfo.PropertyType.IsNestedFamily)
            {
                AccessModifier = "protected";
            }
            else if (propertyinfo.PropertyType.IsNestedAssembly)
            {
                AccessModifier = "internal";
            }

            Signature = AccessModifier + " " + propertyinfo.PropertyType.Name + " " + propertyinfo.Name;
        }
    }
}
