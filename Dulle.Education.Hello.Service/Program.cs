using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Dulle.Education.Hello.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddressHttp = "http://" 
                + Environment.MachineName 
                + ":80/Temporary_Listen_Addresses/helloservice";
            //string baseAddressTcp = "net.tcp://" + Environment.MachineName + ":8731/Design_Time_Addresses/helloservice";

            ServiceHost host = new ServiceHost(typeof(HelloService), new Uri(baseAddressHttp));
            try
            {
                host.AddServiceEndpoint(
                    typeof(IHello),
                    new BasicHttpBinding(BasicHttpSecurityMode.None),
                    "basic"
                    );

                host.Description.Behaviors.Add(new ServiceMetadataBehavior());
                host.AddServiceEndpoint(
                    typeof(IMetadataExchange),
                    MetadataExchangeBindings.CreateMexHttpBinding(),
                    "mex"
                    );
                host.Open();
                PrintServiceInfo(host);
                Console.ReadLine();
                host.Close();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                host.Abort();
            }
        }

        static void PrintServiceInfo( ServiceHost host )
        {
            Console.WriteLine("{0} running", host.Description.ServiceType);
            foreach( ServiceEndpoint endPoint in host.Description.Endpoints )
            {
                Console.WriteLine(">>> {0}", endPoint.Address);
            }

        }
    }
}
