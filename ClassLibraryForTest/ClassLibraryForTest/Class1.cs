using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForTest
{
    public class Class1
    {
        public int a;
        public bool b { get; set; }
        public void Create(int a)
        {
            this.a = a;
            b = true;
        }
        public Class1(int a, bool b)
        {

        }
        internal string c = "Lol";
    }
}
