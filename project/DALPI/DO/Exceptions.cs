using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class badIdBusexeption :Exception
    {
        public badIdBusexeption(int id): base(string.Format($"this id bus does not exist : {id}")) { }
        public badIdBusexeption(Bus bus) : base(string.Format($"this id bus already exist : {bus.LicenseNum}")) { }
    }

    [Serializable]
    public class badIdLineexeption : Exception
    {
        public badIdLineexeption(int id) : base(string.Format($"this id Line does not  exist : {id}")) { }
        public badIdLineexeption(Line line) : base(string.Format($"this id Line already exist : {line.Id}")) { }
    }
    [Serializable]
    public class badIDStationexeption : Exception
    {
        public badIDStationexeption(int id) : base(string.Format($"this code station does not exist : {id}")) { }
        public badIDStationexeption(Station station) : base(string.Format($"this code station already exist : {station.Code}")) { }
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
