using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String param1 = args[0];
            String param2 = args[1];

            Console.WriteLine("<HTML><BODY> <br>Ceci est l'exe et tout ce que j'ai à dire est :" + param1+" "+param2+"</BODY></HTML>");
        }
    }
}
