using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.data;
using fifi.data.contexts;
using fifi.domain.repositories;
using fifi.data.entities;

namespace fifi.data.tests
{
    [TestFixture]
    public class ReportTests
    {
        [Test]
        public void ShouldAddReports()
        {
            using (var repo = new ReportRepository())
            {
                var reports = new List<Report>()
                {
                    new Report { 
                        Location = new GeoLocation 
                        {
                            Lat = 45.712113f,
                            Long = -121.527200f, 
                            Address = "301 15th Street, Hood River",
                            Narrative = "test"
                        }, 
                        Type = "Interaction"
                    },
                    new Report { 
                        Location = new GeoLocation 
                        {
                            Lat = -45.708457f,
                            Long = -121.514432f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test"
                        }, 
                        Type = "Interaction"
                    },

                };
                foreach (var report in reports)
                {
                    repo.Add(report);
                }

                repo.Commit();
            }
        }

        [Test]
        public void ShouldRemoveAllReports()
        {
            using (var context = new ReportRepository())
            {
                
            }
        }
    }
}
