using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class Property
    {
        public string Signature { get; set; }
        public Property(PropertyInfo propertyinfo)
        {
            Signature = propertyinfo.PropertyType.ToString() + propertyinfo.Name;
        }
    }
}
