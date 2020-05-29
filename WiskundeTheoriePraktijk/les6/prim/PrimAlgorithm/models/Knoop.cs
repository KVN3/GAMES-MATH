using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm.models
{
    public class Knoop
    {
        private string identifier;
        public Knoop(string id) { identifier = id; }
        public string Identifier { get { return identifier; } }
    }
}
