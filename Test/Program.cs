using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ServiceReference1;

namespace Test
{
    class Program
    {
        static ServiceReference1.BLServiceOf_SensorDtoClient client = new BLServiceOf_SensorDtoClient();
        static void Main(string[] args)
        {
            SensorDto s =client.Get(new object[] {1});
            Console.ReadKey();
        }
    }
}
