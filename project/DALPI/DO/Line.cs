using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Line
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public Areas Area { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public IEnumerable<Station> listOfStationInLine { get; set; } 
    }
}
