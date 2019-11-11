using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class Class
    {
        public string Name { get; set; }

        public Class(Type type)
        {
            Name = type.Name;
        }
    }
}
