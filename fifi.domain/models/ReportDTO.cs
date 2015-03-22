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
    }
}
