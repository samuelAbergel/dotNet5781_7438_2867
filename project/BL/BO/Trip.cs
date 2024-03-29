﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Trip
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int LineId { get; set; }
        public int InStation { get; set; }
        public int InAt { get; set; }
        public int OutStation { get; set; }
        public int OutAt { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
