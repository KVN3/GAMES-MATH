using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm.models
{
   public class Kant
    {
        private Knoop a, b; private int lengte;
        public Kant(Knoop a, Knoop b, int lengte) { this.a = a; this.b = b; this.lengte = lengte; }
        public Knoop KnoopA { get { return a; } }
        public Knoop KnoopB { get { return b; } }
        public int Lengte { get { return lengte; } }
    }
}
