using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCF_ServiceBlockchain.BlockchainService)))
            {
                host.Open();
                Console.WriteLine($"{DateTime.Now}:Сервер стартовал!");
                Console.ReadLine();
            }
        }
    }
}
