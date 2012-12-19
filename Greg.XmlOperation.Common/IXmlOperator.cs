using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greg.XmlOperation.Common
{
    public interface IXmlOperator
    {
        string ReadXml();

        void WriteToXml();
    }
}
