using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.data.contexts;
using fifi.data.entities;

namespace fifi.domain.repositories
{
    public class ReportCategoryRepository : BaseRepository<ReportCategory>
    {
        public ReportCategoryRepository() : base(new DataContext())
        {

        }

        public ReportCategoryRepository(DataContext context) : base(context)
        {

        }
    }
}
