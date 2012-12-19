using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greg.XmlOperation.Common;
using Xml = System.Xml;

namespace Greg.XmlOperation.XmlReader
{

    //
    // XmlReader zapewnia bardzo szybki dostep do xmlow, nie przechowywuje calego pliku w pamieci tylko np odczytuje po kolei nody
    //

    public class ReaderTest : IXmlOperator
    {
        public string ReadXml()
        {
            ReadXmlAndEnumerateTypes();

            ReadXmlFile();

            return String.Empty;
        }

        public void WriteToXml()
        {
            
        }

        private string ReadXmlFile()
        {
            using (Xml.XmlReader reader = Xml.XmlReader.Create("TestXml.xml"))
            {
                var text = reader.ReadInnerXml();

                while (reader.Read())
                {
                    int a = 100;
                }


            }

            return String.Empty;
        }

        private void ReadXmlAndEnumerateTypes()
        {
            using (Xml.XmlReader reader = Xml.XmlReader.Create("TestXml.xml"))
            {

                // funkcja ktora przeskakuje do czesci xmla zawierajacej dane. Omija takie typy nodow jak:
                // ProcessingInstruction, DocumentType, Comment, Whitespace, or SignificantWhitespace.
                reader.MoveToContent();
                
                //
                //
                // PRZECHODZENIE PO NODACH ODBYWA SIE STRASZNIE SPECYFICZNIE:
                // 1. <author>
                // 2. text z authora
                // 3. </author> 
                // i tak node po nodzie!!!!
                //
                //
                // Parse the file and display each of the nodes. 
                
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case Xml.XmlNodeType.Element:
                            Console.Write("<{0}>", reader.Name);
                            break;
                        case Xml.XmlNodeType.Text:
                            Console.Write(reader.Value);
                            break;
                        case Xml.XmlNodeType.CDATA:
                            Console.Write("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case Xml.XmlNodeType.ProcessingInstruction:
                            Console.Write("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case Xml.XmlNodeType.Comment:
                            Console.Write("<!--{0}-->", reader.Value);
                            break;
                        case Xml.XmlNodeType.XmlDeclaration:
                            Console.Write("<?xml version='1.0'?>");
                            break;
                        case Xml.XmlNodeType.Document:
                            break;
                        case Xml.XmlNodeType.DocumentType:
                            Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case Xml.XmlNodeType.EntityReference:
                            Console.Write(reader.Name);
                            break;
                        case Xml.XmlNodeType.EndElement:
                            Console.Write("</{0}>", reader.Name);
                            break;
                    }
                }

                

            }
        }
    }
}
