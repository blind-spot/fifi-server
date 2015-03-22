using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.data.entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public string Address { get; set; }
        public string Narrative { get; set; }
        public string Mode { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Image { get; set; }
        public bool Infrastructure { get; set; }
        public bool Collision { get; set; }
        public bool PropertyDamage { get; set; }
        public bool Injury { get; set; }
        public string CollisionModes { get; set; }
    }
}
