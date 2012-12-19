using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Greg.XmlOperation.Common;

namespace Greg.XmlOperation.Dom
{
    //
    // XmlElement, XmlDocument - sa to klasy implementujace interface natywny. Jest to poprzedni Ling To Xml
    //

    public class DomOperation : IXmlOperator
    {
        private XmlDocument document;

        public string ReadXml()
        {
            document = new XmlDocument();

            LoadXmlDocumentFromFile();

            LoadXmlDocumentFromString();

            SelectNode();

            // InnerXml zwraca XML dla danego elementu
            return SelectNode(); 
        }

        public void WriteToXml()
        {
            
        }

        private void LoadXmlDocumentFromString()
        {
            var doc = CreateNewDocument();

            document.LoadXml(doc.InnerXml);

            
        }

        private void LoadXmlDocumentFromFile()
        {
            document.Load("TestXml.xml");
        }

        private XmlDocument CreateNewDocument()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = "Patrick Hines";
            XmlElement phone1 = doc.CreateElement("Phone");
            phone1.SetAttribute("Type", "Home");
            phone1.InnerText = "206-555-0144";
            XmlElement phone2 = doc.CreateElement("Phone");
            phone2.SetAttribute("Type", "Work");
            phone2.InnerText = "425-555-0145";
            XmlElement street1 = doc.CreateElement("Street1");
            street1.InnerText = "123 Main St";
            XmlElement city = doc.CreateElement("City");
            city.InnerText = "Mercer Island";
            XmlElement state = doc.CreateElement("State");
            state.InnerText = "WA";
            XmlElement postal = doc.CreateElement("Postal");
            postal.InnerText = "68042";
            XmlElement address = doc.CreateElement("Address");
            address.AppendChild(street1);
            address.AppendChild(city);
            address.AppendChild(state);
            address.AppendChild(postal);
            XmlElement contact = doc.CreateElement("Contact");
            contact.AppendChild(name);
            contact.AppendChild(phone1);
            contact.AppendChild(phone2);
            contact.AppendChild(address);
            XmlElement contacts = doc.CreateElement("Contacts");
            contacts.AppendChild(contact);
            doc.AppendChild(contacts);

            return doc;
        }

        private String SelectNode()
        {
            // szukanie elementu jest wykonywane za pomoca XPATH!!!
            var node = document.SelectSingleNode("//Contacts/Contact/Address/City");

            // pobieranie wszystkich nodow typu city
            var node1 = document.GetElementsByTagName("City");

            // pobieranie zawartosci noda
            var cityName = node1[0].InnerXml;

            return node.InnerXml;
        }
    }
}
