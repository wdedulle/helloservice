using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dulle.Education.Hello
{
    [DataContract]
    public class Name
    {
        [DataMember]
        public string Fist;
        [DataMember]
        public string Last;
    }

    [ServiceContract]
    public interface IHello
    {
        [OperationContract]
        string SayHello(Name person);
    }

    public class HelloService : IHello
    {
        public string SayHello(Name person)
        {
            return string.Format("Hello {0} {1}", person.Fist, person.Last);
        }
    }
}
