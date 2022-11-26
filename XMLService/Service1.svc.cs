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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public XElement addMember(string username, string password, XElement xml)
        {
            XElement member = new XElement("Member", new XAttribute("username", username), new XAttribute("password", password));
           
            xml.Add(member);
            return xml;
        }

        public bool verification(string username, string password, XElement xml)
        {
            var match = xml.Descendants("Member").Where(x => (string)x.Attribute("username") == username).Where(x => (string)x.Attribute("password") == password);
            if(match.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public bool searchMember(string username, XElement xml)
        {
            var match = xml.Descendants("Member").Where(x => (string)x.Attribute("username") == username);
            if (match.Count() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
