using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace XMLService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        XElement addMember(string username, string password, XElement xml);

        [OperationContract]
        bool verification(string username, string password, XElement xml);

        [OperationContract]
        bool searchMember(string username, XElement xml);
    }
}
