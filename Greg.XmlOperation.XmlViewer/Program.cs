using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greg.XmlOperation.Common;
using Greg.XmlOperation.Dom;
using Greg.XmlOperation.LinqToXml;
using Greg.XmlOperation.XmlReader;

namespace Greg.XmlOperation.XmlViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            IXmlOperator oXmlOperator = new ReaderTest();
            
            Console.Write(oXmlOperator.ReadXml()); 
            
            oXmlOperator.WriteToXml();

            Console.WriteLine("End");
            
            Console.Read();
        }
    }
}
