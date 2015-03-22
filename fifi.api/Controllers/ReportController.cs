using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using fifi.data.entities;
using fifi.domain.models;
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
                var reports = repo.FindAll()
                                  .Select(r => new ReportDTO
                                  {
                                      Id = r.Id,
                                      Description = r.Description,
                                      Incident_Time = r.CreatedOn,
                                      Mode = r.Mode,
                                      Location = new LocationDTO
                                      {
                                          Cross_Street = r.Address,
                                          Lat = r.Lat,
                                          Long = r.Long,
                                          Narrative = r.Narrative
                                      },
                                      Modes = new ModesDTO
                                     {
                                         Personal = r.Mode,
                                         //Other = r.CollisionModes.Split(',')
                                     },
                                     Infrastructure = r.Infrastructure,
                                     Injury = r.Injury,
                                     Collision = r.Collision,
                                     PropertyDamage = r.PropertyDamage,
                                  })
                                  .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
        }

        [ActionName("Interaction")]
        public HttpResponseMessage GetReport()
        {
            using (var repo = new ReportRepository())
            {
                var reports = repo.FindAll()
                                  .Select(r => new ReportDTO
                                  {
                                      Id = r.Id,
                                      Description = r.Description,
                                      Incident_Time = r.CreatedOn,
                                      Mode = r.Mode,
                                      Location = new LocationDTO
                                      {
                                          Cross_Street = r.Address,
                                          Lat = r.Lat,
                                          Long = r.Long,
                                          Narrative = r.Narrative
                                      },
                                      Image = r.Image,
                                      Modes = new ModesDTO
                                      {
                                          Personal = r.Mode,
                                          //Other = r.CollisionModes.Split(',')
                                      },
                                      Infrastructure = r.Infrastructure,
                                      Injury = r.Injury,
                                      Collision = r.Collision,
                                      PropertyDamage = r.PropertyDamage,
                                  })
                                  .ToList();
                return Request.CreateResponse(HttpStatusCode.OK, reports);
            }
        }

        [ActionName("Interaction")]
        public HttpResponseMessage GetReport(int id)
        {
            using (var repo = new ReportRepository())
            {
                var report = repo.Find(r => r.Id == id)
                                 .Select(r => new ReportDTO
                                 {
                                     Id = r.Id,
                                     Description = r.Description,
                                     Incident_Time = r.CreatedOn,
                                     Mode = r.Mode,
                                     Location = new LocationDTO
                                     {
                                         Cross_Street = r.Address,
                                         Lat = r.Lat,
                                         Long = r.Long,
                                         Narrative = r.Narrative
                                     },
                                     Image = r.Image,
                                     Modes = new ModesDTO
                                     {
                                         Personal = r.Mode,
                                         //Other = r.CollisionModes.Split(','),
                                     },
                                     Infrastructure = r.Infrastructure,
                                     Injury = r.Injury,
                                     Collision = r.Collision,
                                     PropertyDamage = r.PropertyDamage,
                                 })
                                 .FirstOrDefault();
                return Request.CreateResponse(HttpStatusCode.OK, report);
            }
        }

        [ActionName("Interaction")]
        public HttpResponseMessage PostReport([FromBody]ReportDTO reportDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, reportDTO);
            }

            using (var repo = new ReportRepository())
            {
                var report = new Report
                {
                    Lat = reportDTO.Location.Lat,
                    Long = reportDTO.Location.Long,
                    Type = "Interaction",
                    Address = reportDTO.Location.Cross_Street,
                    Narrative = reportDTO.Location.Narrative,
                    Mode = reportDTO.Mode,
                    Description = reportDTO.Description,
                    CreatedOn = DateTime.Now,
                    Infrastructure = reportDTO.Infrastructure,
                    Collision =  reportDTO.Collision,
                    PropertyDamage = reportDTO.PropertyDamage,
                    Injury = reportDTO.Injury,
                    CollisionModes = string.Join(",", reportDTO.Modes.Other)
                };

                repo.Add(report);
                repo.Commit();
                reportDTO.Id = report.Id;

                return Request.CreateResponse(HttpStatusCode.OK, reportDTO);

            }
        }

        [ActionName("Status")]
        public HttpResponseMessage GetStatus()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [ActionName("UploadImage")]
        public HttpResponseMessage PostImageFile(int id)
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var image = HttpContext.Current.Request.Files["image"];

                if (image != null)
                {
                    // Validate the uploaded image(optional)
                    var rand = new Random();
                    var unique = rand.Next(1000000).ToString();
                    var ext = Path.GetExtension(image.FileName).ToLower();
                    var fileName = string.Format("{0}-{1}{2}", id, unique, ext);
                    if (ext == ".png" || ext == ".jpg")
                    {
                        // Get the complete file path
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), fileName);

                        // Save the uploaded file to "Images" folder
                        image.SaveAs(fileSavePath);

                        using (var repo = new ReportRepository())
                        {
                            var report = repo.Find(r => r.Id == id).FirstOrDefault();
                            if (report != null)
                            {
                                report.Image = fileName;
                                repo.Commit();
                                return Request.CreateResponse(HttpStatusCode.Created);
                            }
                            else
                            {
                                // delete file
                                // report does not exist
                                return Request.CreateResponse(HttpStatusCode.BadRequest);
                            }
                        }
                    }
                    else
                    {
                        // create err invalid file extension (jpg, png)
                        return Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                }
                else
                {
                    // no image posted
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                // no image posted
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [ActionName("Categories")]
        public HttpResponseMessage GetCategories()
        {
            using (var context = new ReportCategoryRepository())
            {
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
                            Lat = 47.608746f,
                            Long = -122.336894f, 
                            Address = "301 15th Street, Hood River",
                            Narrative = "test",
                            Mode = "Bike",
                            Description = "Doored on 2nd n seneca",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = false,
                            PropertyDamage = false,
                            Injury = false,
                            CollisionModes = "",
                             
                    },
                    new Report { 
                            Lat = 47.60731f,
                            Long = -122.337066f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = true,
                            CollisionModes = "Car,Walk",
                    },
                    new Report { 
                            Lat = 47.606127f,
                            Long = -122.337538f,
                            Address = "Kaze Sushi",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = false,
                            Collision = true,
                            PropertyDamage = false,
                            Injury = true,
                            CollisionModes = "Car",
                    },
                    new Report { 
                            Lat = 47.606818f,
                            Long = -122.333536f,
                            Address = "Kaze Sushi/Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = false,
                            CollisionModes = "Walk",
                    },
                    new Report { 
                            Lat = 47.606561f,
                            Long = -122.334115f,
                            Address = "Kaze Sushi / Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = true,
                            CollisionModes = "Walk",
                    },                    
                    new Report { 
                            Lat = 47.606702f,
                            Long = -122.334984f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = true,
                            CollisionModes = "Car,Walk",
                    },                    
                    new Report { 
                            Lat = 47.608297f,
                            Long = -122.336454f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = true,
                            CollisionModes = "Car,Walk",
                    },                    
                    new Report { 
                            Lat = 47.609509f,
                            Long = -122.338364f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = true,
                            CollisionModes = "Car,Walk",
                    },                    
                    new Report { 
                            Lat = 47.611639f,
                            Long = -122.339523f,
                            Address = "Kaze Sushi, Hood River",
                            Narrative = "test",
                            Mode = "Walk",
                            Description = "Trip and fell on the sidewalk",
                            CreatedOn = new DateTime(2015, 3, 20),
                            Type = "Interaction",
                            Infrastructure = true,
                            Collision = true,
                            PropertyDamage = true,
                            Injury = true,
                            CollisionModes = "Car,Walk",
                    }
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
