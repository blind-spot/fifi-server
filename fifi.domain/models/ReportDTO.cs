using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.domain.models
{
    public class ReportDTO
    {
        public int Id { get; set; }
        public LocationDTO Location { get; set; }
        public string Mode { get; set; }
        public string Description { get; set; }
        public DateTime Incident_Time { get; set; }
        public string Image { get; set; }
        public bool Infrastructure { get; set; }
        public bool Collision { get; set; }
        public bool PropertyDamage { get; set; }
        public bool Injury { get; set; }
        public ModesDTO Modes { get; set; }
    }
}
