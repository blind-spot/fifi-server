using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.data.entities
{
    public class GeoLocation
    {
        //public int Id { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public string Address { get; set; }
        public string Narrative { get; set; }
    }
}
