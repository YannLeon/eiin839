using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soap_web_service_client
{
    class Program
    {
        static void Main(string[] args)
        {
            calculator.CalculatorSoap c = new calculator.CalculatorSoapClient() ;
            Console.WriteLine(c.Add(11, 11)) ;
            Console.ReadLine();
        }
    }
}
