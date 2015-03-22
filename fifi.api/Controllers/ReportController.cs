using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using fifi.data.entities;
using fifi.domain.repositories;

namespace fifi.api.Controllers
{
    public class ReportController : ApiController
    {
        // GET api/values
        [ActionName("All")]
        public HttpResponseMessage GetReports()
        {

            using (var repo = new ReportRepository())
            {
                var reports = repo.FindAll().ToList();
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
        }

        [ActionName("Interaction")]
        public HttpResponseMessage GetReport()
        {
            using (var repo = new ReportRepository())
            {
                var report = repo.Find(r => r.Type == "Interaction").ToList();
                return Request.CreateResponse(HttpStatusCode.OK, report);
            }
        }

        [ActionName("Interaction")]
        public HttpResponseMessage GetReport(int id)
        {
            using (var repo = new ReportRepository())
            {
                var report = repo.Find(r => r.Id == id).FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, report);
            }

        }

        [ActionName("Status")]
        public HttpResponseMessage GetStatus()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [ActionName("Categories")]
        public HttpResponseMessage GetCategories()
        {
            using (var context = new ReportCategoryRepository())
            {
                //var categories = new[] 
                //{
                //    "Abandoned Vehicle",
                //    "Graffiti Report",
                //    "Illegal Dumping",
                //    "Parking Enforcement",
                //    "Pothole",
                //    "Streetlight Report",
                //    "Other Inquiry"
                //};

                var categories = context.FindAll().ToArray();

                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
        }

        [ActionName("LoadData")]
        public HttpResponseMessage GetLoadData()
        {
            using (var repo = new ReportRepository())
            {
                var reports = new List<Report>()
                {
                    new Report { 
                            Lat = 45.712113f,
                            Long = -121.527200f, 
                            Address = "301 15th Street, Hood River",
                            Narrative = "test",
                            Mode = "Bike",
                            Description = "Doored on 2nd n seneca",
                            CreatedOn = new DateTime(2015, 3, 20),
                        Type = "Interaction"
                    },
                    new Report { 
                            Lat = -45.708457f,
                            Long = -121.514432f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                        Type = "Interaction"
                    },

                };
                foreach (var report in reports)
                {
                    repo.Add(report);
                }

                repo.Commit();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
