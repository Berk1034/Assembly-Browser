using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class Field
    {
        public string Signature { get; set; }
        public Field(FieldInfo fieldinfo)
        {
            Signature = fieldinfo.FieldType.ToString() + fieldinfo.Name;
        }
    }
}
