using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Serializable]
    public class BLExeption : Exception
    {
        public BLExeption(string msg) : base(msg) { }
    }
}
