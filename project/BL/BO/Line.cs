﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Line
    {
        public int Code { get; set; }
        public Areas Area { get; set; }
        public string FirstStation { get; set; }
        public string LastStation { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
