using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.data.contexts;
using fifi.data.entities;

namespace fifi.domain.repositories
{
    public class ReportRepository : BaseRepository<ReportCategory>
    {
        public ReportRepository() : base(new DataContext())
        {

        }

        public ReportRepository(DataContext context) : base(context)
        {

        }
    }
}
