using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class DLExeption :Exception
    {
        public DLExeption(string msg): base(msg) { }
    }

   
    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }

        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
}
