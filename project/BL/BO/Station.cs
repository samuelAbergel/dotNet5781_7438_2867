using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Longitude { get; set; }
        public string Lattitude { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
