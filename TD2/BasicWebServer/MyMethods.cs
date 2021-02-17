using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicServerHTTPlistener
{
    class MyMethods
    {
        public MyMethods() {}

        public String MyMethod(System.Collections.Specialized.NameValueCollection c)
        {
            String param1 = c.Get("param1");
            String param2 = c.Get("param2");
            String param3 = c.Get("param3");
            String param4 = c.Get("param4");
            return ("<HTML><BODY> Hello " + param1 + " et " + param2 + "</BODY></HTML>");
        }
    }
}
