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
        [ActionName("Status")]
        public HttpResponseMessage GetStatus()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [ActionName("Categories")]
        public HttpResponseMessage GetCategories()
        {
            using (var context = new ReportRepository())
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
    }
}
