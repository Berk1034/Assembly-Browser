using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class Namespace
    {
        public string Name { get; set; }
        public ObservableCollection<Class> Classes { get; set; }

        public Namespace(string name)
        {
            Name = "namespace " + name;
            Classes = new ObservableCollection<Class>();
        }
    }
}
