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

            string getter = "";
            var getmethod = propertyinfo.GetGetMethod(true);
            if (getmethod != null)
            {
                getter = " get; ";
                if (getmethod.IsPrivate)
                {
                    getter = " private get; ";
                }
            }

            string setter = "";
            var setmethod = propertyinfo.GetSetMethod(true);
            if (setmethod != null)
            {
                setter = " set; ";
                if (setmethod.IsPrivate)
                {
                    setter = " private set; ";
                }
            }
            
            Signature = AccessModifier + " " + propertyinfo.PropertyType.Name + " " + propertyinfo.Name + "{" + getter + setter + "}";
        }
    }
}
