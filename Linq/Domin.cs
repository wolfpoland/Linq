﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Domin
    {
        public Domin()
        {
            Max = 0;
            tmp = new Car();
            wiadomosc = "";
            tmpF = new Fuzja();
            
        }
        public int Max { get; set; }
        public Car tmp { get; set; }
        public Fuzja tmpF { get; set; }
        public Object obj { get; set; }
        public string wiadomosc { get; set; }
    }
}
