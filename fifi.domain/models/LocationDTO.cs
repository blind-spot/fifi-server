using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.domain.models
{
    public class LocationDTO
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Cross_Street { get; set; }
        public string Narrative { get; set; }
    }
}
