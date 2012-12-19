using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Greg.XmlOperation.Common;

namespace Greg.XmlOperation.LinqToXml
{
    //
    // Uzycie Linq To Xml - klasy X{name} - XDocument, XElement. O wiele latwiejsze uzycie niz klas natywnych.
    // Caly dokument jest przetrzymywany w pamieci wiec moze byc problem z duzymi plikami.
    // 
    //

    public class LoadDocFromFile : IXmlOperator
    {
        private XDocument document;

        public string ReadXml()
        {

            document = new XDocument();

            LoadXmlDocument();

            BasicOperations();

            GetBookWithComputerGenry();

            var element1 = CreateNewXml();

            return document.ToString();
        }

        public void WriteToXml()
        {

        }

        private void LoadXmlDocument()
        {
            // otwieranie dokumentu z pliku - otrzymanie elementu najwyzszego poziomu
            // z tego poziomu np nie mozemy otrzymac nodow 'book'. Zeby pobrac book trzeba najpierw pobrac XElement 'catalog'
            document = XDocument.Load("TestXml.xml");
        }

        private void BasicOperations()
        {
            // pobranie pierwszego elementu z dokumentu - na danym poziomie
            var catalog = document.Element("catalog");

            // pobieranie wszystkich nodow 'book' - pobranie wszystkich nodow typu 'book' na danym poziomie 
            var books = catalog.Elements("book");

            var count = books.Count();

            // wyszukanie elementu na podstawie wartosci atrybutu 'id'
            var book = books.FirstOrDefault(x => x.Attribute("id").Value == "bk101");

            // pobieranie nodow danego typu na dowolnym poziomie, przeszukiwane sa wszystkie poziomy
            books = document.Descendants("book");
        }

        private void GetBookWithComputerGenry()
        {
            /*
             * najpierw otrzymujemy wszystkie nody book:
             * 
             *<book id="bk112">
             *   <author>Galos, Mike</author>
             *   <title>Visual Studio 7: A Comprehensive Guide</title>
             *   <genre>Computer</genre>
             *   <price>49.95</price>
             *   <publish_date>2001-04-16</publish_date>
             *   <description>
             *       Microsoft Visual Studio 7 is explored in depth,
             *       looking at how Visual Basic, Visual C++, C#, and ASP+ are
             *       integrated into a comprehensive development
             *       environment.
             *   </description>
             *</book>
             *
             * nastepnie pobieramy elemement 'genre' z kazdego z elementow 
             * 
             * <genre>Computer</genre> 
             * 
             * i sprawdzamy jego wartosc: Computer
             */
            var book1 = document.Descendants("book").Where(x => x.Element("genre").Value == "Computer").ToList();
        }

        private XElement CreateNewXml()
        {
            XElement contacts =
                new XElement("Contacts",
                    new XElement("Contact",
                        new XElement("Name", "Patrick Hines"),
                        new XElement("Phone", "206-555-0144",
                        new XAttribute("Type", "Home")),
                        new XElement("phone", "425-555-0145",
                        new XAttribute("Type", "Work")),
                        new XElement("Address",
                            new XElement("Street1", "123 Main St"),
                            new XElement("City", "Mercer Island"),
                            new XElement("City", "Mercer Island"),
                            new XElement("State", "WA"),
                            new XElement("Postal", "68042")
            )
        )
    );

            return contacts;
        }
    }
}
