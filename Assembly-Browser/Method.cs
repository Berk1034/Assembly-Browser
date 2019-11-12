using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assembly_Browser
{
    public class Method
    {
        public string Signature { get; set; }

        public Method(MethodInfo methodinfo)
        {
            String[] param = methodinfo.GetParameters().Select(p => String.Format("{0} {1}", p.ParameterType.Name, p.Name)).ToArray();
            Signature = String.Format("{0} {1} ({2})", methodinfo.ReturnType.Name, methodinfo.Name, String.Join(",", param));
        }
    }
}
